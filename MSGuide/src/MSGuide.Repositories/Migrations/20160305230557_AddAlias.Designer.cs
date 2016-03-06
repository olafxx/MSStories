using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MSGuide.Repositories.Models;

namespace MSGuide.Repositories.Migrations
{
    [DbContext(typeof(ArticleContext))]
    [Migration("20160305230557_AddAlias")]
    partial class AddAlias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSGuide.Repositories.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Header");

                    b.Property<DateTime>("PubDate");

                    b.Property<string>("Text");

                    b.Property<int>("WriterId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSGuide.Repositories.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MSGuide.Repositories.Models.Article", b =>
                {
                    b.HasOne("MSGuide.Repositories.Models.Writer")
                        .WithMany()
                        .HasForeignKey("WriterId");
                });
        }
    }
}
