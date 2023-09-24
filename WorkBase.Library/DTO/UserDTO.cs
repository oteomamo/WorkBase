using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;

namespace WorkBase.Library.DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int TotalApplications { get; set; }
        public bool ActiveApplication { get; set; }

        public List<Application>? Applications { get; set; }

        public UserDTO() 
        {
            Id = 0;
            Name = string.Empty;
            EmailAddress = string.Empty;
            Password = string.Empty;
            TotalApplications = 0;
            ActiveApplication = false;
            Applications = new List<Application>();
        }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            Name = user.Name;
            EmailAddress= user.EmailAddress;
            Password = user.Password;
            TotalApplications = user.TotalApplications;
            ActiveApplication = user.ActiveApplication;
            Applications = new List<Application>();
        }

    }
}
