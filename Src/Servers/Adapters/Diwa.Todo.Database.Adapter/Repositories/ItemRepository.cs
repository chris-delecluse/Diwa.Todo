using System.Linq.Expressions;
using AutoMapper;
using Diwa.Todo.Common.DataModels;
using Diwa.Todo.Database.Adapter.Entities;
using Diwa.Todo.Port.Driven;
using Microsoft.EntityFrameworkCore;

namespace Diwa.Todo.Database.Adapter.Repositories;

public class ItemRepository(AppDbContext dbContext, IMapper mapper) : IAccessItem
{
    public async Task<IEnumerable<Item>> Get()
        => mapper.Map<IEnumerable<Item>>(await dbContext.Items
            .AsNoTracking()
            .ToListAsync());

    public async Task<Item?> Get(Guid id)
        => mapper.Map<Item>(await dbContext.Items
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id));

    public async Task Post(Item item) => await dbContext.Items.AddAsync(mapper.Map<ItemEntity>(item));

    public void Put(Item item) => dbContext.Items.Update(mapper.Map<ItemEntity>(item));

    public void Delete(Item item) => dbContext.Items.Remove(mapper.Map<ItemEntity>(item));
}