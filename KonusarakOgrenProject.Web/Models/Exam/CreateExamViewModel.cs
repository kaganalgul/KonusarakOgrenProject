using KonusarakOgrenProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonusarakOgrenProject.Web.Models.Exam
{
    public class CreateExamViewModel
    {
        public ExamViewModel ExamViewModels { get; set; }

        public List<SelectListItem> ArticleTitles { get; set; }

        public int SelectedArticleId { get; set; }
    }
}
