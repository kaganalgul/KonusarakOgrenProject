using FluentValidation;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.EntityValidation
{
    internal class QuestionValidator : AbstractValidator<Question>
    {
        static readonly int maxLength = 500;

        readonly string notNullMessage = "This field cannot be empty.";
        readonly string maxLengthMessage = $"Maximum length of this field can be {maxLength}";

        public QuestionValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage(notNullMessage)
                .NotNull().WithMessage(notNullMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);
        }
    }
}
