using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Entities;

namespace TitanWeb.Infrastructure.Contexts;

public partial class TitanWebContext : DbContext
{
    public TitanWebContext()
    {
    }

    public TitanWebContext(DbContextOptions<TitanWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Button> Buttons { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<RequestForm> RequestForms { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SubItem> SubItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=TitanWeb;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Button>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.ButtonId, "IX_Items_ButtonId");

            entity.HasIndex(e => e.CategoryId, "IX_Items_CategoryId");

            entity.HasIndex(e => e.ImageId, "IX_Items_ImageId");

            entity.HasIndex(e => e.SectionId, "IX_Items_SectionId");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Button).WithMany(p => p.Items).HasForeignKey(d => d.ButtonId);

            entity.HasOne(d => d.Category).WithMany(p => p.Items).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Image).WithMany(p => p.Items).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Section).WithMany(p => p.Items).HasForeignKey(d => d.SectionId);
        });

        modelBuilder.Entity<RequestForm>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_RequestForms_CategoryId");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Category).WithMany(p => p.RequestForms).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasIndex(e => e.ImageId, "IX_Sections_ImageId");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Image).WithMany(p => p.Sections).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<SubItem>(entity =>
        {
            entity.HasIndex(e => e.ItemId, "IX_SubItems_ItemId");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Item).WithMany(p => p.SubItems).HasForeignKey(d => d.ItemId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
