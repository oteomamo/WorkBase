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
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateApplied { get; set; }
        public string ApplicationStatus { get; set; }
        public string JobDescription { get; set; }


        public Application()
        {
            Id = 0;
            EmployerName = string.Empty;
            JobTitle = string.Empty;
            DateApplied = DateTime.Now;
            ApplicationStatus = string.Empty;
            JobDescription = string.Empty;
        }

        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tEmployerName: {1,-20}\tJobTitle: {2,-20}\tDateApplied: {3,-10:MM/dd/yyyy}\tApplicationStatus: {4,-5}\tJobDescription: {5,-30}", Id, EmployerName, JobTitle, DateApplied, ApplicationStatus, JobDescription);
        }
    }
}
