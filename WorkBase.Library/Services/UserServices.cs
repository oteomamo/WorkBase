
using WorkBase.Library.DTO;
using WorkBase.Library.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WorkBase.Library.Services
{
    public class UserService
    {
        private static UserService? instance;

        public static UserService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }

        private List<UserDTO> users;

        public List<UserDTO> Users
        {
            get
            {
                return users ?? new List<UserDTO>();
            }
        }

        public IEnumerable<UserDTO> Search(string query)
        {
            return Users
                .Where(c => c.Username.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private UserService()
        {
            var response = new WebRequestHandler()
                     .Get("/User").Result;
            users = JsonConvert
                   .DeserializeObject<List<UserDTO>>(response) ?? new List<UserDTO>();
        }

        public UserDTO? Get(int id)
        {
            return Users.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler()
                .Delete($"/User/Delete/{id}").Result;

            if (response == "SUCCESS")
            {
                var clientToDelete = users.FirstOrDefault(c => c.Id == id);
                if (clientToDelete != null)
                {
                    users.Remove(clientToDelete);
                }
            }
        }

        public void AddOrUpdate(UserDTO c)
        {
            var response = new WebRequestHandler().Post("/User", c).Result;
            var myUpdatedUsers = JsonConvert.DeserializeObject<UserDTO>(response);
            if (myUpdatedUsers != null)
            {
                var existingUser = users.FirstOrDefault(c => c.Id == myUpdatedUsers.Id);
                if (existingUser == null)
                {
                    users.Add(myUpdatedUsers);
                }
                else
                {
                    var index = users.IndexOf(existingUser);
                    users.RemoveAt(index);
                    users.Insert(index, myUpdatedUsers);
                }
            }
        }
    }
}
