    using LibraryDomain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInfraData.EntitiesConfiguration {

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
            builder.Property(b => b.Quantity).IsRequired();
            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Books)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(b => b.PublicationYear).IsRequired();
            builder.Property(b => b.CategoryId).IsRequired();
        }
    }

}