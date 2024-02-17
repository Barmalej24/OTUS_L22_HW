using System.ComponentModel;

namespace OTUS_L22_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<(string, int)> { ("Petrov", 430), ("Kumov", 100), ("Ivanov", 420), ("Zimov", 660), ("Kupec", 590), ("Zuzev", 530), ("Melov", 620) };
            TreeNode tree = null;
            var result = false;

            while (!result)
            {
                Console.WriteLine("Выбери режим формирования дерева Ручной(r) или Автоматический(a)");
                char.TryParse(Console.ReadLine(), out char inputMenu1);

                switch (inputMenu1)
                {
                    case 'r':
                        tree = TreeOperations.InputTree();
                        break;
                    case 'a':
                        tree = TreeOperations.GenerateTree(list);
                        break;
                    default:
                        result = false; 
                        break;
                }
                if (tree != null)
                {
                    TreeOperations.TraverseTree(tree);
                    var result2 = false;
                    TreeOperations.FindNumber(tree);

                    do
                    {
                        Console.WriteLine("Выбери дальнейшее действие Поиск зарплаты(1) или Формирование нового дерева(0)");

                        if (!int.TryParse(Console.ReadLine(), out int inputMenu2))
                        {
                            inputMenu2 = -1;
                        }

                        switch (inputMenu2)
                        {
                            case 0:
                                result2 = true;
                                tree = null;
                                break;
                            case 1:
                                TreeOperations.FindNumber(tree);
                                break;
                            default:
                                result2 = false;
                                break;
                        }
                    }
                    while (!result2);
                }
            }
        }
    }
}
