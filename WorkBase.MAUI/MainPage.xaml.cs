using WorkBase.Library.Services;
using WorkBase.MAUI.ViewModels;
using WorkBase.MAUI.Views;

namespace WorkBase.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SigninBtnClicked(object sender, EventArgs e)
        {
            try
            {
                string email = UsernameEntry.Text;
                string password = PasswordEntry.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Please enter both email and password.", "OK");
                    return;
                }


                var user = UserService.Current.Authenticate(email, password);

                if (user != null)
                {
                    var userViewPage = new UserDetailView();
                    userViewPage.BindingContext = new UserViewModel(user);
                    await Shell.Current.Navigation.PushAsync(userViewPage);

                }
                else
                {
                    await DisplayAlert("Error", "Invalid email or password!", "OK");
                }

                //(BindingContext as UserViewViewModel).RefreshClientList();
                if (BindingContext is UserViewViewModel viewModel)
                {
                    viewModel.RefreshClientList();
                }
            }
            catch (Exception ex)
            {
                // Log or display the error for debugging
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void SignupBtnClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//UserSignUpView");
        }



    }
}