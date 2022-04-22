using System;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Domain.TicketAggregate
{
    public class MediumPriority : PriorityManagerFactory
    {
        public MediumPriority(string title, string assignedTo, bool isPayingCustomer, DateTime createdTime, IUserRepository userRepository)
            : base(title, assignedTo, isPayingCustomer, createdTime, userRepository)
        {
            this.Priority = Priority.Medium;
        }

        public override void RaisedPriority()
        {
            if (CreatedTime < DateTime.UtcNow - TimeSpan.FromHours(1))
            {
                this.Priority = Priority.High;
            }
            else if (Title.Contains("Crash") || Title.Contains("Important") || Title.Contains("Failure"))
            {
                this.Priority = Priority.High;
            }
        }
    }
}
