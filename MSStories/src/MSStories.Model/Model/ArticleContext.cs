using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public DbSet<Article> Articles { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
