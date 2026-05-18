namespace LibraryInfraData.EntitiesConfiguration
{
  using LibraryDomain.Entities;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;

  public class AuthorConfiguration : IEntityTypeConfiguration<Author>
  {
    public void Configure(EntityTypeBuilder<Author> builder)
    {
      builder.HasKey(a => a.Id);
      builder.Property(a => a.Name).IsRequired();
    }
  }
}
