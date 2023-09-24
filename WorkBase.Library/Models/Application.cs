﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkBase.Library.DTO;

namespace WorkBase.Library.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Closed
    }
    public class Application
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string JobPosting { get; set; }
        public DateTime DateApplied { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Notes { get; set; }


        public Application()
        {
            Id = 0;
            Company = string.Empty;
            JobTitle = string.Empty;
            JobPosting = string.Empty;
            DateApplied = DateTime.Now;
            Status = ApplicationStatus.Pending;
            Notes = string.Empty;
        }

        public Application(ApplicationDTO dto)
        {
            this.Id = dto.Id;
            this.Company = dto.Company;
            this.JobTitle = dto.JobTitle;
            this.JobPosting = dto.JobPosting;
            this.DateApplied = dto.DateApplied;
            this.Status = (ApplicationStatus)dto.Status;
            this.Notes = dto.Notes;
        }

        public override string ToString()
        {
            return string.Format(" Id: {0,-3}\tEmployerName: {1,-20}\tJobTitle: {2,-20}\tApplicationStatus: {4,-5}", Id, Company, JobTitle, Status);
        }
    }
}
