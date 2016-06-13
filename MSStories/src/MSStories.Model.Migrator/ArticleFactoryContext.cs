using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MSStories.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace MSStories.Model.Migrator
{
    public class ArticleFactoryContext : IDbContextFactory<ArticleContext>
    {
        public ArticleContext Create()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.Development.json").Build();//add config file with connection string
            var conectionString = config.GetConnectionString("DevConnectionString");
            var builder = new DbContextOptionsBuilder<ArticleContext>();
            builder.UseSqlServer(conectionString, b => b.MigrationsAssembly("MSStories.Model.Migrator"));
            return new ArticleContext(builder.Options);
        }
    }
}
