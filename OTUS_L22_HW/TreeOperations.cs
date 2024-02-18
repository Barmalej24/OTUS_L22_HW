namespace OTUS_L22_HW
{
    public class TreeOperations
    {
        public static TreeNode GenerateTree(List<(string, int)> list)
        {
            var tree = new TreeNode();
            foreach (var element in list)
            {
                if (tree.Name == null)
                {
                    tree = new TreeNode()
                    {
                        Name = element.Item1,
                        Salary = element.Item2
                    };
                }
                else
                {
                    AddNode(tree, new TreeNode()
                    {
                        Name = element.Item1,
                        Salary = element.Item2
                    });
                }
            }

            return tree;
        }

        public static TreeNode InputTree()
        {
            TreeNode root = null;
            while (true)
            {
                var salaryToInt = false;
                var salary = 0;
                Console.WriteLine("Веддите Фамилию сотрудника:");
                var name = Console.ReadLine();

                if (name.Length == 0)
                {
                    break;
                }                

                while (!salaryToInt)
                {
                    Console.WriteLine("Введите размер зарплаты (целочисленное)");
                    salaryToInt = int.TryParse(Console.ReadLine(), out salary);
                }                                

                if (root == null)
                {
                    root = new TreeNode()
                    {
                        Name = name,
                        Salary = salary
                    };
                }
                else
                {
                    AddNode(root, new TreeNode()
                    {
                        Name = name,
                        Salary = salary
                    });
                }
            }

            return root;
        }
        
        public static void AddNode(TreeNode rootNode, TreeNode nodeToAdd)
        {
            if (nodeToAdd.Salary < rootNode.Salary)
            {
                if (rootNode.Left != null)
                {
                    AddNode(rootNode.Left, nodeToAdd);
                }
                else
                {
                    rootNode.Left = nodeToAdd;
                }
            }
            else
            {
                if (rootNode.Right != null)
                {
                    AddNode(rootNode.Right, nodeToAdd);
                }
                else
                {
                    rootNode.Right = nodeToAdd;
                }
            }
        }
        public static void MakeTreeTraverse(TreeNode originNode)
        {
            Console.WriteLine("Список сотрудников:");
            Traverse(originNode);
        }
        public static void Traverse(TreeNode originNode)
        {
            if (originNode.Left != null)
            {
                Traverse(originNode.Left);
            }
            Console.WriteLine($"{originNode.Name} - {originNode.Salary}");
            if (originNode.Right != null)
            {
                Traverse(originNode.Right);
            }
        }

        public static void FindNumber(TreeNode root)
        {
            Console.WriteLine("Введите размер зарплаты для поиска сотрудника:");
            var s = Console.ReadLine();
            int.TryParse(s, out int d);
            if (d == 0)
            {
                return;
            }

            var node = FindNode(root, d);
            if (node != null)
            {
                Console.WriteLine($"Найден: {node.Name} - {node.Salary}");
            }
            else
            {
                Console.WriteLine($"Такой сотрудник не найден");
            }
        }

        public static TreeNode FindNode(TreeNode root, int salary)
        {
            if (salary < root.Salary)
            {
                if (root.Left != null)
                {
                    return FindNode(root.Left, salary);
                }

                return null;
            }
            if (salary > root.Salary)
            {
                if (root.Right != null)
                {
                    return FindNode(root.Right, salary);
                }

                return null;
            }

            return root;
        }
    }
}
