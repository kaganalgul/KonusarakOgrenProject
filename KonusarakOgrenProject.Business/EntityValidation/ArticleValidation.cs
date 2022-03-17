using FluentValidation;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.EntityValidation
{
    internal class ArticleValidation : AbstractValidator<Article>
    {
        int maxTitleLength = 350;
        int maxArticleLength = 10000;

        public ArticleValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(maxTitleLength);

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(maxArticleLength);
        }
    }
}
