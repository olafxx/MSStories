using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MSStories.Model;

namespace MSStories.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions options) :base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //foreach (var entity in builder.Model.GetEntityTypes())
            //{
            //    entity.Relational().TableName = entity.DisplayName();
            //}

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer(
        //            ConfigHelper.GetConnectionString(),
        //            options => options.EnableRetryOnFailure());
        //}


        public DbSet<Article> Articles { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
}
