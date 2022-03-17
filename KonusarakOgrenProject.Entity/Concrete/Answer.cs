using KonusarakOgrenProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Concrete
{
    public class Answer : BaseEntity, IAnswer
    {
        public string Text { get; set; }

        public bool isTrue { get; set; } = false;

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
