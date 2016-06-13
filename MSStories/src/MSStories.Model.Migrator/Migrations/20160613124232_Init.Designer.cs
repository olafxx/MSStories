using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MSStories.Models;

namespace MSStories.Model.Migrator.Migrations
{
    [DbContext(typeof(ArticleContext))]
    [Migration("20160613124232_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSStories.Models.Article", b =>
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

                    b.HasIndex("CategoryId");

                    b.HasIndex("WriterId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MSStories.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MSStories.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("MSStories.Models.Article", b =>
                {
                    b.HasOne("MSStories.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("MSStories.Models.Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
