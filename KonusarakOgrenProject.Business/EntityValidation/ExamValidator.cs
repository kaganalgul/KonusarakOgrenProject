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

        readonly string notNullMessage = "This field cannot be empty.";
        readonly string maxLengthMessage = $"Maximum length of this field can be {maxLength}";

        public ExamValidator()
        {
            RuleFor(x => x.Paragraph)
                .NotEmpty().WithMessage(notNullMessage)
                .NotNull().WithMessage(maxLengthMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);
        }
    }
}
