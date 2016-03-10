using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MSStories.Repositories.Models;

namespace MSStories.Repositories.Migrations
{
    [DbContext(typeof(ArticleContext))]
    partial class ArticleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSStories.Repositories.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Header");

                    b.Property<DateTime>("PubDate");

                    b.Property<string>("Text");

                    b.Property<int>("WriterId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSStories.Repositories.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSStories.Repositories.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSStories.Repositories.Models.Article", b =>
                {
                    b.HasOne("MSStories.Repositories.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("MSStories.Repositories.Models.Writer")
                        .WithMany()
                        .HasForeignKey("WriterId");
                });
        }
    }
}
