using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkBase.Library.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string JobPosting { get; set; }
        public DateTime DateApplied { get; set; }
        public string ApplicationStatus { get; set; }
        public string Notes { get; set; }


        public Application()
        {
            Id = 0;
            Company = string.Empty;
            JobTitle = string.Empty;
            JobPosting = string.Empty;
            DateApplied = DateTime.Now;
            ApplicationStatus = string.Empty;
            Notes = string.Empty;
        }

        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tEmployerName: {1,-20}\tJobTitle: {2,-20}\tApplicationStatus: {4,-5}", Id, Company, JobTitle, ApplicationStatus);
        }
    }
}
