namespace SampleMAUIApp.Bab5;

public partial class AddEmployee : ContentPage
{
    public AddEmployee()
    {
        InitializeComponent();
    }

    public async void OnSaveClicked(object sender, EventArgs args)
    {
        var newEmployee = new Employee()
        {
            EmpName = txtEmpName.Text,
            Department = txtDepartment.Text,
            Designation = txtDesign.Text,
            Qualification = txtQualification.Text
        };
        App.DBUtils.SaveEmployee(newEmployee);
        await Navigation.PushAsync(new ManageEmployee());
    }
}