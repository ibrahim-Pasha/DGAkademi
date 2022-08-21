using System;
using System.Threading.Tasks;

namespace WebApi
{
    public interface IUserService
    {
        User AuthenticateUser(string UserName, string password);
        void AddUser(string name, string surName, string userName, string password);
    }
}
