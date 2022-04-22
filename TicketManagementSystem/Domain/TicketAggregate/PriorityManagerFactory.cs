using System;
using EmailService;
using TicketManagementSystem.Domain.UserAggregate;
using TicketManagementSystem.Infrastructure.Persistence;

namespace TicketManagementSystem.Domain.TicketAggregate
{
    public abstract class PriorityManagerFactory 
    {
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public string AssignedTo { get; set; }
        public bool IsPayingCustomer { get; set; }
        public User AccountManager { get; set; }
        public double Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public readonly IUserRepository _userRepository;

        public PriorityManagerFactory(string title, string assignedTo, bool isPayingCustomer, DateTime createdTime, IUserRepository userRepository) {
            Title = title;
            AssignedTo = assignedTo;
            IsPayingCustomer = isPayingCustomer;
            Price = 0;
            CreatedTime = createdTime;
            _userRepository = userRepository;
        }

        public void CalculatePrice()
        {
            if (IsPayingCustomer)
            {
                AccountManager = _userRepository.GetAccountManager();
            }

            if (AccountManager != null)
            {
                if (Priority == Priority.High)
                {
                    Price = 100;
                }
                else
                {
                    Price = 50;
                }
            }
        }

        public void NotifyAdministrator()
        {
            if (Priority == Priority.High)
            {
                var emailService = new EmailServiceProxy();
                emailService.SendEmailToAdministrator(Title, AssignedTo);
            }
        }

        public abstract void RaisedPriority();
    }
}