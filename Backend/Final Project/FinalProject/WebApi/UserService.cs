using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DGDbContext;

namespace WebApi
{
    public class UserService : IUserService
    {
        DgContext _DgContext;
        public UserService(DgContext DgContext)
        {
            _DgContext = DgContext;
        }

        public void AddUser(string name, string surName, string userName, string password)
        {

            User user = new User
            {
                Name = name,
                SurName = surName,
                UserName = userName,
                Password = password,
                Role = "Gust"
            };

            _DgContext.Users.Add(user);
            _DgContext.SaveChanges();
        }

        public User AuthenticateUser(string UserName, string password)
        {
            return _DgContext.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == password);
        }
    }
}
