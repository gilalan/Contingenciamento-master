using System;
using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Department(long id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public Department(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public Department()
        {

        }
    }

    class DepartmentComparer : IEqualityComparer<Department>
    {
        public bool Equals(Department x, Department y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            if (String.IsNullOrEmpty(x.Code) && String.IsNullOrEmpty(y.Code))
            {
                return x.Name == y.Name;
            }
            else
            {
                return x.Code == y.Code;
            }
        }

        public int GetHashCode(Department obj)
        {
            // Stores the result.
            //int result = 0;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            } else
            {
                return obj.Code.GetHashCode();
            }
        }
    }
}