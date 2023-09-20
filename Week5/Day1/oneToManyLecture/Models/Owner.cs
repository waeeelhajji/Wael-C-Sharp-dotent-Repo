#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace oneToManyLecture.Models;


public class Owner 

{
    [Key]
    public int OwnerId { get; set; }
    [Required]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Pet> PetOwned { get; set; } = new List<Pet>();


}