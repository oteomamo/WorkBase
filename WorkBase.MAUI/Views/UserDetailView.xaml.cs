using WorkBase.MAUI.ViewModels;

namespace WorkBase.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class UserDetailView : ContentPage
{
    //public int UserId { get; set; }


    public UserDetailView()
	{
		InitializeComponent();
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
            OnUserIdChanged();  // New method to handle changes
        }
    }

    private void OnUserIdChanged()
    {
        BindingContext = new UserViewModel(UserId);
        (BindingContext as UserViewModel)?.RefreshApplications();
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


}