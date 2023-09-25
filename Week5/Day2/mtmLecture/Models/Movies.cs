#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace mtmLecture.Models;


public class Movie
{
    [Key]
    public int MovieId { get; set; }
    [Required]
    public string Title{ get; set; }
    public string Poster { get; set; }
    public string Genre { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // navigation properties
    public List<Association> MyActors { get; set; } = new List<Association>();

}
