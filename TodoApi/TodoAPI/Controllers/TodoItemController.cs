using DbCore;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
  
    private readonly ILogger<TodoItemController> _logger;
    private readonly DbCoreContext _context;

    public TodoItemController(ILogger<TodoItemController> logger, DbCoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetAll")]
    public  ActionResult<IEnumerable<TodoItem>> GetAll()
    {
        var result = _context.TodoItem.Select(c => new TodoItem()
        {
            Id = c.Id,
            Title = c.Title,
            Content = c.Content,
            Created = c.Created,
            Modified = c.Modified,
            Modifier = c.Modifier,
            Finished = c.Finished == 1
        }).ToList();
        return result;
    }
    
    [HttpPatch("UdpateStatus/{Id}")]
    public  ActionResult UdpateStatus(Guid Id, bool Finished)
    {
        var itemToUpdate = _context.TodoItem.FirstOrDefault(c => c.Id == Id);
        if (itemToUpdate is not null)
        {
            byte trueByte = 1;
            byte falseByte = 0;
            itemToUpdate.Finished = Finished ? trueByte : falseByte;
            _context.SaveChanges();
        }
        return new OkResult();
    }
    
    [HttpDelete("Delete/{Id}")]
    public  ActionResult Delete(Guid Id)
    {
     var itemToRemove = _context.TodoItem.FirstOrDefault(c => c.Id == Id);
     if (itemToRemove is not null)
     {
         _context.TodoItem.Remove(itemToRemove);
         _context.SaveChanges();
     }
     return new OkResult();
    }
}