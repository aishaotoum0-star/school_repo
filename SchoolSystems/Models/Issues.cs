using System;

namespace SchoolSystems.Models
{
    public class Issues
    {
        public int IssuesId { get; set; }
        public int StudentId { get; set; }
        public int BooksId { get; set; }
        public DateTime IssuesDate { get; set; }
        public Books Books { get; set; }
        public Student Student { get; set; }
    }
}
