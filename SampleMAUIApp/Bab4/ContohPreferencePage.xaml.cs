namespace SampleMAUIApp.Bab4;

public partial class ContohPreferencePage : ContentPage
{
    public ContohPreferencePage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        if (Preferences.ContainsKey("bahasa"))
        {
            var bahasa = Preferences.Get("bahasa", String.Empty);
            entryBahasa.Text = bahasa;
            await DisplayAlert("Info", $"Bahasa yang digunakan: {bahasa}", "OK");
        }
        else
        {
            await DisplayAlert("Info", "Object PReferences belum ada", "OK");
        }
    }

    private async void btnSetPReference_Clicked(object sender, EventArgs e)
    {
        if (!Preferences.ContainsKey("bahasa"))
        {
            Preferences.Set("bahasa", entryBahasa.Text);
            await DisplayAlert("Info", "Preferences berhasil dibuat", "OK");
        }
    }

    private async void btnClearPreference_Clicked(object sender, EventArgs e)
    {
        Preferences.Remove("bahasa");
        Preferences.Clear();
        await DisplayAlert("Info", "Semua data preference berhasil dihapus", "OK");
    }

}