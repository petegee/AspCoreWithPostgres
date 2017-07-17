using System;

namespace AspCoreWithPostgres
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
