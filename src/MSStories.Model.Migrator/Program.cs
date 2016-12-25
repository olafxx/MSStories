using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSStories.Model.Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new ArticleFactoryContext().Create();
        }
    }
}
