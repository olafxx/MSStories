using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSGuide.Repositories.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public DateTime PubDate { get; set; }
        public int? CategoryId { get; set; }
        public int WriterId { get; set; }

        public virtual Writer Writer { get; set; }
        public virtual Category Category { get; set; }
    }
}
