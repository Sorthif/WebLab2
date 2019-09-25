using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace webbLabb2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new webbLabb2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<webbLabb2Context>>()))
            {
                //Clear the database for testing
                //context.Database.ExecuteSqlCommand("delete * from dbo.Article");
                List<Article> list = context.Article.FromSql<Article>("select * from dbo.Article").ToList();
                //Get all the JSON files in the json folder
                List<string> fileNames = new List<string>();
                List<string> tempFileNames = new List<string>();
                tempFileNames.AddRange(Directory.GetFiles("wwwroot/json/"));
                foreach(var fn in tempFileNames)
                {
                    if (fn.Contains(".json"))
                    {
                        fileNames.Add(fn);
                    }
                }

                //READ THE ARTICLES FROM FILE AND ADD THEM TO THE "Article class"
                foreach (string fn in fileNames)
                {
                    string json;
                    json = File.ReadAllText(fn);
                    dynamic obj = JsonConvert.DeserializeObject(json);
                    foreach (var news in obj.news)
                    {
                        var a = new Article
                        {
                            ImageUrl = news.imgurl,
                            MarkupText = news.content,
                            PublishDate = DateTime.Today,
                            Title = news.title
                        };
                        if (!list.Contains(a))
                                context.Add(a);
                    }
                }
                
                context.SaveChanges();
            }
        }
    }
}