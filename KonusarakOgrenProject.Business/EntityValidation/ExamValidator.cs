using FluentValidation;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.EntityValidation
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        static readonly int maxLength = 5000;

        public ExamValidator()
        {
            RuleFor(x => x.Paragraph)
                .NotEmpty()
                .NotNull()
                .MaximumLength(maxLength);
        }
    }
}
