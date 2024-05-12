using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Data.Domain.Mapping
{
    public partial class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));

           
            builder.HasKey(s => s.Id);

            builder.Property(p => p.FirstName)
                    .HasColumnName(nameof(Student.FirstName));

            builder.Property(p => p.LastName)
                .HasColumnName(nameof(Student.LastName))
                    .HasMaxLength(50);

        }
    }
}
