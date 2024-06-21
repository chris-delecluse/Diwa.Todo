using Diwa.Todo.Database.Adapter.Entities;
using Diwa.Todo.Port.Driven;
using Microsoft.EntityFrameworkCore;

namespace Diwa.Todo.Database.Adapter;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<ItemEntity> Items { get; set; }
}