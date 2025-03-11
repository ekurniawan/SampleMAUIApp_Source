using BackendAPI.DAL;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TodoConnectionString")));

builder.Services.AddScoped<ITodoDAL, TodoDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.  
app.MapGet("/todoitems", async (ITodoDAL repository) =>
    await repository.GetAllAsync());

app.MapGet("/todoitems/{id}", async (int id, ITodoDAL repository) =>
{
    var todoItem = await repository.GetByIdAsync(id);
    return todoItem is not null ? Results.Ok(todoItem) : Results.NotFound();
});

app.MapPost("/todoitems", async (TodoItem todo, ITodoDAL repository) =>
{
    await repository.AddAsync(todo);
    return Results.Created($"/todoitems/{todo.TodoId}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, ITodoDAL repository) =>
{
    var todo = await repository.GetByIdAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.Notes = inputTodo.Notes;
    todo.Done = inputTodo.Done;

    await repository.UpdateAsync(todo);
    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, ITodoDAL repository) =>
{
    var todo = await repository.GetByIdAsync(id);
    if (todo is not null)
    {
        await repository.DeleteAsync(id);
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

app.Run();