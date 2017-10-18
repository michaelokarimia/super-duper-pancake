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
                if(currentNode.RightTree != null)
                {
                    stack.Push(currentNode.RightTree);
                }
                if(currentNode.LeftTree != null)
                {
                    stack.Push(currentNode.LeftTree);
                }
            }


        }

        private static void postOrderTraversalSalaryReport(BinaryTree node)
        {
            if(node!=null)
            {
                postOrderTraversalSalaryReport(node.LeftTree);
                postOrderTraversalSalaryReport(node.RightTree);
                Console.WriteLine(node.Value);
            }
        }

        private static void inOrderTraversalSalaryReport(BinaryTree node)
        {
            if(node != null)
            {
                inOrderTraversalSalaryReport(node.LeftTree);
                Console.WriteLine(node.Value);
                inOrderTraversalSalaryReport(node.RightTree);
            }
        }

        private static void preOrderTraversalSalaryReport(BinaryTree node)
        {
            if(node != null)
            {
                Console.WriteLine(node.Value);
                preOrderTraversalSalaryReport(node.LeftTree);
                preOrderTraversalSalaryReport(node.RightTree);
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
            if(node.LeftTree != null)
            {
                leftSum += node.LeftTree.Value;
                calcRightVsLeftSalaries(node.LeftTree);
            }

            if (node.RightTree != null)
            {
                rightSum += node.RightTree.Value;
                calcRightVsLeftSalaries(node.RightTree);
            }
        }

        private static void depthFirstSearch(BinaryTree node)
        {
            if(node !=null)
            {
                Console.WriteLine(node);
                depthFirstSearch(node.LeftTree);
                depthFirstSearch(node.RightTree);

            }
        }

        private static BinaryTree buildPayTree()
        {
            var ceo = new BinaryTree(1000);

            var pres = ceo.AddLeft(500);
            var coo = ceo.AddRight(500);

            var vpOfToys = pres.AddRight(450);
            vpOfToys.AddLeft(250);
            vpOfToys.AddRight(280);

            var vpOfLuck = pres.AddLeft(400);
            vpOfLuck.AddLeft(220);
            vpOfLuck.AddRight(260);

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