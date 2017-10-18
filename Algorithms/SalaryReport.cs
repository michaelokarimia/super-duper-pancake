using System;

namespace Algorithms
{
    internal class SalaryReport
    {
        //given a sorted list of employees with names and salaries, find the name of an employee with a given salary
        //Make the search a efficient as possible
    
        
        static Employee[] _employees;

        internal static void Run()
        {
            _employees = getSortedListOfSalaries();

            var employee = getUserBySalary(500);

            Console.WriteLine("Name: {0} , salary {1}", employee.user, employee.salary);

        }

        //use binary search tree to divide and conquer a sorted list
        private static Employee getUserBySalary(int target)
        {
            Employee result = null;

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

        private static Employee[] getSortedListOfSalaries()
        {
            return new Employee[]
            {
                new Employee(){ user = "danz0", salary = 210},
                new Employee(){ user = "sampus", salary = 220},
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