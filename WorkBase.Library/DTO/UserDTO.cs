using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;
using WorkBase.Library.Services;

namespace WorkBase.Library.DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool ActiveApplication { get; set; }

        public int TotalActiveApplications
        {
            get
            {
                return ApplicationService.Current.GetPendingApplicationsByUserId(this.Id).Count;
            }
        }
        public List<Application>? Applications { get; set; }

        public UserDTO() 
        {
            Id = 0;
            Name = string.Empty;
            EmailAddress = string.Empty;
            Password = string.Empty;
            ActiveApplication = false;
            Applications = new List<Application>();
        }

        public int TotalApplications
        {
            get
            {
                return ApplicationService.Current.GetApplicationsByUserId(this.Id).Count;
            }
        }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            Name = user.Name;
            EmailAddress= user.EmailAddress;
            Password = user.Password;
            ActiveApplication = user.ActiveApplication;
            Applications = new List<Application>();
        }

    }
}
