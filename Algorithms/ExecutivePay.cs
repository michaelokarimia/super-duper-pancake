using Algorithms.data_structures.data_structures;
using System;

namespace Algorithms
{
    internal class ExecutivePay
    {
        internal static void Run()
        {
            BinaryTree root = buildPayTree();

            depthFirstSearch(root);
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
            vpOfToys.AddLeft(220);
            vpOfToys.AddRight(260);

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