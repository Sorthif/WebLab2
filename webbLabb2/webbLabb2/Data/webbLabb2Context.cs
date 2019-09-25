using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webbLabb2.Models
{
    public class webbLabb2Context : DbContext
    {
        public webbLabb2Context (DbContextOptions<webbLabb2Context> options)
            : base(options)
        {
        }
        public webbLabb2Context()
            : base()
        {
        }

        public DbSet<webbLabb2.Models.Article> Article { get; set; }

    }
}
