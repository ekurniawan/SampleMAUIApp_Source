using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleMAUIApp.Bab6
{
    public class RestServices : IRestServices
    {
        private HttpClient client;
        public List<TodoItem> Items { get; private set; }

        public RestServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            Items = new List<TodoItem>();
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var uri = new Uri($"{Constants.RestUrl}/todoitems/{id}");
            await client.DeleteAsync(uri);
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items.Clear();
            var uri = new Uri($"{Constants.RestUrl}/todoitems");
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<TodoItem>>(content);
            }
            else
            {
                throw new Exception("Gagal mengambil data");
            }
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem)
        {
            Uri uri = null!;
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null!;
            if (isNewItem)
            {
                uri = new Uri($"{Constants.RestUrl}/todoitems");
                response = await client.PostAsync(uri, content);
            }
            else
            {
                uri = new Uri($"{Constants.RestUrl}/todoitems/{item.todoId}");
                response = await client.PutAsync(uri, content);
            }
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception("Gagal menyimpan data");
            }
        }
    }
}
