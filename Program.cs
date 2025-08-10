public class Program
{

    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    enum Direction
    {
        Up, Down, Left, Right
    }
    public static void Main(string[] args)
    {
        int choiceMenu = -1;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Start Game Snake");
            Console.WriteLine("0. Exit");
            Console.Write("Please select an option: ");
            choiceMenu = Convert.ToInt32(Console.ReadLine());
            switch (choiceMenu)
            {
                case 1:
                    int choiceLevel = -1;
                    int level = 0;
                    Console.WriteLine("Select Level:");
                    Console.WriteLine("1. Easy");
                    Console.WriteLine("2. Normal");
                    Console.WriteLine("3. Hard");
                    Console.Write("Please select a level: ");
                    choiceLevel = Convert.ToInt32(Console.ReadLine());
                    switch (choiceLevel)
                    {
                        case 1:
                            Console.WriteLine("Starting Easy level...");
                            level = 100;
                            break;
                        case 2:
                            Console.WriteLine("Starting Medium level...");
                            level = 150;
                            break;
                        case 3:
                            Console.WriteLine("Starting Hard level...");
                            level = 200;
                            break;
                        default:
                            Console.WriteLine("Invalid level selected. Please try again.");
                            break;
                    }


                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choiceMenu != 1);

    }
}