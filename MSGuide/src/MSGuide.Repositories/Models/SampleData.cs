﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using MSGuide.Repositories.Models;

namespace MSGuide.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ArticleContext>();
            context.Database.Migrate();
            if (!context.Articles.Any())
            {
                var vlad = context.Writers.Add(new Writer()
                {
                    Name = "Vlad",
                    Surname = "Priymak"
                }).Entity;
                var senin = context.Writers.Add(new Writer()
                {
                    Name = "Leo",
                    Surname = "Senin"
                }).Entity;

                context.Articles.AddRange(
                    new Article()
                    {
                        Header = "First article",
                        Text = "First article",
                        PubDate = DateTime.Now,
                        WriterId = vlad.Id
                    },
                    new Article()
                    {
                        Header = "Second article",
                        Text = "Second article",
                        PubDate = DateTime.Now,
                        WriterId = senin.Id
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
