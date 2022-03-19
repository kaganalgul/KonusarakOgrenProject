using KonusarakOgrenProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Concrete
{
    public class User : BaseEntity, IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
