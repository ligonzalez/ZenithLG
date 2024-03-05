using BooksOnLoan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksOnLoan.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book>? Book { get; set; }
    public DbSet<Transactions>? Transactions { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Use seed method here
        SeedUsersRoles seedUsersRoles = new();
        builder.Entity<IdentityRole>().HasData(seedUsersRoles.Roles);
        builder.Entity<IdentityUser>().HasData(seedUsersRoles.Users);
        builder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);

        //Seeding Books 
        builder.Entity<Book>().Property(m => m.Title).IsRequired();
        builder.Entity<Book>().Property(m => m.Title).HasMaxLength(500);
        //builder.Entity<Book>().ToTable("Book");
        builder.Entity<Book>().HasData(SeedBookData.GetBooks());

        builder.Entity<Transactions>().ToTable("Transactions");
    }
}
