using MSGuide.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSGuide.Repositories.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetByName(string name);
        Category GetByAlias(string alias);

    }
}
