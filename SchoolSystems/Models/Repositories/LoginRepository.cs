using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class LoginRepository : IRepository<Login>
    {
        List<Login> listLogin;
        public LoginRepository()
        {
            listLogin = new List<Login>
            {
                new Login{LoginId=1,LoginUserName="Yazan_",LoginPassword="test123",UserId=1,RoleId=5 },
                new Login{LoginId=2,LoginUserName="Abood_",LoginPassword="test123",UserId=2,RoleId=4 },
                new Login{LoginId=3,LoginUserName="Walled_",LoginPassword="test123",UserId=3,RoleId=3 },
                new Login{LoginId=4,LoginUserName="Khaled_",LoginPassword="test123",UserId=4,RoleId=2 },
                new Login{LoginId=5,LoginUserName="Bhaa_",LoginPassword="test123",UserId=5,RoleId=1 },
            };
        }
        public bool Add(Login entity)
        {
            bool result = false;
            if (entity != null)
            {
                listLogin.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Login entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                listLogin.Remove(entity);
                result = true;
            }
            return result;
        }

        public Login Find(int id)
        {
            return listLogin.Find(x => x.LoginId == id);
        }

        public bool Update(int id, Login entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.LoginUserName = entity.LoginUserName;
                data.LoginPassword = entity.LoginPassword;
                data.UserId = entity.UserId;
                data.RoleId = entity.RoleId;
                result = true;
            }
            return result;
        }

        public IList<Login> View()
        {
            return listLogin.ToList();
        }
    }
}
