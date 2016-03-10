using MSStories.Repositories.Models;
using MSStories.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSStories.Repositories.Repositories.Implementations
{
    public class WriterRepository :IWriterRepository
    {
        public IEnumerable<Writer> GetWriters(ArticleContext context)
        {
            return context.Writers.ToList();
        }
    }
}
