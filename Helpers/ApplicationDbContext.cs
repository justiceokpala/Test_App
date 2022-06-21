
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test_App.Models;

namespace Test_App.Helpers
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
    {
    }
    public DbSet<User> Customers { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Lga> Lgas { get; set; }
  
    }
}
