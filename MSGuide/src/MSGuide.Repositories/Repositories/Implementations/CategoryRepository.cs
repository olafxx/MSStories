using MSGuide.Repositories.Repositories.Interfaces;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSGuide.Repositories.Models;

namespace MSGuide.Repositories.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ArticleContext _context;
        public CategoryRepository(ArticleContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetByName(string name)
        {
            return _context.Categories.First(o=>o.Name == name);
        }

        public Category GetByAlias(string alias)
        {
            return _context.Categories.Where(o => o.Alias == alias).FirstOrDefault();
        }
    }
}
