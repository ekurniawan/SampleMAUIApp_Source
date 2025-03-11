using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMAUIApp.Bab6
{
    public interface IRestServices
    {
        Task<List<TodoItem>> RefreshDataAsync();
        Task SaveTodoItemAsync(TodoItem item, bool isNewItem);
        Task DeleteTodoItemAsync(int id);
    }
}
