using KonusarakOgrenProject.Business.Concrete;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.Abstract
{
    public interface ICreateExamService
    {
        public bool CreateExam(int articleId, List<Question> questions);
    }
}
