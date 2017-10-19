using Algorithms.data_structures;
using Algorithms.data_structures.data_structures;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    internal partial class SalaryReport
    {
        //given a sorted list of employees with names and salaries, find the name of an employee with a given salary
        //Make the search a efficient as possible
    
        static Employee[] _employees;

        internal static void Run()
        {
            _employees = getSortedListOfEmployeesByTheirSalaries();

            var salaryTarget = 350;

            var employeeList = getUserBySalaryUsingDictionary(salaryTarget);

            Console.WriteLine("Employees with salary of {0}", salaryTarget);
            foreach (var employee in employeeList)
            {
                Console.WriteLine("Name: {0} , salary {1}", employee.user, employee.salary);
            }

        }

        internal static void BuildBalancedBinarySearchTree()
        {
            _employees = getSortedListOfEmployeesByTheirSalaries();

            var tree = BuildTree(_employees, 0, _employees.Length -1);

            Console.WriteLine(tree);

            Console.WriteLine("Traverse Balanced Binary tree using depth first in order method");

            ExecutivePay.inOrderTraversal(tree);
        }

        private static BinaryTree BuildTree(Employee[] list, int min, int max)
        {
            //root node needs to be in the middle of the array. 
            //get the middle item of our array, make that the root, then split the array into smaller chunks

            //there are no more elements to split so set the node to null
            if (max < min)
                return null;
            

            var middle = (max + min) / 2;

            var node = new BinaryTree(list[middle].salary);

            //set the left tree and it's children to store the first half of the array 

            node.Left = BuildTree(list, min, middle - 1);

            //set the right tree and it's children to contain all the array elements from mid point of array till the end

            node.Right = BuildTree(list, middle + 1, max);

            return node;
        }            

        private static List<Employee> getUserBySalaryUsingDictionary(int target)
        {
            List<Employee> matchingEmployeesList = new List<Employee>();

            // scan array once and add it to a dictionary O(n)

            var dict = new Dictionary<int, List<Employee>>();

            foreach(Employee emp in _employees)
            {
                if (dict.ContainsKey(emp.salary))
                {
                    //already an employee stored, so append the new one 
                    dict[emp.salary].Add(emp);
                }
                else
                {
                    //no employee with the salary so just add it as new
                    dict[emp.salary] = new List<Employee> { emp };
                }
            }


            // then lookup be salary key o(1) after wards

            if (dict.ContainsKey(target))
            { matchingEmployeesList = dict[target]; }

            return matchingEmployeesList;

        }

        //use binary search tree to divide and conquer a sorted list
        private static Employee getUserBySalaryBinarySearch(int target)
        {
            //time complexity O log (n)

            Employee result = new Employee();

            var max = _employees.Length - 1;
            var min = 0;

            bool found = false;

            while (!found)
            {
                var midpoint = min + (max - min) / 2;
                int current = _employees[midpoint].salary;
                if (current == target)
                {
                    found = true;
                    return _employees[midpoint];
                }
                if(current < target)
                {
                    min = midpoint + 1;
                }
                else
                {
                    max = midpoint - 1;
                }

                if(max < min)
                {
                    break;
                }
            }

            return result;
        }

        private static Employee[] getSortedListOfEmployeesByTheirSalaries()
        {
            return new Employee[]
            {
                new Employee("danz0", 210),
                new Employee("sampus", 220),
                new Employee("samllamam", 220),
                new Employee("akeela", 230),
                new Employee("dwonx", 240),
                new Employee("twixl", 250),
                new Employee("flerp", 260),
                new Employee("twitchx", 280),
                new Employee("dkkkskd2k", 350),
                new Employee("plenth", 380),
                new Employee("j0newa", 400),
                new Employee("kliffff", 450),
                new Employee("perplz", 500),
                new Employee("x", 520),
                new Employee("zed", 1000)
            };
        }
    }
}