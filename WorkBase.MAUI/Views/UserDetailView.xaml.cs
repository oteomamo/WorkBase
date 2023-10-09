using WorkBase.Library.Services;
using WorkBase.MAUI.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WorkBase.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class UserDetailView : ContentPage
{
    //public int UserId { get; set; }


    public UserDetailView()
	{
		InitializeComponent();
        this.SizeChanged += OnPageSizeChanged;
    }

    private void OnPageSizeChanged(object sender, EventArgs e)
    {
        ApplicationsListView.HeightRequest = this.Height * 0.7;
    }

    private void SettingsClicked(object sender, EventArgs e)
    {
        BindingContext = new UserViewModel(UserId);
    }




    private void OpenClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ApplicationDetail");
    }
    private async void ExitClicked(object sender, EventArgs e)
    {
        try
        {
            if (BindingContext is UserViewModel viewModel)
            {
                viewModel.Update();
                await Shell.Current.GoToAsync("//MainPage");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }




    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ApplicationViewViewModel).RefreshApplicationList();
    }
    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UserViewModel(UserId);

        (BindingContext as UserViewModel).RefreshApplications();
    }

    private void AddApplicationClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ApplicationDetail?userId={UserId}");
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as UserViewModel;
        viewModel?.RefreshApplications();
    }

    private int userId;
    public int UserId
    {
        get { return userId; }
        set
        {
            userId = value;
            OnUserIdChanged();  
        }
    }

    private void OnUserIdChanged()
    {
        
        try
        {
            BindingContext = new UserViewModel(UserId);
        Console.WriteLine($"Fetched User Name: {(BindingContext as UserViewModel)?.Model?.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching user data: {ex.Message}");
        }
    }



    private void OpenApplicationClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is ApplicationViewModel appViewModel)
        {
            var applicationId = appViewModel.Model.Id;
            var userId = appViewModel.Model.UserId;

            Shell.Current.GoToAsync($"//ApplicationDetail?userId={userId}&applicationId={applicationId}");
        }
    }
    private void DeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var application = button?.BindingContext as ApplicationViewModel;
        if (application != null)
        {
            ApplicationService.Current.Delete(application.Model.Id);
            var viewModel = BindingContext as UserViewModel;
            viewModel?.RefreshApplications();
        }
    }


}