using System;

namespace Algorithms.data_structures
{
    public struct Employee : IComparable<Employee>
    {
        public string user;
        public int salary;

        public Employee(string username, int pay)
        {
            user = username;
            salary = pay;
        }

        public int CompareTo(Employee other)
        {
            return this.salary.CompareTo(other.salary);
        }

    }
}