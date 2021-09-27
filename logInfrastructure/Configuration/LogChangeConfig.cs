using logCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logInfrastructure.Configuration
{
    class LogChangeConfig : IEntityTypeConfiguration<LogChange>
    {
        public void Configure(EntityTypeBuilder<LogChange> builder)
        {
            builder.ToTable("LogChange");

            builder.HasKey(k => k.Id);
        }
    }
}
