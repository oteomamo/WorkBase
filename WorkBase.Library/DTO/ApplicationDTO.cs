using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;

namespace WorkBase.Library.DTO
{

    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string JobPosting { get; set; }
        public DateTime DateApplied { get; set; }
        public bool ApplicationStatus { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }

        public ApplicationDTO() 
        { 
            Id = 0;
            Company = string.Empty;
            JobTitle = string.Empty;
            JobPosting = string.Empty;
            DateApplied = DateTime.Now;
            ApplicationStatus = true;
            UserId = 0;
            Notes = string.Empty;
        }

        public ApplicationDTO(Application application)
        {
            this.Id = application.Id;
            Company = application.Company;
            JobTitle = application.JobTitle;
            JobPosting = application.JobPosting;
            DateApplied = application.DateApplied;
            this.ApplicationStatus = application.ApplicationStatus;
            this.UserId = application.UserId;
            Notes = application.Notes;
        }


        public override string ToString()
        {
            return string.Format("Id: {0,-3}\tEmployerName: {1,-40}\tJobTitle: {2,-40}\n\tApplicationStatus: {3,-5}", Id, Company, JobTitle, ApplicationStatus);
        }

    }
}
