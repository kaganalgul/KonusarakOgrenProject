using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using KonusarakOgrenProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KonusarakOgrenProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetArticleFromWebsiteService _getArticleFromWebsiteService;
        private readonly DatabaseContext _db;

        public HomeController(DatabaseContext db, IGetArticleFromWebsiteService getArticleFromWebsiteService)
        {
            _db = db;
            _getArticleFromWebsiteService = getArticleFromWebsiteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            _getArticleFromWebsiteService.GetArticleFromWebsite();
            List<GetArticleViewModel> articleViewModels = new List<GetArticleViewModel>();
            List<Article> articles1 = _db.Articles.ToList();
            articleViewModels = _db.Articles.Select(x => new GetArticleViewModel() { Content = x.Content, Title = x.Title }).Skip(Math.Max(0, articles1.Count - 5)).ToList(); // This method start taking last 5 articles from web site but while the program is working the added articles are added to database too. It take last 5 articles from db with SKIP method. If we always want to take only last 5 articles from website, we can write a cronjob method to reset database when the new data come then rerun the method.
            return View(articleViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}