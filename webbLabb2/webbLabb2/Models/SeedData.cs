using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Newtonsoft.Json;

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


                //READ THE ARTICLES FROM FILE AND ADD THEM TO THE "Article class"
                string json;
                json = System.IO.File.ReadAllText("wwwroot/json/Ass2News.json");
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
                    context.Add(a);
                }
                context.SaveChanges();
            }
        }
    }
}