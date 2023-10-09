using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkBase.Library.DTO;
using WorkBase.Library.Utilities;

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

        public List<UserDTO> Users => users ?? FetchAllUsers();

        private List<UserDTO> FetchAllUsers()
        {
            var response = new WebRequestHandler().Get("/User").Result;
            return JsonConvert.DeserializeObject<List<UserDTO>>(response) ?? new List<UserDTO>();
        }

        public UserDTO? Authenticate(string email, string password)
        {
            var credentials = new
            {
                EmailAddress = email,
                Password = password
            };

            var response = new WebRequestHandler().Post("/User/Authenticate", credentials).Result;

            // Check if the response is valid JSON
            if (!string.IsNullOrWhiteSpace(response) && IsValidJson(response))
            {
                return JsonConvert.DeserializeObject<UserDTO>(response);
            }

            // Handle invalid or unexpected response
            return null;
        }

        private bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }
            return false;
        }

        public IEnumerable<UserDTO> Search(string query)
        {
            return Users.Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
        }

        private UserService()
        {
            users = FetchAllUsers();
        }

        public UserDTO? Get(int id)
        {
            return Users.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/User/Delete/{id}").Result;
            if (response == "SUCCESS")
            {
                users.Remove(users.FirstOrDefault(c => c.Id == id));
            }
        }

        public void AddOrUpdate(UserDTO c)
        {
            try
            {
                var response = new WebRequestHandler().Post("/User", c).Result;
                var updatedUser = JsonConvert.DeserializeObject<UserDTO>(response);
                if (updatedUser != null)
                {
                    var existingUser = users.FirstOrDefault(user => user.Id == updatedUser.Id);
                    if (existingUser == null)
                    {
                        users.Add(updatedUser);
                    }
                    else
                    {
                        var index = users.IndexOf(existingUser);
                        users[index] = updatedUser;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, maybe log it or display an alert.
            }
        }

        public void Update(UserDTO c)
        {
            var response = new WebRequestHandler().Post("/User", c).Result;
            var updatedUser = JsonConvert.DeserializeObject<UserDTO>(response);
            if (updatedUser != null)
            {
                var existingUser = users.FirstOrDefault(user => user.Id == updatedUser.Id);
                if (existingUser != null)
                {
                    var index = users.IndexOf(existingUser);
                    users[index] = updatedUser;
                }
            }
        }

    }
}
