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
        private PriorityManagerFactory PriorityManagerFactory;

        public int CreateTicket(string title, Priority priority, string assignedTo, string description, DateTime createdTime, bool isPayingCustomer)
        {
            title.ThrowIfArgumentIsEmptyOrNull("Title or description were null");
            description.ThrowIfArgumentIsEmptyOrNull("Title or description were null");

            User user = null;
            using (var userRepository = new UserRepository())
            {
                if (assignedTo != null)
                {
                    user = userRepository.GetUser(assignedTo);
                }
                user.ThrowIfArgumentIsNull("User " + assignedTo + " not found");

                StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, userRepository);
                PriorityManagerFactory = StrategyPriorityManager.GetStrategyPriorityManager(priority);
            }

            var ticket = new Ticket()
            {
                Title = PriorityManagerFactory.Title,
                AssignedUser = user,
                Priority = PriorityManagerFactory.Priority,
                Description = description,
                Created = PriorityManagerFactory.CreatedTime,
                PriceDollars = PriorityManagerFactory.Price,
                AccountManager = PriorityManagerFactory.AccountManager
            };

            return TicketRepository.CreateTicket(ticket);
        }

        public void AssignTicket(int ticketId, string username)
        {
            User user = null;
            using (var userRepository = new UserRepository())
            {
                if (username != null)
                {
                    user = userRepository.GetUser(username);
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