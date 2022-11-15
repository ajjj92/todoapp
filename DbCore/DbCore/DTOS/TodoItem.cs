using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbCore.DTOS;

public class TodoItem
{
    [Column(Order = 0)]
    public Guid Id { get; set; }
    [StringLength(40)]
    public string Title { get; set; }
    public string Content { get; set; }
    
    public byte Finished { get; set; }
    public DateTime Created { get; set; }
    [ConcurrencyCheck]
    public DateTime Modified { get; set; }
    [StringLength(40)]
    public string Modifier { get; set; }

}