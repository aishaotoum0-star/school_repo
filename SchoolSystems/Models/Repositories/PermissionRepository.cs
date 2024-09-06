using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class PermissionRepository : IRepository<Permission>
    {
        List<Permission> listPermissions;
        public PermissionRepository()
        {
            listPermissions = new List<Permission>
            {
                new Permission{PermissionId=1,PermissionName="SuperAdmin",RolesId=1 },
                new Permission{PermissionId=2,PermissionName="Admin",RolesId=2 },
                new Permission{PermissionId=3,PermissionName="Manager",RolesId=3 },
                new Permission{PermissionId=4,PermissionName="User",RolesId=4 },
                new Permission{PermissionId=5,PermissionName="Student",RolesId=5 },
            };
        }
        public bool Add(Permission entity)
        {
            bool result = false;
            if (entity != null)
            {
                listPermissions.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Permission entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                listPermissions.Remove(entity);
                result = true;
            }
            return result;
        }

        public Permission Find(int id)
        {
            return listPermissions.Find(x => x.PermissionId == id);
        }

        public bool Update(int id, Permission entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.PermissionName = entity.PermissionName;
                data.RolesId = entity.RolesId;
                data.PermissionId = entity.PermissionId;
                result = true;
            }
            return result;
        }

        public IList<Permission> View()
        {
            return listPermissions.ToList();
        }
    }
}
