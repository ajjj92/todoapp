namespace TodoAPI.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string Modifier { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool Finished { get; set; }
}