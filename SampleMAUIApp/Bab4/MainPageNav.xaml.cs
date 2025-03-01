namespace SampleMAUIApp.Bab4;

public partial class MainPageNav : ContentPage
{
    public MainPageNav()
    {
        InitializeComponent();
    }

    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        string parameter = InputEntry.Text;
        await Shell.Current.GoToAsync($"detailpage?text={parameter}");
    }
}