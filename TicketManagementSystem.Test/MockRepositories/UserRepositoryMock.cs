using System;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Test
{
    public class UserRepositoryMock : IUserRepository
    {
        public User GetUser(string username)
        {
            User u = new User();
            u.Username = "jorge.puerta";
            u.FirstName = "Jorge";
            u.LastName = "Puerta";
            return u;
        }

        public User GetAccountManager()
        {
            return GetUser("Jorge");
        }
    }
}
