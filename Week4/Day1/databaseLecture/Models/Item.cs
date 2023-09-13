#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace databaseLecture.Models;

public class Item
{
    // we Need an ID
    // make sure is the name of your model + ID
    [Key]
    [Required]
    public int ItemId { get; set; }
    [Required]
    [MinLength(5)]
    public string name { get; set; }
    [Required]
    [MinLength(10)]
    public string Description { get; set; }
    // we always include a createdAt and updatedAt because it's good practice
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}