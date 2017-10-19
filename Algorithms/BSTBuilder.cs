using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.data_structures;

namespace Algorithms
{
    class BSTBuilder
    {
        internal static BinarySearchTree Build()
        {
            var list = getSortedListOfEmployeesByTheirSalaries();


            BinarySearchTree bst = new BinarySearchTree(list);

            return bst;
        }

        private static List<Employee> getSortedListOfEmployeesByTheirSalaries()
        {
            return new List<Employee>()
            {

                new Employee(){ user = "danz0", salary = 210},
                new Employee(){ user = "sampus", salary = 215},
                new Employee(){ user = "samllamam", salary = 220},
                new Employee(){ user = "akeela", salary = 230},
                new Employee(){ user = "dwonx", salary = 240},
                new Employee(){ user = "twixl", salary = 250},
                new Employee(){ user = "flerp", salary = 260},
                new Employee(){ user = "twitchx", salary = 280},
                new Employee(){ user = "dkkkskd2k", salary = 350},
                new Employee(){ user = "plenth", salary = 380},
                new Employee(){ user = "j0newa", salary = 400},
                new Employee(){ user = "kliffff", salary = 450},
                new Employee(){ user = "perplz", salary = 500},
                new Employee(){ user = "x", salary = 520},
                new Employee(){ user = "zed", salary = 1000},
            };
        }
    }
}
