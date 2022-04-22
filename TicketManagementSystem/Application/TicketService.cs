using System;
using System.IO;
using System.Text.Json;
using TicketManagementSystem.Application.Common.ExtensionMethods;
using TicketManagementSystem.Domain.TicketAggregate;
using TicketManagementSystem.Domain.UserAggregate;
using TicketManagementSystem.Infrastructure.Persistence;

namespace TicketManagementSystem
{
    public class TicketService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public int CreateTicket(string title, Priority priority, string assignedTo, string description, DateTime createdTime, bool isPayingCustomer)
        {
            title.ThrowIfArgumentIsEmptyOrNull("Title or description were null");
            description.ThrowIfArgumentIsEmptyOrNull("Title or description were null");

            User user = null;
            using (var ur = new UserRepository())
            {
                if (assignedTo != null)
                {
                    user = ur.GetUser(assignedTo);
                }
            }
            user.ThrowIfArgumentIsNull("User " + assignedTo + " not found");

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            var ticket = new Ticket()
            {
                Title = title,
                AssignedUser = user,
                Priority = priority,
                Description = description,
                Created = createdTime,
                PriceDollars = factory.Price,
                AccountManager = factory.AccountManager
            };

            var id = TicketRepository.CreateTicket(ticket);

            return id;
        }

        public void AssignTicket(int ticketId, string username)
        {
            User user = null;
            using (var ur = new UserRepository())
            {
                if (username != null)
                {
                    user = ur.GetUser(username);
                }
            }
            user.ThrowIfArgumentIsNull("User not found");

            var ticket = TicketRepository.GetTicket(ticketId);
            ticket.ThrowIfArgumentIsNull("No ticket found for id " + ticketId);
            ticket.AssignedUser = user;

            TicketRepository.UpdateTicket(ticket);
        }

        private void WriteTicketToFile(Ticket ticket)
        {
            var ticketJson = JsonSerializer.Serialize(ticket);
            File.WriteAllText(Path.Combine(Path.GetTempPath(), $"ticket_{ticket.Id}.json"), ticketJson);
        }
    }
}