namespace SampleMAUIApp.Bab3;

public partial class BindingListString : ContentPage
{
    public BindingListString()
    {
        InitializeComponent();
        List<string> items = new List<string> { "First", "Second", "Third" };
        listView.ItemsSource = items;
        //untuk mengambil nilai item ketika diklik pada baris
        listView.ItemTapped += async (sender, e) =>
        {
            await DisplayAlert("Tapped", e.Item.ToString() + " was selected", "OK");
            ((ListView)sender).SelectedItem = null;
        };

    }
}