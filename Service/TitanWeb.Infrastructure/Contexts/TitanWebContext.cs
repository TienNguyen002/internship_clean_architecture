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

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasMany(d => d.Items).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryItem",
                    r => r.HasOne<Item>().WithMany().HasForeignKey("ItemsItemId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoriesCategoryId"),
                    j =>
                    {
                        j.HasKey("CategoriesCategoryId", "ItemsItemId");
                        j.ToTable("CategoryItem");
                        j.HasIndex(new[] { "ItemsItemId" }, "IX_CategoryItem_ItemsItemId");
                    });
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.ButtonId, "IX_Items_ButtonId");

            entity.HasIndex(e => e.ImageId, "IX_Items_ImageId");

            entity.HasOne(d => d.Button).WithMany(p => p.Items).HasForeignKey(d => d.ButtonId);

            entity.HasOne(d => d.Image).WithMany(p => p.Items).HasForeignKey(d => d.ImageId);

            entity.HasMany(d => d.Sections).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemSection",
                    r => r.HasOne<Section>().WithMany().HasForeignKey("SectionsSectionId"),
                    l => l.HasOne<Item>().WithMany().HasForeignKey("ItemsItemId"),
                    j =>
                    {
                        j.HasKey("ItemsItemId", "SectionsSectionId");
                        j.ToTable("ItemSection");
                        j.HasIndex(new[] { "SectionsSectionId" }, "IX_ItemSection_SectionsSectionId");
                    });

            entity.HasMany(d => d.SubItems).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemSubItem",
                    r => r.HasOne<SubItem>().WithMany().HasForeignKey("SubItemsSubItemId"),
                    l => l.HasOne<Item>().WithMany().HasForeignKey("ItemsItemId"),
                    j =>
                    {
                        j.HasKey("ItemsItemId", "SubItemsSubItemId");
                        j.ToTable("ItemSubItem");
                        j.HasIndex(new[] { "SubItemsSubItemId" }, "IX_ItemSubItem_SubItemsSubItemId");
                    });
        });

        modelBuilder.Entity<RequestForm>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_RequestForms_CategoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.RequestForms).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasIndex(e => e.ImageId, "IX_Sections_ImageId");

            entity.HasOne(d => d.Image).WithMany(p => p.Sections).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<SubItem>(entity =>
        {
            entity.HasIndex(e => e.ImageId, "IX_SubItems_ImageId");

            entity.HasOne(d => d.Image).WithMany(p => p.SubItems).HasForeignKey(d => d.ImageId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
