using HtmlAgilityPack;
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
    public class GetArticleFromWebsiteManager : IGetArticleFromWebsiteService
    {
        DatabaseContext _db;
        const int articleCount = 5;
        List<string>upToDatelastTenPostsUrls = new List<string>();

        public GetArticleFromWebsiteManager(DatabaseContext db)
        {
            _db = db;
        }

        public void GetArticleFromWebsite()
        {
            var url = "https://www.wired.com/most-recent/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var uris = doc.DocumentNode
                .Descendants("a").Where(x => x.Attributes.Contains("class"))
                .Where(x => x.Attributes["class"].Value == "archive-item-component__link")
                .Select(x => x.Attributes["href"].Value).ToList();
                        
            for (int i = 0; i < uris.Count; i++)
            {
                if (i % 2 == 0)
                {
                    string tempUrl = "https://www.wired.com" + uris[i];
                    upToDatelastTenPostsUrls.Add(tempUrl);
                }
            };

            for (int i = 0; i < articleCount; i++)
            {
                var url2 = $"{upToDatelastTenPostsUrls[i]}";
                var web2 = new HtmlWeb();
                var doc2 = web.Load(url2);

                var title = doc2.DocumentNode.Descendants("h1")
                .Select(x => x.InnerText)
                .FirstOrDefault();

                if (_db.Articles.Any(x => x.Title == title))
                {
                    continue;
                }

                var contentHeader = doc2.DocumentNode.Descendants("div")
                .Where(x => x.Attributes
                .Contains("class"))
                .Where(x => x.Attributes["class"].Value.Contains("ContentHeaderDek-uqvGp")).FirstOrDefault().InnerText;

                var leadText = doc2.DocumentNode.Descendants()
                .Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "lead-in-text-callout")
                .Select(x => x.Ancestors("p")).FirstOrDefault().FirstOrDefault().InnerText;

                var InnerContainerElements = doc2.DocumentNode.Descendants().Where(x => !(x.Attributes.Contains("hr") && x.Attributes.Contains("ul")))
                .Where(x => x.Attributes.Contains("class"))
                .Where(x =>
                x.Attributes["class"].Value == "paywall" ||
                x.Attributes["class"].Value == "paywall heading-h3").Where(x => !x.Attributes.Contains("div")).ToList();

                InnerContainerElements = InnerContainerElements.Take(InnerContainerElements.Count - 2).ToList(); // Delete the advertising area.

                var space = "<br /><br />";

                var content = contentHeader + space + leadText + space;

                foreach (var item in InnerContainerElements)
                {
                    content = content + (item.InnerText + space);
                }

                Article article = new Article()
                {
                    Title = title,
                    Content = content,
                };

                _db.Articles.Add(article);
                _db.SaveChanges();           
            }
        }
    }
}
