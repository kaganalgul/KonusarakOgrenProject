using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Abstract
{
    public interface IArticle
    {
        public string Content { get; set; }

        public string Title { get; set; }
    }
}
