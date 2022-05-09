using System;
using System.Collections.Generic;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Domain.TicketAggregate
{
    public class StrategyPriorityManager
    {
        private readonly Dictionary<Priority, PriorityManagerFactory> Strategy;

        public StrategyPriorityManager(string title, string assignedTo, bool isPayingCustomer, DateTime createdTime, IUserRepository userRepository)
        {
            Strategy = new Dictionary<Priority, PriorityManagerFactory>();
            Strategy.Add(Priority.Low, new LowPriority(title, assignedTo, isPayingCustomer, createdTime, userRepository));
            Strategy.Add(Priority.Medium, new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, userRepository));
            Strategy.Add(Priority.High, new HighPriority(title, assignedTo, isPayingCustomer, createdTime, userRepository));
        }

        public PriorityManagerFactory GetStrategyPriorityManager(Priority priority)
        {
            var priorityManager = Strategy.GetValueOrDefault(priority);

            priorityManager.RaisedPriority();
            priorityManager.CalculatePrice();
            priorityManager.NotifyAdministrator();

            return priorityManager;
        }
    }
}
