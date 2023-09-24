namespace WorkBase.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SigninBtnClicked(object sender, EventArgs e)
        {
            //string username = UsernameEntry.Text;
            //string password = PasswordEntry.Text;
            Shell.Current.GoToAsync("//User");
        }
        private void SignupBtnClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//UserDetail");
        }



    }
}