using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfraData.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    ) : base(options)
    {
    }
    public DbSet<Author> Author { get; set;}
    public DbSet<Book> Book { get; set;}
    public DbSet<BookAuthor> BookAuthor { get; set;}
    public DbSet<Category> Category { get; set;}
    public DbSet<Loan> Loan { get; set;}
    public DbSet<User> User { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}