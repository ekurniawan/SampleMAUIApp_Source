namespace SampleMAUIApp.Bab4;

public partial class NavigationPage1 : ContentPage
{
    public NavigationPage1()
    {
        InitializeComponent();
        btnSecond.Clicked += BtnSecond_Clicked;
    }

    private async void BtnSecond_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage2("Erick Kurniawan"));
    }

}