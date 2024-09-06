using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        List<User> lstUsers;
        public UserRepository()
        {
            lstUsers = new List<User>
            {
                new User{UserId=1,UserName="Ahmmed",UserEmail="Ahmmed@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=2,UserName="Abdallah",UserEmail="Abdallah@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=3,UserName="Ibrahim",UserEmail="Ibrahim@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=4,UserName="Waleed",UserEmail="Waleed@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=5,UserName="Khalid",UserEmail="Khalid@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=6,UserName="Atef",UserEmail="Atef@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
                new User{UserId=7,UserName="Zaid",UserEmail="Zaid@gmail.com",UserPhone="0786352551",UserImageURL="Users.png" },
            };
        }
        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstUsers.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, User entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstUsers.Remove(entity);
                result = true;
            }
            return result;
        }

        public User Find(int id)
        {
            return lstUsers.Find(x => x.UserId == id);
        }

        public bool Update(int id, User entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.UserName = entity.UserName;
                data.UserEmail = entity.UserEmail;
                data.UserPhone = entity.UserPhone;
                data.UserImageURL = entity.UserImageURL;
                result = true;
            }
            return result;
        }

        public IList<User> View()
        {
            return lstUsers.ToList();
        }
    }
}
