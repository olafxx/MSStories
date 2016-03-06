using MSGuide.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSGuide.Repositories.Repositories.Interfaces
{
    public interface IWriterRepository
    {
        IEnumerable<Writer> GetWriters(ArticleContext context);
    }
}
