namespace SampleMAUIApp.Bab7;

public partial class SampleMap : ContentPage
{
    public SampleMap()
    {
        InitializeComponent();
    }

    public async Task NavigateToBuilding25()
    {
        var location = new Location(47.645160, -122.1306032);
        var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

        await Map.OpenAsync(location, options);
    }

    private async void btnMap_Clicked(object sender, EventArgs e)
    {
        await NavigateToBuilding25();
    }


    private async void btnPlacemark_Clicked(object sender, EventArgs e)
    {
        var placemark = new Placemark
        {
            CountryName = "United States",
            AdminArea = "WA",
            Thoroughfare = "Microsoft Building 25",
            Locality = "Redmond"
        };
        var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

        await Map.OpenAsync(placemark, options);
    }

}