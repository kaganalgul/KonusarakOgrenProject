using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.Concrete
{
    public class TakeExamManager
    {
        DatabaseContext _db;
        public TakeExamManager(DatabaseContext db)
        {
            _db = db;
        }

        public bool TakeExam(int id, List<Question> questions)
        {
            Exam exam = _db.Exams.FirstOrDefault(x => x.Id == id);
            exam.Questions = questions;

            return true;
        }
    }
}
