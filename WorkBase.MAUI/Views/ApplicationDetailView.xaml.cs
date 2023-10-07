using WorkBase.MAUI.ViewModels;

namespace WorkBase.MAUI.Views;


[QueryProperty(nameof(UserId), "userId")]

[QueryProperty(nameof(ApplicationId), "applicationId")]
public partial class ApplicationDetailView : ContentPage
{
    public int UserId { get; set; }

    public int ApplicationId { get; set; }
    public ApplicationDetailView()
	{
		InitializeComponent();
	}


    /*    private void OnArrived(object sender, NavigatedToEventArgs e)
        {
            BindingContext = new ApplicationViewModel(UserId, ApplicationId);
    *//*        var viewModel = BindingContext as ApplicationViewModel;
            viewModel.Model.UserId = UserId;
            viewModel.Model.Id = ApplicationId; // Ensure the Id is set*//*
            (BindingContext as ApplicationViewModel).RefreshApplications();
        }*/

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ApplicationViewModel(UserId, ApplicationId);
        var viewModel = BindingContext as ApplicationViewModel;
        if (viewModel != null)
        {
            viewModel.Model.UserId = UserId;
            viewModel.Model.Id = ApplicationId; // Ensure the Id is set
            viewModel.RefreshApplications();
        }
    }


    /*    private void OkClicked(object sender, EventArgs e)
        {
            //(BindingContext as ApplicationViewModel).AddOrUpdate();

            Shell.Current.GoToAsync("//UserDetail");
        }*/

    private void OkClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as ApplicationViewModel;
        if (viewModel != null)
        {
            viewModel.AddOrUpdate();
            Shell.Current.GoToAsync($"//UserDetail?userId={UserId}");
        }
    }

}