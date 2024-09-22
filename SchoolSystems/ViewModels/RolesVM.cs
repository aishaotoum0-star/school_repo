using SchoolSystems.Models;
using System.Collections.Generic;

namespace SchoolSystems.ViewModels
{
    public class RolesVM
    {
        public Roles Roles { get; set; }
        public IList<Roles> ListRoles { get; set; }
    }
}
