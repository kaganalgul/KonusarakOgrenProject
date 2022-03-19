using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.Concrete
{
    public class CreateExamManager : ICreateExamService
    {
        const int questionCountPerExam = 4;
        const int answerCountPerQuestion = 4;
        private readonly DatabaseContext _db;

        public CreateExamManager(DatabaseContext db)
        {
            _db = db;
        }

        public bool CreateExam(int articleId, List<Question> questions)
        {
            Exam exam = new Exam();
            exam.ArticleId = articleId;
            exam.Questions = questions;
            try
            {
                _db.Exams.Add(exam);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
