using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.Service
{
    public class UserService : IUserService
    {

        private List<User> users = new List<User>()
        {
            new(){Id=1, Email="turkay.urkmez@dinamikzihin.com", Name="Türkay", UserName="turkay", Password="123", Role="Admin" },
            new(){Id=2, Email="caglar.kanber@turkcell.com.tr", Name="Çağlar", UserName="caglar", Password="123", Role="Editor" },
            new(){Id=3, Email="fusun.diker@turkcell.com.tr", Name="Füsun", UserName="fusun", Password="123", Role="Client" },

        };

        public User? ValidateUser(string userName, string password)
        {
            return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
