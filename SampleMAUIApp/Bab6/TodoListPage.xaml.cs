using System.Diagnostics;
namespace SampleMAUIApp.Bab6;

public partial class TodoListPage : ContentPage
{
    public TodoListPage()
    {
        InitializeComponent();
    }

    private void ListView_Refreshing(object sender, EventArgs e)
    {
        OnAppearing();
        listView.IsRefreshing = false;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var data = await App.EmpServices.RefreshDataAsync();
        listView.ItemsSource = data;
    }

    void OnAddItemClicked(object sender, EventArgs e)
    {
        var todoPage = new TodoItemPage(true);
        todoPage.BindingContext = new TodoItem();
        Navigation.PushAsync(todoPage);
    }

    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var todoItem = e.SelectedItem as TodoItem;
        var todoPage = new TodoItemPage();
        todoPage.BindingContext = todoItem;
        Navigation.PushAsync(todoPage);
    }
}