using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Abstract
{
    public interface IAnswer
    {
        public string Text { get; set; }

        public bool isTrue { get; set; }
    }
}
