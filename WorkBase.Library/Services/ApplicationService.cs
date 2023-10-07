﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBase.Library.DTO;
using WorkBase.Library.Models;
using WorkBase.Library.Utilities;

namespace WorkBase.Library.Services
{
    public class ApplicationService
    {
        private static ApplicationService? instance;

        public static ApplicationService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationService();
                }
                return instance;
            }
        }

        private List<ApplicationDTO> applications;

        public List<ApplicationDTO> Applications
        {
            get
            {
                return applications ?? new List<ApplicationDTO>();
            }
        }

        public IEnumerable<ApplicationDTO> Search(string query)
        {
            return Applications
                .Where(c => c.Company.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private ApplicationService()
        {
            var response = new WebRequestHandler()
                     .Get("/Application").Result;
            applications = JsonConvert
                   .DeserializeObject<List<ApplicationDTO>>(response) ?? new List<ApplicationDTO>();
        }

        public ApplicationDTO? Get(int id)
        {
            return Applications.FirstOrDefault(c => c.Id == id);
        }
        public ApplicationDTO? GetUpdate(int id)
        {
            return Applications.FirstOrDefault(p => p.UserId == id);
        }


        public void Delete(int id)
        {
            var response = new WebRequestHandler()
                .Delete($"/Application/Delete/{id}").Result;

            if (response == "SUCCESS")
            {
                var clientToDelete = applications.FirstOrDefault(c => c.Id == id);
                if (clientToDelete != null)
                {
                    applications.Remove(clientToDelete);
                }
            }
        }

        /*        public void AddOrUpdate(ApplicationDTO c)
                {
                    var response = new WebRequestHandler()
                        .Post("/Application", c).Result;
                    var myUpdatedApplications = JsonConvert.DeserializeObject<ApplicationDTO>(response);
                    if (myUpdatedApplications != null)
                    {
                        var existingApplication = applications.FirstOrDefault(c => c.Id == myUpdatedApplications.Id);
                        if (existingApplication == null)
                        {
                            applications.Add(myUpdatedApplications);
                        }
                        else
                        {
                            var index = applications.IndexOf(existingApplication);
                            applications.RemoveAt(index);
                            applications.Insert(index, myUpdatedApplications);
                        }
                    }
                }*/

        public void AddOrUpdate(ApplicationDTO c)
        {
            if (c.Id > 0)
            {
                // Update existing application logic
                Update(c);
            }
            else
            {
                // Add new application logic
                Add(c);
            }
        }


        private void Update(ApplicationDTO c)
        {
            // Assuming you have a Put method in WebRequestHandler
            var response = new WebRequestHandler().Put($"/Application/{c.Id}", c).Result;
            try
            {
                var updatedApplication = JsonConvert.DeserializeObject<ApplicationDTO>(response);
                if (updatedApplication != null)
                {
                    var existingApplication = applications.FirstOrDefault(app => app.Id == updatedApplication.Id);
                    if (existingApplication != null)
                    {
                        var index = applications.IndexOf(existingApplication);
                        applications.RemoveAt(index);
                        applications.Insert(index, updatedApplication);
                    }
                }
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Failed to deserialize response: " + ex.Message);
            }


        }

        private void Add(ApplicationDTO c)
        {
            var response = new WebRequestHandler().Post("/Application", c).Result;
            var newApplication = JsonConvert.DeserializeObject<ApplicationDTO>(response);
            if (newApplication != null)
            {
                applications.Add(newApplication);
            }
        }


    }
}