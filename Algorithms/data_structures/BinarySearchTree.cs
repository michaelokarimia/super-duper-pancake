using Algorithms.data_structures.data_structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.SalaryReport;

namespace Algorithms.data_structures
{
    public class BinarySearchTree
    {
        //accepts a list of objects to put into a tree
        public BinarySearchTree(List<Employee> list)
        {
            //sort the list

            list.Sort();

            itemList = list;
            //pass in the sorted list into BuildTree which should be able to create a balanced tree
            this.tree = BuildTree(list.ToArray(), 0, list.Count - 1);

        }


        public BinaryTree Append(Employee item)
        {
            itemList.Add(item);

            itemList.Sort();
            tree = BuildTree(itemList.ToArray(), 0, itemList.Count);
            return tree;
        }

        




        public List<Employee> itemList { get; private set; }
        public BinaryTree tree { get; private set; }

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

        public override string ToString()
        {
            return tree.ToString();
        }
    }
}
