using KonusarakOgrenProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Concrete
{
    public class Article : BaseEntity, IArticle
    {
        public string Content { get; set; }

        public string Title { get; set; }
    }
}
