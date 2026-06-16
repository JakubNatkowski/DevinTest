using CardDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Data;

/// <summary>
/// Database context for CardDemo application
/// Replaces VSAM/DB2 with SQL Server using Entity Framework Core
/// </summary>
public class CardDemoDbContext : DbContext
{
    public CardDemoDbContext(DbContextOptions<CardDemoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Card> Cards => Set<Card>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<CardAccountCrossReference> CardAccountCrossReferences => Set<CardAccountCrossReference>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Customer entity
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.SSN).IsRequired();
        });

        // Configure Account entity
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId);
            entity.Property(e => e.ActiveStatus).IsRequired();
            entity.Property(e => e.CurrentBalance).HasPrecision(12, 2);
            entity.Property(e => e.CreditLimit).HasPrecision(12, 2);
            entity.Property(e => e.CashCreditLimit).HasPrecision(12, 2);
            entity.Property(e => e.CurrentCycleCredit).HasPrecision(12, 2);
            entity.Property(e => e.CurrentCycleDebit).HasPrecision(12, 2);

            entity.HasOne(e => e.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Card entity
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardNumber);
            entity.Property(e => e.CardNumber).HasMaxLength(16).IsRequired();
            entity.Property(e => e.AccountId).IsRequired();
            entity.Property(e => e.EmbossedName).IsRequired();

            entity.HasOne(e => e.Account)
                .WithMany(a => a.Cards)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure User entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasMaxLength(8).IsRequired();
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.UserType).IsRequired();
        });

        // Configure Transaction entity
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);
            entity.Property(e => e.AccountId).IsRequired();
            entity.Property(e => e.CardNumber).IsRequired();
            entity.Property(e => e.TransactionDate).IsRequired();
            entity.Property(e => e.TransactionType).HasMaxLength(2).IsRequired();
            entity.Property(e => e.TransactionCategory).HasMaxLength(4).IsRequired();
            entity.Property(e => e.TransactionAmount).HasPrecision(12, 2);

            entity.HasOne(e => e.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure CardAccountCrossReference entity
        modelBuilder.Entity<CardAccountCrossReference>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CardNumber).IsRequired();
            entity.Property(e => e.CustomerId).IsRequired();
            entity.Property(e => e.AccountId).IsRequired();
        });
    }
}
