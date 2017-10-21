using Algorithms.data_structures;
using Algorithms.data_structures.data_structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    internal class ExecutivePay
    {
        static int _leftSum = 0;
        static int _rightSum = 0;

        internal static void Run()
        {
            BinaryTree ceo = buildPayTree();

            Console.WriteLine("PreOrderTraversal");
            preOrderTraversalSalaryReport(ceo);
            Console.WriteLine("InOrderTraversal");
            inOrderTraversal(ceo);
            Console.WriteLine("PostOrderTraversal");
            postOrderTraversalSalaryReport(ceo);

            Console.WriteLine("StackImplemention");
            stackSalaryReportImplementation(ceo);

            Console.WriteLine("Breadth First Traversal");
            queueBreadthFirstSearchTraversal(ceo);


            CheckForSymmetricCorporateStructure();



        }

        private static void CheckForSymmetricCorporateStructure()
        {
            var newCorporateStructure = BuildRevisedCorporateStructure();

            Console.WriteLine("Is Binary Tree Symmetrical? {0}", isBinarySearchTreeIsSymetrical(newCorporateStructure) ? "Yes" : "No");
        }

        private static bool isBinarySearchTreeIsSymetrical(BinaryTree ceo)
        {
            Queue q = new Queue();

            //start with first two nodes
            q.Enqueue(ceo.Left);
            q.Enqueue(ceo.Right);

            while (q.count > 0)
            {
                var left = (BinaryTree)q.Dequeue();
                var right = (BinaryTree)q.Dequeue();

                if (left.Value != right.Value)
                {
                    return false;
                }

                //add the outside nodes to the queue one after each other in order to compare them next

                if (left.Left != null)
                {
                    q.Enqueue(left.Left);
                }

                if (right.Right != null)
                {
                    q.Enqueue(right.Right);
                }

                //then enqueue the inner two nodes for comparison

                if (left.Right != null)
                {
                    q.Enqueue(left.Right);
                }

                if (right.Left != null)
                {
                    q.Enqueue(right.Left);
                }


            }

            return true;
        }

        private static void queueBreadthFirstSearchTraversal(BinaryTree ceo)
        {
            var q = new Queue();

            q.Enqueue(ceo);

            while (q.count > 0)
            {
                BinaryTree currentNode = (BinaryTree)q.Dequeue();
                Console.WriteLine(currentNode.Value);

                if (currentNode.Left != null)
                {
                    q.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    q.Enqueue(currentNode.Right);
                }
            }

        }

        private static void stackSalaryReportImplementation(BinaryTree node)
        {
            var stack = new Stack();

            stack.Push(node);

            while (stack.Count > 0)
            {
                BinaryTree currentNode = (BinaryTree)stack.Pop();
                Console.WriteLine(currentNode.Value);
                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }


        }

        private static void postOrderTraversalSalaryReport(BinaryTree node)
        {
            if (node != null)
            {
                postOrderTraversalSalaryReport(node.Left);
                postOrderTraversalSalaryReport(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        public static void inOrderTraversal(BinaryTree node)
        {
            if (node != null)
            {
                inOrderTraversal(node.Left);
                Console.WriteLine(node.Value);
                inOrderTraversal(node.Right);
            }
        }

        private static void preOrderTraversalSalaryReport(BinaryTree node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                preOrderTraversalSalaryReport(node.Left);
                preOrderTraversalSalaryReport(node.Right);
            }
        }

        private static void printLeftRightSalaries(BinaryTree root)
        {
            _leftSum = 0;
            _rightSum = 0;
            calcRightVsLeftSalaries(root);
            Console.WriteLine("LeftSum: {0}, RightSum: {1}", _leftSum, _rightSum);
        }

        private static void calcRightVsLeftSalaries(BinaryTree node)
        {
            if (node.Left != null)
            {
                _leftSum += (int)node.Left.Value;
                calcRightVsLeftSalaries(node.Left);
            }

            if (node.Right != null)
            {
                _rightSum += (int)node.Right.Value;
                calcRightVsLeftSalaries(node.Right);
            }
        }

        private static void depthFirstSearch(BinaryTree node)
        {
            if (node != null)
            {
                Console.WriteLine(node);
                depthFirstSearch(node.Left);
                depthFirstSearch(node.Right);

            }
        }

        private static BinaryTree buildPayTree()
        {
            var ceo = new BinaryTree(1000);

            var pres = ceo.AddLeft(500);
            var coo = ceo.AddRight(500);

            var vpOfLuck = pres.AddLeft(400);
            vpOfLuck.AddLeft(220);
            vpOfLuck.AddRight(260);

            var vpOfToys = pres.AddRight(450);
            vpOfToys.AddLeft(250);
            vpOfToys.AddRight(280);

            var vpOfMeetings = coo.AddLeft(380);
            vpOfMeetings.AddLeft(210);
            vpOfMeetings.AddRight(220);

            var vpOfVPs = coo.AddRight(350);
            vpOfVPs.AddLeft(230);
            vpOfVPs.AddRight(240);

            return ceo;
        }

        private static BinaryTree BuildRevisedCorporateStructure()
        {
            var ceo = new BinaryTree(1000);

            var pres = ceo.AddLeft(500);
            var coo = ceo.AddRight(500);

            var vpOfLuck = pres.AddLeft(350);
            vpOfLuck.AddLeft(250);
            vpOfLuck.AddRight(220);

            var vpOfToys = pres.AddRight(400);
            vpOfToys.AddLeft(220);
            vpOfToys.AddRight(220);

            var vpOfMeetings = coo.AddLeft(400);
            vpOfMeetings.AddLeft(220);
            vpOfMeetings.AddRight(220);

            var vpOfVPs = coo.AddRight(350);
            vpOfVPs.AddLeft(220);
            vpOfVPs.AddRight(250);

            return ceo;
        }

    }
}