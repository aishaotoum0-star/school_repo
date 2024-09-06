using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class BranchRepository : IRepository<Branch>
    {
        List<Branch> lstBranches;
        public BranchRepository()
        {
            lstBranches=new List<Branch> 
            {
                new Branch{BranchId=1,BranchName="Amman",BranchCtg="test" },
                new Branch{BranchId=2,BranchName="Doubi",BranchCtg="test" },
                new Branch{BranchId=3,BranchName="Alquds",BranchCtg="test" },
                new Branch{BranchId=4,BranchName="Aqaba",BranchCtg="test" },
                new Branch{BranchId=5,BranchName="Ajman",BranchCtg="test" },
            };
        }
        public bool Add(Branch entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstBranches.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Branch entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstBranches.Remove(entity);
                result = true;
            }
            return result;
        }

        public Branch Find(int id)
        {
            return lstBranches.Find(x => x.BranchId == id);
        }

        public bool Update(int id, Branch entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.BranchCtg = entity.BranchCtg;
                data.BranchName = entity.BranchName;
                result = true;
            }
            return result;
        }

        public IList<Branch> View()
        {
            return lstBranches.ToList();
        }
    }
}
