namespace TicketManagementSystem.Domain.UserAggregate
{
    public interface IUserRepository
    {
        User GetUser(string username);
        User GetAccountManager();
    }
}
