using WorkBase.API.Database;
using WorkBase.Library.DTO;
using WorkBase.Library.Models;

namespace WorkBase.API.EC
{
    public class ApplicationEC
    {
        public ApplicationDTO? Get(int id)
        {
            var application = Filebase.Current.Applications.FirstOrDefault(u => u.Id == id);
            return application != null ? new ApplicationDTO(application) : null;
        }

        public Application AddOrUpdate(Application application)
        {
            return Filebase.Current.AddOrUpdate(application);
        }

        public ApplicationDTO? Delete(int id)
        {
            var applicationToDelete = Filebase.Current.Applications.FirstOrDefault(c => c.Id == id);
            if (applicationToDelete != null)
            {
                Filebase.Current.Applications.Remove(applicationToDelete);
                Filebase.Current.DeleteApplication(id.ToString());
            }
            return applicationToDelete != null ? new ApplicationDTO(applicationToDelete) : null;
        }

        public IEnumerable<ApplicationDTO> Search(string query = "")
        {
            return Filebase.Current.Applications
                .Where(c => c.Company.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ApplicationDTO(c));
        }
    }
}
