using SampleMAUIApp.Models;

namespace SampleMAUIApp.Bab3;

public partial class BindingToDataModel : ContentPage
{
    public BindingToDataModel()
    {
        InitializeComponent();
        BindingContext = new ListViewDataModelViewModel();
    }

    private async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        ListItem item = (ListItem)e.Item;
        await DisplayAlert("Tapped", item.Title.ToString() + " was selected", "OK");
        ((ListView)sender).SelectedItem = null;
    }


    public class ListViewDataModelViewModel : BindableObject
    {
        private List<ListItem> lstItems;
        public ListViewDataModelViewModel()
        {
            lstItems = new List<ListItem>
                {
                    new ListItem { Title="Mystic", Description="Mystic team blue badge" },
                    new ListItem {Title="Instinct",Description="Instinct team yellow badge" },
                    new ListItem {Title="Valor",Description="Valor team red badge" }
                };
        }
        public List<ListItem> ListItems
        {
            get { return lstItems; }
            set
            {
                lstItems = value;
                OnPropertyChanged("ListItems");
            }
        }
    }



}