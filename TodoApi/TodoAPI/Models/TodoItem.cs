namespace TodoAPI.Models;

public class TodoItem:CreateTodo
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string Modifier { get; set; }
    public byte Finished { get; set; }
}