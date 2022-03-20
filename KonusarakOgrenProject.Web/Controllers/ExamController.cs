using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.Core.Filters;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using KonusarakOgrenProject.Web.Models;
using KonusarakOgrenProject.Web.Models.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonusarakOgrenProject.Web.Controllers
{
    public class ExamController : Controller
    {
        private readonly IDeleteExamService _deleteExamService;
        private readonly ICreateExamService _createExamService;
        private readonly DatabaseContext _db;
        public ExamController(DatabaseContext db, ICreateExamService createExamService, IDeleteExamService deleteExamService)
        {
            _deleteExamService = deleteExamService;
            _createExamService = createExamService;
            _db = db;
        }

        [HttpGet]
        [LoggedUser]
        public IActionResult CreateExam()
        {
            CreateExamViewModel createExamViewModel = new CreateExamViewModel();
            var articles = _db.Articles.ToList();
            createExamViewModel.ArticleTitles = _db.Articles.Select(x => new SelectListItem(x.Title, x.Id.ToString())).Skip(Math.Max(0, articles.Count - 5 )).ToList();

            return View(createExamViewModel);
        }

        [HttpGet]
        public Article GetSelectedArticle(int id) // ajax ile CreateExam view'ına tüm verileri çekmeden seçilen Article'ı göndermek için kullanılır.
        {
            return _db.Articles.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult CreateExam(CreateExamViewModel model)
        {
            var result = _createExamService.CreateExam(model.SelectedArticleId, model.ExamViewModels.Questions);            
            if (result)
            {
                TempData["message"] = "Exam Created.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["message"] = "There was an error occured.";
                return View(model);
            }
        }

        [HttpGet]
        [LoggedUser]
        public IActionResult TakeExam()
        {
            var result =_db.Exams.ToList();
            TakeExamViewModel takeExamViewModel = new TakeExamViewModel();
            //takeExamViewModel.Exam=result;
            return View(takeExamViewModel);
        }

        [LoggedUser]
        public IActionResult DeleteExam(int id)
        {
            var result = _deleteExamService.DeleteExam(id);
            if (result)
            {
                TempData["message"] = "Exam Deleted.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["message"] = "There was an error occured.";
                return View(id);
            }
        }

        [LoggedUser]
        [HttpPost]
        public IActionResult TakeExam(Exam exam)
        {
            return View();
        }
    }
}
