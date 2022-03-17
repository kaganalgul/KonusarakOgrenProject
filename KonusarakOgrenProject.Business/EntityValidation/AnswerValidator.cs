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

        public AnswerValidator()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty()
                .MaximumLength(maxLength);
        }
    }
}
