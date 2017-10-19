using Algorithms.data_structures;
using Algorithms.data_structures.data_structures;
using System;

namespace Algorithms
{
    internal class ExecutivePay
    {
        static int leftSum = 0;
        static int rightSum = 0;

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
        
        }

        private static void stackSalaryReportImplementation(BinaryTree node)
        {
            var stack = new Stack();

            stack.Push(node);

            while(stack.Count > 0)
            {
                BinaryTree currentNode = (BinaryTree)stack.Pop();
                Console.WriteLine(currentNode.Value);
                if(currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if(currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }


        }

        private static void postOrderTraversalSalaryReport(BinaryTree node)
        {
            if(node!=null)
            {
                postOrderTraversalSalaryReport(node.Left);
                postOrderTraversalSalaryReport(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        public static void inOrderTraversal(BinaryTree node)
        {
            if(node != null)
            {
                inOrderTraversal(node.Left);
                Console.WriteLine(node.Value);
                inOrderTraversal(node.Right);
            }
        }

        private static void preOrderTraversalSalaryReport(BinaryTree node)
        {
            if(node != null)
            {
                Console.WriteLine(node.Value);
                preOrderTraversalSalaryReport(node.Left);
                preOrderTraversalSalaryReport(node.Right);
            }
        }

        private static void printLeftRightSalaries(BinaryTree root)
        {
            leftSum = 0;
            rightSum = 0;
            calcRightVsLeftSalaries(root);
            Console.WriteLine("LeftSum: {0}, RightSum: {1}", leftSum, rightSum);
        }

        private static void calcRightVsLeftSalaries(BinaryTree node)
        {
            if(node.Left != null)
            {
                leftSum += (int)node.Left.Value;
                calcRightVsLeftSalaries(node.Left);
            }

            if (node.Right != null)
            {
                rightSum += (int)node.Right.Value;
                calcRightVsLeftSalaries(node.Right);
            }
        }

        private static void depthFirstSearch(BinaryTree node)
        {
            if(node !=null)
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
    }
}