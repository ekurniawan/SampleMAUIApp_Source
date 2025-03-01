using SampleMAUIApp.Models;

namespace SampleMAUIApp.Bab3;

public partial class SampleCollectionView : ContentPage
{
    public SampleCollectionView()
    {
        InitializeComponent();
        BindingContext = new SampleCollectionViewModel();
    }

    public class SampleCollectionViewModel : BindableObject
    {
        private List<ListItem> listItems;

        public List<ListItem> ListItems
        {
            get { return listItems; }
            set
            {
                listItems = value;
                OnPropertyChanged("ListItems");
            }
        }

        public SampleCollectionViewModel()
        {
            listItems = new List<ListItem>
                {
                    new ListItem { Title="Pokeball", Description="Pokeball Red", Price="Rp.10.000" },
                    new ListItem {Title="Masterball",Description="Masterball Blue",Price="Rp.20.000" },
                    new ListItem {Title="Ultraball",Description="Ultraball Yellow",Price="Rp.50.000" }
                };
        }
    }
}