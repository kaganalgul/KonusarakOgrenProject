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
        
        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string TrueOption { get; set; }
    }
}
