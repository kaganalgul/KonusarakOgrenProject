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
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).IsRequired();

            builder.HasOne(x => x.Exam).WithOne(x => x.Question).HasForeignKey<Exam>(x => x.QuestionId);

        }
    }
}
