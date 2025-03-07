namespace SampleMAUIApp.Bab4;

[QueryProperty(nameof(ReceivedText), "text")]
public partial class DetailPageNav : ContentPage
{

    public DetailPageNav()
    {
        InitializeComponent();
    }

    private string receivedText;
    public string ReceivedText
    {
        get => receivedText;
        set
        {
            receivedText = Uri.UnescapeDataString(value);
            OnPropertyChanged(nameof(ReceivedText));
            ReceivedTextLabel.Text = $"Received Text: {receivedText}";
        }
    }
}