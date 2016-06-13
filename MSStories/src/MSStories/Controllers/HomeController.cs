using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSStories.Repositories.Repositories.Interfaces;

namespace MSStories.Controllers
{
    public class HomeController : Controller
    {
        public IArticleRepository _articleRepository { get; set; }
        public IWriterRepository _writerRepository { get; set; }
        public ICategoryRepository _categoryRepository { get; set; }

        public HomeController([FromServices] IArticleRepository article, [FromServices] IWriterRepository writers, [FromServices] ICategoryRepository categories)
        {
            _articleRepository = article;
            _writerRepository = writers;
            _categoryRepository = categories;

        }

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
