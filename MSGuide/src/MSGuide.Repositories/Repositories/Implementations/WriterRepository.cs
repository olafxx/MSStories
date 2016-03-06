using MSGuide.Repositories.Models;
using MSGuide.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSGuide.Repositories.Repositories.Implementations
{
    public class WriterRepository :IWriterRepository
    {
        public IEnumerable<Writer> GetWriters(ArticleContext context)
        {
            return context.Writers.ToList();
        }
    }
}
