using MSStories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSStories.Repositories.Repositories.Interfaces
{
    public interface IWriterRepository
    {
        IEnumerable<Writer> GetWriters(ArticleContext context);
    }
}
