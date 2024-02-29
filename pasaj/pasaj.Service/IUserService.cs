using pasaj.Entities;

namespace pasaj.Service
{
    public interface IUserService
    {
        User? ValidateUser(string userName, string password);
    }
}