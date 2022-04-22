using System;
using TicketManagementSystem.Application.Common.Exceptions;
using TicketManagementSystem.Domain.UserAggregate;

namespace TicketManagementSystem.Application.Common.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static void ThrowIfArgumentIsNull<T>(this T value, string argument) where T : class
        {
            if (value == null)
            {
                if (value.GetType() == typeof(User))
                {
                    throw new UnknownUserException(argument);
                };
                throw new ApplicationException(argument);
            }
        }

        public static void ThrowIfArgumentIsEmptyOrNull(this string value, string argument)
        {
            if (value == null || value == string.Empty)
            {
                throw new InvalidTicketException(argument);
            }
        }
    }
}
