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

    public static void DrawBorder(int width, int height)
    {
        Console.Clear();
        for (int x = 0; x < width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("_");
            Console.SetCursorPosition(x, height - 1);
            Console.Write("-");
        }
        for (int y = 0; y < height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("|");
            Console.SetCursorPosition(width - 1, y);
            Console.Write("|");
        }
    }

    public static void Game(int level)
    {
        int width = 40;
        int height = 20;
        Point food;
        List<Point> snake = new List<Point>();
        Direction direction = Direction.Right;
        Random rand = new Random();
        int score = 0;

        food = new Point(rand.Next(1, width - 2), rand.Next(1, height - 2));

        snake.Add(new Point(12, 10));
        snake.Add(new Point(11, 10));
        snake.Add(new Point(10, 10));

        DateTime lastTime = DateTime.Now;
        while (true)
        {
            DrawBorder(width, height);

            foreach (Point s in snake)
            {
                Console.SetCursorPosition(s.X, s.Y);
                Console.Write("O");
            }

            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("*");

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        if (direction != Direction.Down)
                        {
                            direction = Direction.Up;
                        }
                        break;
                    case ConsoleKey.S:
                        if (direction != Direction.Up)
                        {
                            direction = Direction.Down;
                        }
                        break;
                    case ConsoleKey.A:
                        if (direction != Direction.Right)
                        {
                            direction = Direction.Left;
                        }
                        break;
                    case ConsoleKey.D:
                        if (direction != Direction.Left)
                        {

                            direction = Direction.Right;
                        }
                        break;
                }
            }
        }

        Console.SetCursorPosition(0, height = 1);
    }

    public static void Main(string[] args)
    {
        int choiceMenu = -1;
        Console.CursorVisible = false;

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
                    Game(level);
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