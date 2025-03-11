using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.DAL
{
    public class TodoDAL : ITodoDAL
    {
        private readonly TodoContext _todoContext;

        public TodoDAL(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            var result = await _todoContext.TodoItems.FindAsync(id);
            if (result == null)
            {
                throw new Exception("Item not found");
            }
            return result;
        }

        public async Task AddAsync(TodoItem item)
        {
            _todoContext.TodoItems.Add(item);
            await _todoContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _todoContext.Entry(item).State = EntityState.Modified;
            await _todoContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoItem = await _todoContext.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _todoContext.TodoItems.Remove(todoItem);
                await _todoContext.SaveChangesAsync();
            }
        }
    }
}
