using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class RolesRepository : IRepository<Roles>
    {
        List<Roles> lstRoles;
        public RolesRepository()
        {
            lstRoles=new List<Roles>
            { 
                new Roles{RolesId=1,RolesName="SuperAdmin",RolesIvI="" },
                new Roles{RolesId=2,RolesName="Admin",RolesIvI="" },
                new Roles{RolesId=3,RolesName="Manager",RolesIvI="" },
                new Roles{RolesId=4,RolesName="User",RolesIvI="" },
                new Roles{RolesId=5,RolesName="Student",RolesIvI="" },
            };
        }
        public bool Add(Roles entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstRoles.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Roles entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstRoles.Remove(entity);
                result = true;
            }
            return result;
        }

        public Roles Find(int id)
        {
            return lstRoles.Find(x => x.RolesId == id);
        }

        public bool Update(int id, Roles entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.RolesName = entity.RolesName;
                data.RolesIvI = entity.RolesIvI;
                result = true;
            }
            return result;
        }

        public IList<Roles> View()
        {
            return lstRoles.ToList();
        }
    }
}
