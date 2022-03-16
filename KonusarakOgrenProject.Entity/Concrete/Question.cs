using KonusarakOgrenProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Concrete
{
    public class Question : BaseEntity, IQuestion
    {
        public string Text { get; set; }

        public Exam Exam { get; set; }

        public int ExamId { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
}
