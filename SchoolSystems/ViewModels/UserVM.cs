using Microsoft.AspNetCore.Http;

namespace SchoolSystems.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserImageURL { get; set; }
        public IFormFile File { get; set; }
    }
}
