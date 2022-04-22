using System;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Domain.TicketAggregate
{
    public class HighPriority : PriorityManagerFactory
    {
        public HighPriority(string title, string assignedTo, bool isPayingCustomer, DateTime createdTime, IUserRepository userRepository)
            : base(title, assignedTo, isPayingCustomer, createdTime, userRepository)
        {
            this.Priority = Priority.High;
        }

        public override void RaisedPriority()
        {
            this.Priority = Priority.High;
        }
    }
}
