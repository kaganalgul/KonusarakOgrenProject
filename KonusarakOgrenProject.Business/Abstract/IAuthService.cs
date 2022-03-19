using KonusarakOgrenProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Business.Abstract
{
    public interface IAuthService
    {
        public User Login(string username, string password);

        public void Register(string username, string password);
    }
}
