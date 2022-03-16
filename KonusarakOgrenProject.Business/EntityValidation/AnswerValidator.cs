using FluentValidation;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.EntityValidation
{
    public class AnswerValidator : AbstractValidator<Answer>
    {
        static readonly int maxLength = 250;

        readonly string notNullMessage = "This field cannot be empty.";
        readonly string maxLengthMessage = $"Maximum length of this field can be {maxLength}";

        public AnswerValidator()
        {
            RuleFor(x => x.Text)
                .NotNull().WithMessage(notNullMessage)
                .NotEmpty().WithMessage(maxLengthMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);
        }
    }
}
