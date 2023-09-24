using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.Models;

namespace WorkBase.Library.DTO
{
    public enum ApplicationStatus
    {
        Pending,
        Closed
    }
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string JobPosting { get; set; }
        public DateTime DateApplied { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Notes { get; set; }

        public ApplicationDTO() 
        { 
            Id = 0;
            Company = string.Empty;
            JobTitle = string.Empty;
            JobPosting = string.Empty;
            DateApplied = DateTime.Now;
            Notes = string.Empty;
            Status = ApplicationStatus.Pending;
        }

        public ApplicationDTO(Application application)
        {
            this.Id = application.Id;
            Company = application.Company;
            JobTitle = application.JobTitle;
            JobPosting = application.JobPosting;
            DateApplied = application.DateApplied;
            Notes = application.Notes;
            Status = (ApplicationStatus)application.Status;
        }


        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tEmployerName: {1,-20}\tJobTitle: {2,-20}\tApplicationStatus: {4,-5}", Id, Company, JobTitle, Status);
        }
    }
}
