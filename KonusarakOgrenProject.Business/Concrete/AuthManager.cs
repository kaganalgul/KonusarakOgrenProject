using KonusarakOgrenProject.Business.Abstract;
using KonusarakOgrenProject.Business.PasswordEndDec;
using KonusarakOgrenProject.DataAccess.Data;
using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly DatabaseContext _db;
        public AuthManager(DatabaseContext db)
        {
            _db = db;
        }

        public User Login(string username, string password)
        {
            password = PasswordEncDec.ConvertToDecrypt(password);
            User user = _db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void Register(string username, string password)
        {
            User createdUser = new User();
            createdUser.Username = username;
            createdUser.Password = PasswordEncDec.ConvertToEncrypt(password);

            _db.Users.Add(createdUser);
            _db.SaveChanges();
        }

    }
}
