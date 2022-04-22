using System;
using NUnit.Framework;
using TicketManagementSystem.Domain.TicketAggregate;

namespace TicketManagementSystem.Test
{
    public class UnhappyPathTicketDomainTests
    {
        private NullUserRepositoryMock _nullUserRepository;

        [SetUp]
        public void Setup()
        {
            _nullUserRepository = new NullUserRepositoryMock();
        }

        [Test]
        public void LowPriorityRaisedToMediumTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

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

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

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

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

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

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

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

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

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

            PriorityManagerFactory factory = priority switch
            {
                Priority.Low => new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.Medium => new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                Priority.High => new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _nullUserRepository),
                _ => throw new NotImplementedException(),
            };
            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(0, factory.Price);
        }
    }
}
