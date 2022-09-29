using Microsoft.EntityFrameworkCore;
using zadaniya.Entites;

namespace zadaniya.Data;
public class AppDbContext:DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> option):base(option){}
  public DbSet<Template> Templates { get; set; }  
}