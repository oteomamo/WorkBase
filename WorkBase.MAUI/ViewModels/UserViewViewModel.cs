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
using WorkBase.Library.Services;

namespace WorkBase.MAUI.ViewModels
{
    class UserViewViewModel : INotifyPropertyChanged
    {

        public UserDTO SelectedUser { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {

            NotifyPropertyChanged(nameof(Users));
        }
        public UserViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public ObservableCollection<UserViewModel> Users
        {
            get
            {
                return
                    new ObservableCollection<UserViewModel>
                    (UserService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new UserViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedUser != null)
            {
                UserService.Current.Delete(SelectedUser.Id);
                SelectedUser = null;
                NotifyPropertyChanged(nameof(Users));
                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }


        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Users));
        }
    }
}