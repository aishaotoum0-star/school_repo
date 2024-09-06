namespace SchoolSystems.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
        public User User { get; set; }
        public Roles Roles { get; set; }


    }
}
