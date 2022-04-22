using System;
namespace TicketManagementSystem.Application.Common.Exceptions
{
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException(string message) : base(message)
        {
        }
    }
}
