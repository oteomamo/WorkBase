using WorkBase.MAUI.ViewModels;

namespace WorkBase.MAUI.Views;



[QueryProperty(nameof(UserId), "clientId")]

[QueryProperty(nameof(ApplicationId), "projectId")]
public partial class ApplicationDetailView : ContentPage
{


    public int UserId { get; set; }

    public int ApplicationId { get; set; }
    public ApplicationDetailView()
	{
		InitializeComponent();
	}


    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ApplicationViewModel(UserId, ApplicationId);
        (BindingContext as ApplicationViewModel).RefreshApplications();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ApplicationViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Users");
    }
}