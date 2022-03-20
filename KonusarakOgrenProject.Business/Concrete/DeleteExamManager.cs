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
    public class DeleteExamManager : IDeleteExamService
    {
        DatabaseContext _db;
        public DeleteExamManager(DatabaseContext db)
        {
            _db = db;
        }

        public bool DeleteExam(int id)
        {
            var exam = _db.Exams.FirstOrDefault(x => x.Id == id);
            try
            {
                _db.Exams.Remove(exam);
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
