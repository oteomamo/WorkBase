using WorkBase.MAUI.ViewModels;

namespace WorkBase.MAUI.Views;
[QueryProperty(nameof(UserId), "userId")]
public partial class UserDetailView : ContentPage
{
    public int UserId { get; set; }
    public UserDetailView()
	{
		InitializeComponent();
	}

    private async void createAccountButtonClicked(object sender, EventArgs e)
    {
        if (!(BindingContext as UserViewModel).PasswordsMatch)
        {
            await DisplayAlert("Error", "Passwords do not match!", "OK");
            return;
        }

        (BindingContext as UserViewModel).AddOrUpdate();
        await Shell.Current.GoToAsync("//MainPage");
    }
    private void cancleButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UserViewModel(UserId);

        (BindingContext as UserViewModel).RefreshApplications();

        retypePasswordEntry.SetBinding(Entry.TextProperty, new Binding("RetypedPassword"));

    }


}