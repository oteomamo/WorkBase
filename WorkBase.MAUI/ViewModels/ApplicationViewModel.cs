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
    class ApplicationViewModel : INotifyPropertyChanged
    {
        public ApplicationDTO Model { get; set; }

        private ObservableCollection<ApplicationViewModel> _applications;
        public ObservableCollection<ApplicationViewModel> Applications
        {
            get { return _applications; }
            set
            {
                if (_applications != value)
                {
                    _applications = value;
                    NotifyPropertyChanged();
                }
            }
        }




        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void ExecuteDelete()
        {
            ApplicationService.Current.Delete(Model.Id);
        }

        private void ExecuteAdd()
        {
            ApplicationService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//UserDetail?userId={Model.UserId}");
        }

        public void ExecuteEdit(int id)
        {
            ApplicationService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ApplicationDetail?userId={Model.UserId}&projectId={Model.Id}");
        }



        public void RefreshApplications()
        {
            Applications = new ObservableCollection<ApplicationViewModel>(ApplicationService
                .Current.Applications.Where(p => p.UserId == Model.Id)
                .Select(r => new ApplicationViewModel(r)));
        }


        public void SetupCommands()
        {
            /*            DeleteCommand = new Command(
                            (c) => ExecuteDelete((c as ApplicationViewModel).Model.Id));*/
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ApplicationViewModel).Model.Id));
            AddCommand = new Command(ExecuteAdd);
        }

        public void AddOrUpdate()
        {
            ApplicationService.Current.AddOrUpdate(Model);
        }

        public void Update()
        {
            ApplicationService.Current.Update(Model);
        }

        public ApplicationViewModel()
        {
            Model = new ApplicationDTO();
            SetupCommands();
        }
        public ApplicationViewModel(int userId, int applicationId)
        {
            if (applicationId == 0)
            {
                Model = new ApplicationDTO { UserId = userId };
            }
            else
            {
                Model = ApplicationService.Current.Get(applicationId);
            }
            SetupCommands();
        }

        public ApplicationViewModel(ApplicationDTO model)
        {
            Model = model;
            SetupCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
