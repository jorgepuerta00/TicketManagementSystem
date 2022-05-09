using System;
using NUnit.Framework;
using TicketManagementSystem.Domain.TicketAggregate;

namespace TicketManagementSystem.Test
{
    public class HappyPathTicketDomainTests
    {
        private UserRepositoryMock _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepositoryMock();
        }

        [Test]
        public void LowPriorityTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.Medium, factory.Priority);
        }

        [Test]
        public void LowPriorityRaisedToMediumTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.Medium, factory.Priority);
        }

        [Test]
        public void LowPriorityRaisedDueDateTimeTest()
        {
            var title = "System";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow.AddDays(-3);
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.Medium, factory.Priority);
        }

        [Test]
        public void LowPriorityNotRaisedTest()
        {
            var title = "System";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.Low, factory.Priority);
        }

        [Test]
        public void MediumPriorityRaisedToHighTest()
        {
            var title = "System Failure";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.High, factory.Priority);
        }

        [Test]
        public void MediumPriorityRaisedDueDateTimeTest()
        {
            var title = "System";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow.AddDays(-3);
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.High, factory.Priority);
        }

        [Test]
        public void MediumPriorityNotRaisedTest()
        {
            var title = "System";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.Medium, factory.Priority);
        }

        [Test]
        public void HighPriorityTest()
        {
            var title = "System Failure";
            var priority = Priority.High;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.High, factory.Priority);
        }

        [Test]
        public void HighPriorityNotRaisedTest()
        {
            var title = "System";
            var priority = Priority.High;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(Priority.High, factory.Priority);
        }

        [Test]
        public void LowPriorityWasPayTest()
        {
            var title = "System Crash";
            var priority = Priority.Low;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(50, factory.Price);
        }

        [Test]
        public void MediumPriorityWasPayTest()
        {
            var title = "System Failure";
            var priority = Priority.Medium;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(100, factory.Price);
        }

        [Test]
        public void HighPriorityWasPayTest()
        {
            var title = "System Failure";
            var priority = Priority.High;
            var assignedTo = "Johan";
            var createdTime = DateTime.UtcNow;
            var isPayingCustomer = true;

            PriorityManagerFactory factory = null;

            switch (priority)
            {
                case Priority.Low:
                    factory = new LowPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.Medium:
                    factory = new MediumPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;

                case Priority.High:
                    factory = new HighPriority(title, assignedTo, isPayingCustomer, createdTime, _userRepository);
                    break;
            };

            factory.RaisedPriority();
            factory.CalculatePrice();
            factory.NotifyAdministrator();

            Assert.AreEqual(100, factory.Price);
        }
    }
}
