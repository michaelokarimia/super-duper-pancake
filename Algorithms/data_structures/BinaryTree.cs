namespace Algorithms.data_structures
{
    namespace data_structures
    {
        public class BinaryTree
        {
            private int _value;

            public BinaryTree(int val)
            {
                Value = val;
            }

            public BinaryTree Left { get; set; }
            public BinaryTree Right { get; set; }
            public int Value { get => _value; private set => _value = value; }

            public BinaryTree AddLeft(int value)
            {
                var newTree = new BinaryTree(value);
                Left = newTree;
                return newTree;

            }

            public BinaryTree AddRight(int value)
            {
                var newTree = new BinaryTree(value);
                Right = newTree;
                return newTree;
            }

            public override string ToString()
            {
                var str = string.Format("\nValue: {0}, Left: {1}, Right: {2}",_value, Left, Right );

                return str;
            }
        }
    }
}
