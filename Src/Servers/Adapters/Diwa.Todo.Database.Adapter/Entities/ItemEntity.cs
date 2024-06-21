namespace Diwa.Todo.Database.Adapter.Entities;

public class ItemEntity
{
    public Guid Id { get; init; }
    
    public string Text { get; set; }
    
    public bool IsDone { get; set; }
    
    public DateTime CreatedAtUtc { get; set; }
}