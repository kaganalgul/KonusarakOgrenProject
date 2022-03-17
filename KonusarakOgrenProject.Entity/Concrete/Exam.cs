﻿using KonusarakOgrenProject.Entity.Abstract;
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

        public Article Article { get; set; }

        public int ArticleId { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
