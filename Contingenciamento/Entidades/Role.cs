using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Role
    {
        public long Id { get; set; }
        public string CBOCode { get; set; }
        public string Name { get; set; }

        public Role(long id, string cBOCode, string name)
        {
            Id = id;
            CBOCode = cBOCode;
            Name = name;
        }

        public Role(string name)
        {
            Name = name;
        }

        public Role()
        {

        }
    }

    class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals(Role x, Role y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            if (String.IsNullOrEmpty(x.CBOCode) && String.IsNullOrEmpty(y.CBOCode))
            {
                return x.Name == y.Name;
            }
            else
            {
                return x.CBOCode == y.CBOCode;
            }
        }

        public int GetHashCode(Role obj)
        {
            // Stores the result.
            int code = obj.Name.GetHashCode();
            //int result = 0;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return code;
        }
    }
}
