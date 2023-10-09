using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.DTO;
using WorkBase.Library.Services;

namespace WorkBase.Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int TotalApplications
        {
            get
            {
                return ApplicationService.Current.GetApplicationsByUserId(this.Id).Count;
            }
        }

        public bool ActiveApplication { get; set; }
        public int TotalActiveApplications
        {
            get
            {
                return ApplicationService.Current.GetPendingApplicationsByUserId(this.Id).Count;
            }
        }

        public List<Application>? Applications { get; set; }


        public User()
        {
            Id = 0;
            Name = string.Empty;
            EmailAddress = string.Empty;
            Password = string.Empty;
            ActiveApplication = false;
            Applications = new List<Application>();

        }

        public User(UserDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.EmailAddress = dto.EmailAddress;
            this.Password = dto.Password;
            this.ActiveApplication = dto.ActiveApplication;
            this.Applications = dto.Applications;

        }
    }
}
