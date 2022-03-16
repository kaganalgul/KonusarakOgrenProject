using KonusarakOgrenProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Mapping.EntityMapping
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Paragraph).IsRequired();

            builder.HasOne(x => x.Question).WithOne(x => x.Exam).HasForeignKey<Question>(x => x.ExamId);

            builder.HasMany(x => x.Answers).WithOne(x => x.Exam).HasForeignKey(x => x.ExamId);
        }
    }
}
