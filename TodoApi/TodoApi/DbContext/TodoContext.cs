using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.DbContext;

public class TodoContext: Microsoft.EntityFrameworkCore.DbContext
{
    public TodoContext(DbContextOptions<TodoContext> option):base(option){}

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

}