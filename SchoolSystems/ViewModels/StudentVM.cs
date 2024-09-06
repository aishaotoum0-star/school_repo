using Microsoft.AspNetCore.Http;

namespace SchoolSystems.ViewModels
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
        public string StudentDob { get; set; }
        public string StudentImageURL { get; set; }
        public IFormFile File { get; set; }
    }
}
