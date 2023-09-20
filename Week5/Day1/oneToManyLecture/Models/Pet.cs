#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace oneToManyLecture.Models;


public class Pet 

{
    [Key]
    public int PetId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Required]
    public int OwnerId { get; set; }
    // Navigation property that lets us see the whole owner
    public Owner? Owner { get; set; }

}