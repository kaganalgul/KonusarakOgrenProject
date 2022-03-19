using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgrenProject.Entity.Abstract
{
    public interface IUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
