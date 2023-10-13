using System.Security.Cryptography.X509Certificates;
using Favourite.Entities;
using Microsoft.EntityFrameworkCore;

namespace Favourite.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){  }
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }
}
