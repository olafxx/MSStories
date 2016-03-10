using System.Linq;
using Microsoft.AspNet.Mvc;
using MSStories.Repositories.Models;
using MSStories.Repositories.Repositories.Interfaces;

namespace MSStories.Controllers
{
    public class HomeController : Controller
    {
        [FromServices]
        public IArticleRepository _articleRepository { get; set; }
        [FromServices]
        public IWriterRepository _writerRepository { get; set; }
        [FromServices]
        public ICategoryRepository _categoryRepository { get; set; }


        [Route("/")]
        public IActionResult Index()
        {
            var article = _articleRepository.GetArticles();
            return View(article);
        }

        [Route("{alias}")]
        public IActionResult BlogItem(string alias)
        {
            var article = _articleRepository.GetByAlias(alias);
            return View(article);
        }
        [Route("{}")]

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult MainMenu()
        {
            _categoryRepository.GetCategories();

            return PartialView();
        }
    }
}
