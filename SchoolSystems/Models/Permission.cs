namespace SchoolSystems.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public int RolesId { get; set; }
        public string PermissionName { get; set; }
        public Roles Roles { get; set; }
    }
}
