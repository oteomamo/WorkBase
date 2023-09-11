using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBase.Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int TotalApplications { get; set; }
        public int ActiveApplication { get; set; }

        public List<Application>? Applications { get; set; }


        public User()
        {
            Id = 0;
            Name = string.Empty;
            EmailAddress = string.Empty;
            Password = string.Empty;
            TotalApplications = 0;
            ActiveApplication = 0;
            Applications = new List<Application>();
        }



    }
}
