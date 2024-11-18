using System;
using CrudApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Data;

public class ApplicationDbContext : DbContext
{
    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    // {
    // }
    private readonly IConfiguration configuration;

    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
}
