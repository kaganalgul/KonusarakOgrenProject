using KonusarakOgrenProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonusarakOgrenProject.Web.Models.Exam
{
    public class ExamViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<Question> Questions { get; set; }
    }
}
