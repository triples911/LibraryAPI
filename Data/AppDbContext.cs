using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models; // تأكد أن Namespace يوافق اسم مشروعك

public class AppDbContext : DbContext
{
    public DbSet<Library> Libraries { get; set; }
    public DbSet<LibraryAddress> LibraryAddresses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // إعداد علاقة One-to-One باستخدام Fluent API
        modelBuilder.Entity<Library>()
            .HasOne(l => l.LibraryAddress)
            .WithOne(a => a.Library)
            .HasForeignKey<LibraryAddress>(a => a.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}