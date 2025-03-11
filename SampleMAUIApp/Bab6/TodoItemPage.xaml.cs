namespace SampleMAUIApp.Bab6;

public partial class TodoItemPage : ContentPage
{
    public TodoItemPage()
    {
        InitializeComponent();
    }

    bool isNewItem;
    public TodoItemPage(bool isNew = false)
    {
        InitializeComponent();
        isNewItem = isNew;
    }
    async void OnSaveActivated(object sender, EventArgs e)
    {
        var todoItem = (TodoItem)BindingContext;
        await App.EmpServices.SaveTodoItemAsync(todoItem, isNewItem);
        await Navigation.PopAsync();
    }

    async void OnDeleteActivated(object sender, EventArgs e)
    {
        var todoItem = (TodoItem)BindingContext;
        await App.EmpServices.DeleteTodoItemAsync(todoItem.todoId);
        await Navigation.PopAsync();
    }
    void OnCancelActivated(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}