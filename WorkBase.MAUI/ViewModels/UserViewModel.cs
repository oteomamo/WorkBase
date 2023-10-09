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
    class UserViewModel : INotifyPropertyChanged
    {
        public UserDTO Model { get; set; }

        public string RetypedPassword { get; set; }

        public bool PasswordsMatch
        {
            get
            {
                return Model.Password == RetypedPassword;
            }
        }

        public ObservableCollection<ApplicationViewModel> Applications
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ApplicationViewModel>();
                }
                return new ObservableCollection<ApplicationViewModel>(ApplicationService
                    .Current.Applications.Where(p => p.UserId == Model.Id)
                    .Select(r => new ApplicationViewModel(r)));
            }
        }

        public UserViewModel(UserDTO user)
        {
            Model = user;
            SetupCommands();
        }

        public UserViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Model = UserService.Current.Get(clientId);
            }
            else
            {
                Model = new UserDTO();
            }
            SetupCommands();
        }

        public UserViewModel()
        {
            Model = new UserDTO();
            SetupCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as UserViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as UserViewModel).Model.Id));
            UpdateCommand = new Command(
                (c) =>
                {
                    var userVM = c as UserViewModel;
                    if (userVM?.Model != null)
                    {
                        ExecuteUpdate(userVM.Model.Id);
                    }
                });

            AddCommand = new Command(
                (c) => ExecuteAdd((c as UserViewModel).Model.Id));
            AddApplicationCommand = new Command(ExecuteAddApplication);
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddApplicationCommand { get; private set; }

        private void ExecuteAddApplication()
        {
            Shell.Current.GoToAsync($"//ApplicationDetail?userId={Model.Id}");
        }

        public void ExecuteDelete(int id)
        {
            UserService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//UserDetail?userId={id}");
        }

        public void ExecuteUpdate(int id)
        {
            Shell.Current.GoToAsync($"//UserSettingsView?userId={id}");
        }

        public void ExecuteAdd(int id)
        {
            Shell.Current.GoToAsync($"//UserDetail?userId={id}");
        }


        public void AddOrUpdate()
        {
            if (!PasswordsMatch)
            {
                throw new InvalidOperationException("Passwords do not match."); 
                
            }UserService.Current.AddOrUpdate(Model);
        }

        public void Update()
        {
            UserService.Current.Update(Model);
        }

        public void RefreshApplications()
        {
            NotifyPropertyChanged(nameof(Applications));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}