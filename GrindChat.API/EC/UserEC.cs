using WorkBase.API.Database;
using WorkBase.Library.DTO;
using WorkBase.Library.Models;

namespace WorkBase.API.EC
{
    public class UserEC
        {
            public UserDTO? Get(int id)
            {
                var user = Filebase.Current.Users.FirstOrDefault(u => u.Id == id);
                return user != null ? new UserDTO(user) : null;
            }

            public User AddOrUpdate(User user)
            {
                return Filebase.Current.AddOrUpdate(user);
            }

            public UserDTO? Delete(int id)
            {
                var userToDelete = Filebase.Current.Users.FirstOrDefault(c => c.Id == id);
                if (userToDelete != null)
                {
                    Filebase.Current.Users.Remove(userToDelete);
                    Filebase.Current.DeleteUser(id.ToString());
                }
                return userToDelete != null ? new UserDTO(userToDelete) : null;
            }
            public User? Authenticate(string email, string password)
            {
                return Filebase.Current.Users.FirstOrDefault(u => u.EmailAddress == email && u.Password == password);
            }

        public IEnumerable<UserDTO> Search(string query = "")
            {
                return Filebase.Current.Users
                    .Where(c => c.Name.ToUpper()
                        .Contains(query.ToUpper()))
                    .Take(1000)
                    .Select(c => new UserDTO(c));
            }
        }
    }