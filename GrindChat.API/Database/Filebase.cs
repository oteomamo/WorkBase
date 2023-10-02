using Newtonsoft.Json;
using WorkBase.Library.Models;
using System.Diagnostics;
using WorkBase.API.EC;
using WorkBase.Library.DTO;

namespace WorkBase.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _userRoot;
        private string _applicationRoot;
        private static Filebase? _instance;

        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        public Filebase()
        {
            _root = @"C:\temp\WorkBase";
            _userRoot = $"{_root}\\Users";
            _applicationRoot = $"{_root}\\Applications";
        }
        private int LastUserId => Users.Any() ? Users.Select(u => u.Id).Max() : 0;
        private int LastApplicationId => Applications.Any() ? Applications.Select(t => t.Id).Max() : 0;


        /*    ++++++++++++++    User Section     +++++++++++++    */

        public User AddOrUpdate(User u)
        {
            if (u.Id <= 0)
            {
                u.Id = LastUserId + 1;
            }
            var path = $"{_userRoot}\\{u.Id}.json";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                var directoryPath = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directoryPath);

                File.WriteAllText(path, JsonConvert.SerializeObject(u));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error updating client: {e.Message}");
            }

            return u;
        }

        public List<User> Users
        {
            get
            {
                var _users = new List<User>();
                if (Directory.Exists(_userRoot))
                {
                    var root = new DirectoryInfo(_userRoot);
                    foreach (var todoFile in root.GetFiles())
                    {
                        var todo = JsonConvert.DeserializeObject<User>(File.ReadAllText(todoFile.FullName));
                        if (todo != null)
                        {
                            _users.Add(todo);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine($"Directory {_userRoot} does not exist.");
                }

                return _users;
            }
        }


        public bool DeleteUser(string id)
        {
            var path = $"{_userRoot}\\{id}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return true;
        }




        /*    ++++++++++++++    Application Section     +++++++++++++    */

        public Application AddOrUpdate(Application t)
        {
            if (t.Id <= 0)
            {
                t.Id = LastApplicationId + 1;
            }
            var path = $"{_applicationRoot}\\{t.Id}.json";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                var directoryPath = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directoryPath);

                File.WriteAllText(path, JsonConvert.SerializeObject(t));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error updating client: {e.Message}");
            }

            return t;
        }

        public List<Application> Applications
        {
            get
            {
                var _applications = new List<Application>();
                if (Directory.Exists(_applicationRoot))
                {
                    var root = new DirectoryInfo(_applicationRoot);
                    foreach (var todoFile in root.GetFiles())
                    {
                        var todo = JsonConvert.DeserializeObject<Application>(File.ReadAllText(todoFile.FullName));
                        if (todo != null)
                        {
                            _applications.Add(todo);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine($"Directory {_applicationRoot} does not exist.");
                }

                return _applications;
            }
        }


        public bool DeleteApplication(string id)
        {
            var path = $"{_applicationRoot}\\{id}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return true;
        }

    }
}
