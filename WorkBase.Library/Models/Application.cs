using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public Application()
    {
        ID = 0;
        EmployerName = string.Empty;
        JobTitle = string.Empty;
        DateApplied = DateTime.Now;
        ApplicationStatus = string.Empty;
        JobDescription = string.Empty;
    }
}
