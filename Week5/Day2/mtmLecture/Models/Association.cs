#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace mtmLecture.Models;


public class Association
{
    [Key]
    public int AssociationId { get; set; }
    [Required]
    public string ActorId{ get; set; }
    public Actor? Actor { get; set; }
    [Required]
    public string MovieId { get; set; }
    public Movie? Movie { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // navigation properties
    
}
