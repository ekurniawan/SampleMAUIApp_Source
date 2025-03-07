namespace SampleMAUIApp.Bab5;

public partial class ShowEmployee : ContentPage
{
    private Employee currEmp;
    public ShowEmployee(Employee employee)
    {
        InitializeComponent();
        currEmp = employee;
        BindingContext = currEmp;
    }

    public async void OnEditClicked(object sender, EventArgs args)
    {
        currEmp.EmpName = txtEmpName.Text;
        currEmp.Department = txtDepartment.Text;
        currEmp.Designation = txtDesignation.Text;
        currEmp.Qualification = txtQualification.Text;
        App.DBUtils.EditEmployee(currEmp);
        await Navigation.PopAsync();
    }

}