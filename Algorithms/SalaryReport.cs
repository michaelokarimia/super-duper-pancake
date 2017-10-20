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
        //Want to return ALL matching employee names, not just the first
    
        internal static void RunDictionarySearch()
        {
            var employeesList = getSortedListOfEmployeesByTheirSalaries();

            var salaryTarget = 500;

            var matchingEmployeeList = getUserBySalaryUsingDictionary(employeesList, salaryTarget);

            Console.WriteLine("Employees with salary of {0}", salaryTarget);
            foreach (var employee in matchingEmployeeList)
            {
                Console.WriteLine("Name: {0}, salary {1}", employee, salaryTarget);
            }
        }

        public static void RunBinarySearch()
        {
            var employeesList = getSortedListOfEmployeesByTheirSalaries();

            var salaryTarget = 350;

            try
            {
                //drawback is that we can only return a single employee. Multiple 
                var employee = getUserBySalaryBinarySearch(employeesList, salaryTarget);

                Console.WriteLine("Employees with salary of {0}", salaryTarget);
                Console.WriteLine("Name: {0} , salary {1}", employee.user, employee.salary);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static void BuildBinarySearchTree()
        {
            var employees = getSortedListOfEmployeesByTheirSalaries();

            var tree = BuildTree(employees, 0, employees.Length -1);

            Console.WriteLine(tree);

            Console.WriteLine("Traverse Balanced Binary tree using depth first in order method");

            ExecutivePay.inOrderTraversal(tree);
        }

        //given a sorted list, create a binary tree of it
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

        private static List<string> getUserBySalaryUsingDictionary(Employee[] employeesList, int salaryTarget)
        {
            List<string> matchingEmployeesList = new List<string>();

            // scan array once and add it to a dictionary O(n)

            var allEmployeesDictionary = new Dictionary<int, List<string>>();

            foreach(Employee emp in employeesList)
            {
                if (allEmployeesDictionary.ContainsKey(emp.salary))
                {
                    //already an employee stored, so append name to the list of names
                    allEmployeesDictionary[emp.salary].Add(emp.user);              
                }
                else
                {
                    //no employee with the salary so just add it as new
                    allEmployeesDictionary.Add(emp.salary, new List<string> { emp.user });
                }
            }


            // then lookup be salary key o(1) after wards

            if (allEmployeesDictionary.ContainsKey(salaryTarget))
            { matchingEmployeesList = allEmployeesDictionary[salaryTarget]; }

            return matchingEmployeesList;

        }

        //use binary search to divide and conquer a sorted list
        private static Employee getUserBySalaryBinarySearch(Employee[] sortedListOfEmployees ,int target)
        {
            //time complexity O log (n)

            
            //employees is a sorted list of employees by their salary
            var max = sortedListOfEmployees.Length - 1;
            var min = 0;

            bool found = false;

            while (!found)
            {
                //pick a midpoint of the current array
                var midpoint = min + (max - min) / 2;
                int current = sortedListOfEmployees[midpoint].salary;
                //we have found the target return it
                if (current == target)
                {
                    found = true;
                    return sortedListOfEmployees[midpoint];
                }
                // target is not in the first half of our array, set the minimum to after the halfway mark
                if(current < target)
                {
                    min = midpoint + 1;
                }
                else
                {
                    //target is less than current, so it must exist in the first portion of the array ahead of current location. Move the search space to before current
                    max = midpoint - 1;
                }

                if(max < min)
                {
                    break;
                }
            }

            throw new Exception("Item not found in employee list");
        }

        private static Employee[] getSortedListOfEmployeesByTheirSalaries()
        {
            return new Employee[]
            {
                new Employee("danz0", 210), //0
                new Employee("sampus", 220), //1
                new Employee("samllamam", 220),//2
                new Employee("akeela", 230),//3
                new Employee("dwonx", 240),//4
                new Employee("twixl", 250),//5
                new Employee("flerp", 260),//6
                new Employee("twitchx", 280),//7
                new Employee("dkkkskd2k", 350),//8
                new Employee("plenth", 380),//9
                new Employee("j0newa", 400),//10
                new Employee("kliffff", 450),//11
                new Employee("perplz", 500),//12
                new Employee("x", 500),//13
                new Employee("zed", 1000)//14
            };
        }
    }
}