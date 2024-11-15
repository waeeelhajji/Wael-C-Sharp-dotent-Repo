#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace beltReview.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    // other Models
    public DbSet<Song> Songs { get; set; } 
    public DbSet<Like> Likes { get; set; } 
    
}