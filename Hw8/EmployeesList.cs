using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hw8
{
    public class EmployeesList:List<Employee>
    {
        public void OrderByMultuplyFields(string[] fields)
        {
            this.Sort((a, b) => 
                CompareRecursively(a, b, fields));
        }

        private int CompareRecursively(Employee employee1, Employee employee2, string[] fields, int i=0)
        {
            var emp1Fld = (IComparable) employee1[fields[i]];
            var emp2Fld = (IComparable) employee2[fields[i]];

            int res = emp1Fld.CompareTo(emp2Fld);

            return res != 0||i==fields.Length-1 ? res : CompareRecursively(employee1, employee2, fields, i+1);

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.AppendLine($"{i + 1} {this[i]}");
            }

            return stringBuilder.ToString();
        }
    }
}