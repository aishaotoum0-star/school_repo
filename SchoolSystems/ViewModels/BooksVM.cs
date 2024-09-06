using Microsoft.AspNetCore.Http;

namespace SchoolSystems.ViewModels
{
    public class BooksVM
    {
        public int BooksId { get; set; }
        public string BookName { get; set; }
        public double BooksPrice { get; set; }
        public string AuthorName { get; set; }
        public double BookBrnPrice { get; set; }
        public string BookImgeUrl { get; set; }
        public string AuthorImgeUrl { get; set; }
        public IFormFile AuthorFile { get; set; }
        public IFormFile BookFile { get; set; }
    }
}
