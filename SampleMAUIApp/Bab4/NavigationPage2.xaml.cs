namespace SampleMAUIApp.Bab4;

public partial class NavigationPage2 : ContentPage
{
    public NavigationPage2(string param)
    {
        InitializeComponent();
        lblParam.Text = "Nama anda : " + param;
        btnBack.Clicked += async (sender, e) =>
        {
            await Navigation.PopAsync(true);
        };


    }
}