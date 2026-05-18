namespace LibraryInfraData.EntitiesConfiguration
{
    using LibraryDomain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LoanDate).IsRequired();
            builder.Property(l => l.ReturnDate).IsRequired(false); 
            builder.HasOne(l => l.User)
                   .WithMany(u => u.Loans)
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(l => l.BookId).IsRequired();
            builder.Property(l => l.UserId).IsRequired();
        }
    }

}