using System;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Test
{
    public class NullUserRepositoryMock : IUserRepository
    {
        public User GetUser(string username)
        {
            return null;
        }

        public User GetAccountManager()
        {
            return GetUser("Jorge");
        }
    }
}
