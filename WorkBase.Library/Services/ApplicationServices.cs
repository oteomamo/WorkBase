using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;

namespace WorkBase.Library.Services
{
    public class ApplicationServices
    {
        private static ApplicationServices? instance;

        public static ApplicationServices Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationServices();
                }
                return instance;
            }
        }

        private List<Application> applications;

        public List<Application> Applications
        {
            get
            {
                return applications;
            }
        }

        public ApplicationServices()
        {
            applications = new List<Application>
            {
                new Application { Id = 1, EmployerName = "Google", JobTitle = "Software Engineer", DateApplied = DateTime.Now, ApplicationStatus = "Applied", JobDescription = "Software Engineer" },
            };
        }
    }

    
}
