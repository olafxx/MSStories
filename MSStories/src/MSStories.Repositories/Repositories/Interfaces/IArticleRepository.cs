using MSStories.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSStories.Repositories.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
        Article GetArticleByName(string name);
        Article GetByAlias(string alias);

    }
}
