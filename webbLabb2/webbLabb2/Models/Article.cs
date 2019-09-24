using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webbLabb2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MarkupText { get; set; }


        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
