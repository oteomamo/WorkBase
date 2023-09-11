using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;

namespace WorkBase.Library.Services
{
    public class UserServices
    {
        private static UserServices? instance;

        public static UserServices Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserServices();
                }
                return instance;
            }
        }

        private List<User> users;

        public List<User> Users
        {
            get
            {
                return users;
            }
        }

        private UserServices()
        {
            users = new List<User>
            {
                   new User { Id = 1, Name = "John Doe", EmailAddress = "jd@gmail.com", ActiveApplication = 1, TotalApplications = 2, Password = "1234" },
                   new User { Id = 1, Name = "Bob Smith", EmailAddress = "bs@gmail.com", ActiveApplication = 1, TotalApplications = 2, Password = "1234" },
                   new User { Id = 1, Name = "Ana Smith", EmailAddress = "as@gmail.com", ActiveApplication = 1, TotalApplications = 2, Password = "1234" }
            };
        }

        public User? GetUser(string emailAddress, string password)
        {
            User? user = null;

            foreach (User u in users)
            {
                if (u.EmailAddress == emailAddress && u.Password == password)
                {
                    user = u;
                    break;
                }
            }

            return user;
        }

    }
}
