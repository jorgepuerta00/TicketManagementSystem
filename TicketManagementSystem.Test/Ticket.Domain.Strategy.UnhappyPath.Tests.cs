using System;
using NUnit.Framework;
using TicketManagementSystem.Domain.TicketAggregate;

namespace TicketManagementSystem.Test
{
    public class UnhappyPathStrategyTicketDomainTests
    {
        private NullUserRepositoryMock _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new NullUserRepositoryMock();
        }

        [Test]
        public void LowPriorityRaisedToMediumTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(null, factory.AccountManager);
        }

        [Test]
        public void MediumPriorityRaisedToHighTest()
        {
            var title = "System Failure";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(null, factory.AccountManager);
        }

        [Test]
        public void HighPriorityTest()
        {
            var title = "System Failure";
            var priority = Priority.High;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(null, factory.AccountManager);
        }

        [Test]
        public void LowPriorityWasNotPayTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(0, factory.Price);
        }

        [Test]
        public void MediumPriorityWasNotPayTest()
        {
            var title = "System Failure";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(0, factory.Price);
        }

        [Test]
        public void HighPriorityWasNotPayTest()
        {
            var title = "System Failure";
            var priority = Priority.High;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            StrategyPriorityManager StrategyPriorityManager = new StrategyPriorityManager(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
            PriorityManagerFactory factory = StrategyPriorityManager.GetStrategyPriorityManager(priority);

            Assert.AreEqual(0, factory.Price);
        }
    }
}
