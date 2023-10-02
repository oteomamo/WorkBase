using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkBase.Library.DTO;
using WorkBase.Library.Models;
using WorkBase.Library.Services;

namespace WorkBase.MAUI.ViewModels
{
    class ApplicationViewViewModel : INotifyPropertyChanged
    {
        public UserDTO User { get; set; }
        public ApplicationDTO SelectedApplication { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Applications));
        }

        public ObservableCollection<ApplicationViewModel> Applications
        {
            get
            {
                return
                    new ObservableCollection<ApplicationViewModel>
                    (ApplicationService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new ApplicationViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ApplicationViewViewModel(int userId)
        {
            if (userId > 0)
            {
                User = UserService.Current.Get(userId);
            }
            else
            {
                User = new UserDTO();
            }

        }

        public void Delete()
        {
            if (SelectedApplication != null)
            {
                ApplicationService.Current.Delete(SelectedApplication.Id);
                SelectedApplication = null;
                NotifyPropertyChanged(nameof(Applications));
                NotifyPropertyChanged(nameof(SelectedApplication));
            }
        }

        public void RefreshApplicationList()
        {
            NotifyPropertyChanged(nameof(Applications));
        }
    }
}