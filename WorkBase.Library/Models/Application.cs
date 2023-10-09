using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkBase.Library.DTO;

namespace WorkBase.Library.Models
{

    public class Application
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string JobPosting { get; set; }
        public DateTime DateApplied { get; set; }
        
        public bool ApplicationStatus { get; set; }
        public string Notes { get; set; }

        public int UserId { get; set; }

        public Application()
        {
            Id = 0;
            Company = string.Empty;
            JobTitle = string.Empty;
            JobPosting = string.Empty;
            DateApplied = DateTime.Now;
            ApplicationStatus = true;
            Notes = string.Empty;
            UserId = 0;
        }

        public Application(ApplicationDTO dto)
        {
            this.Id = dto.Id;
            this.Company = dto.Company;
            this.JobTitle = dto.JobTitle;
            this.JobPosting = dto.JobPosting;
            this.DateApplied = dto.DateApplied;
            this.ApplicationStatus = dto.ApplicationStatus;
            this.Notes = dto.Notes;
            this.UserId = dto.UserId;
        }

        public override string ToString()
        {
            return string.Format("Id: {0,-3}\tEmployerName: {1,-40}\tJobTitle: {2,-40}\n\tApplicationStatus: {3,-5}", Id, Company, JobTitle, ApplicationStatus);
        }
    }
}
