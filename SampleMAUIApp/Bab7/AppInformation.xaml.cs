namespace SampleMAUIApp.Bab7;

public partial class AppInformation : ContentPage
{
    public AppInformation()
    {
        InitializeComponent();
    }

    private async void btnAppName_Clicked(object sender, EventArgs e)
    {
        var appName = AppInfo.Name;
        await DisplayAlert("Keterangan", $"Nama Aplikasi: {appName}", "OK");
    }

    private async void btnPackageName_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Keterangan", $"Nama Package: {AppInfo.PackageName}", "OK");
    }

    private async void btnVersion_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Keterangan", $"Nama Versi: {AppInfo.VersionString}", "OK");
    }

    private async void btnBuildNum_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Keterangan", $"Build Number: {AppInfo.BuildString}", "OK");
    }

}