namespace SampleMAUIApp.Bab5;

public partial class ManageEmployee : ContentPage
{
    public ManageEmployee()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        lstEmployee.ItemsSource = App.DBUtils.GetAllEmployees();
    }

    private async void LstEmployee_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
        {
            return;
        }
        var empDetail = (Employee)e.SelectedItem;
        await Navigation.PushAsync(new ShowEmployee(empDetail));
    }

    public async void OnNewClicked(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new AddEmployee());
    }

    public async void btnDeleteClick(object sender, EventArgs args)
    {
        var item = (Button)sender;
        if (item.Text == "delete")
        {
            var result = await DisplayAlert("Konfirmasi", "Apakah anda yakin akan mendelete data " + item.CommandParameter.ToString() + " ?", "Yes", "No");
            if (result)
            {
                var empId = Convert.ToInt64(item.CommandParameter.ToString());
                App.DBUtils.DeleteEmployee(new Employee { EmpId = empId });
                OnAppearing();
            }
        }
    }

}