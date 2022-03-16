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
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).IsRequired();

            builder.Property(x => x.Question).IsRequired();

            builder.Property(x => x.Exam).IsRequired();
        }
    }
}
