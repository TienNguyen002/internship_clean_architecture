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

            entity.HasMany(d => d.Items).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryItem",
                    r => r.HasOne<Item>().WithMany().HasForeignKey("ItemsId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    j =>
                    {
                        j.HasKey("CategoriesId", "ItemsId");
                        j.ToTable("CategoryItem");
                        j.HasIndex(new[] { "ItemsId" }, "IX_CategoryItem_ItemsId");
                    });
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

            entity.HasIndex(e => e.ImageId, "IX_Items_ImageId");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Button).WithMany(p => p.Items).HasForeignKey(d => d.ButtonId);

            entity.HasOne(d => d.Image).WithMany(p => p.Items).HasForeignKey(d => d.ImageId);

            entity.HasMany(d => d.Sections).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemSection",
                    r => r.HasOne<Section>().WithMany().HasForeignKey("SectionsId"),
                    l => l.HasOne<Item>().WithMany().HasForeignKey("ItemsId"),
                    j =>
                    {
                        j.HasKey("ItemsId", "SectionsId");
                        j.ToTable("ItemSection");
                        j.HasIndex(new[] { "SectionsId" }, "IX_ItemSection_SectionsId");
                    });

            entity.HasMany(d => d.SubItems).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemSubItem",
                    r => r.HasOne<SubItem>().WithMany().HasForeignKey("SubItemsId"),
                    l => l.HasOne<Item>().WithMany().HasForeignKey("ItemsId"),
                    j =>
                    {
                        j.HasKey("ItemsId", "SubItemsId");
                        j.ToTable("ItemSubItem");
                        j.HasIndex(new[] { "SubItemsId" }, "IX_ItemSubItem_SubItemsId");
                    });
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
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
