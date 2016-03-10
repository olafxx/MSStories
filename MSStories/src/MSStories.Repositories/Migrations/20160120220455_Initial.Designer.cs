using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MSStories.Models;
using MSStories.Repositories.Models;

namespace MSStories.Repositories.Migrations
{
    [DbContext(typeof(ArticleContext))]
    [Migration("20160120220455_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSStories.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Header");

                    b.Property<DateTime>("PubDate");

                    b.Property<string>("Text");

                    b.Property<int>("WriterId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSStories.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSStories.Models.Article", b =>
                {
                    b.HasOne("MSStories.Models.Writer")
                        .WithMany()
                        .HasForeignKey("WriterId");
                });
        }
    }
}
