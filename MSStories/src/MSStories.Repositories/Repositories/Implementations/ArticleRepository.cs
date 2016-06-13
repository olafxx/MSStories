using MSStories.Repositories.Repositories.Interfaces;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using MSStories.Models;

namespace MSStories.Repositories.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;
        public ArticleRepository(ArticleContext context)
        {
            _context = context;
        }
        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleByName(string name)
        {
            return _context.Articles.First(o=>o.Header == name);
        }

        public Article GetByAlias(string alias)
        {
            return _context.Articles.Where(o => o.Alias == alias).FirstOrDefault();
        }
    }
}
