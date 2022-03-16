using KonusarakOgrenProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Concrete
{
    public class Exam : BaseEntity, IExam
    {
        public string Paragraph { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
