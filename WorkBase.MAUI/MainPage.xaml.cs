using WorkBase.Library.Services;

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

                    await Shell.Current.GoToAsync("//UserDetail");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid email or password!", "OK");
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
            Shell.Current.GoToAsync("//UserDetail");
        }



    }
}