using System;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Domain.TicketAggregate
{
    public class LowPriority : PriorityManagerFactory
    {
        public LowPriority(string title, string assignedTo, bool isPayingCustomer, DateTime createdTime, IUserRepository userRepository)
            : base(title, assignedTo, isPayingCustomer, createdTime, userRepository)
        {
            this.Priority = Priority.Low;
        }

        public override void RaisedPriority()
        {
            if (CreatedTime < DateTime.UtcNow - TimeSpan.FromHours(1))
            {
                this.Priority = Priority.Medium;
            }
            else if (Title.Contains("Crash") || Title.Contains("Important") || Title.Contains("Failure"))
            {
                this.Priority = Priority.Medium;
            }
        }
    }
}
