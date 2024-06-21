using AutoMapper;
using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.Database.Adapter.Entities.Mappings;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemEntity>();
        CreateMap<ItemEntity, Item>();
    }
}