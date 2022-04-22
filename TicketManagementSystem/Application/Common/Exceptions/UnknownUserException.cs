using System;
namespace TicketManagementSystem.Application.Common.Exceptions
{
    public class UnknownUserException : Exception
    {
        public UnknownUserException(string message) : base(message)
        {
        }
    }
}
