
using Microsoft.EntityFrameworkCore;
using SeamLessGoWeb.Data.Entities;
namespace SeamLessGoWeb.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<TransactionLineEntity> TransactionLines { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<TransactionTypeEntity> TransactionTypes { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<ItemPackEntity> ItemPacks { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your UserEntity table
            modelBuilder.Entity<TransactionEntity>()
              .HasOne(t => t.Customer)
              .WithMany()
              .HasForeignKey(t => t.CustomerID)
              .OnDelete(DeleteBehavior.Restrict);

            // --------------------------
            // Transaction ↔ User (CreatedByUser)
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // --------------------------
            // Transaction ↔ TransactionType
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.TransactionType)
                .WithMany()
                .HasForeignKey(t => t.TransactionTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            // --------------------------
            // Transaction ↔ Route
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Route)
                .WithMany()
                .HasForeignKey(t => t.RouteID)
                .OnDelete(DeleteBehavior.SetNull);

            // --------------------------
            // Transaction ↔ Currency
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.Currency)
                .WithMany()
                .HasForeignKey(t => t.CurrencyID)
                .OnDelete(DeleteBehavior.Restrict);

            // --------------------------
            // Transaction ↔ Source Transaction
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.SourceTransaction)
                .WithMany()
                .HasForeignKey(t => t.SourceTransactionID)
                .OnDelete(DeleteBehavior.SetNull);

            // --------------------------
            // Transaction ↔ Source Order
            // --------------------------
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.SourceOrder)
                .WithMany()
                .HasForeignKey(t => t.SourceOrderID)
                .OnDelete(DeleteBehavior.SetNull);

            // --------------------------
            // TransactionLine ↔ Transaction
            // --------------------------
            modelBuilder.Entity<TransactionLineEntity>()
                .HasOne(l => l.Transaction)
                .WithMany(t => t.TransactionLines) // You MUST add this navigation in TransactionEntity
                .HasForeignKey(l => l.TransactionID)
                .OnDelete(DeleteBehavior.Cascade);

            // --------------------------
            // TransactionLine ↔ ItemPack
            // --------------------------
            modelBuilder.Entity<TransactionLineEntity>()
                .HasOne(l => l.Itempack)
                .WithMany()
                .HasForeignKey(l => l.ItemPackID)
                .OnDelete(DeleteBehavior.Restrict);

        }



    }


}