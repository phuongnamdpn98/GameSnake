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

        food = new Point(rand.Next(1, width - 1), rand.Next(1, height - 1));

        snake.Add(new Point(12, 10));
        snake.Add(new Point(11, 10));
        snake.Add(new Point(10, 10));

        DateTime lastMove = DateTime.Now;

        DrawBorder(width, height);

        while (true)
        {
            // vẽ rắn
            foreach (var s in snake)
            {
                Console.SetCursorPosition(s.X, s.Y);
                Console.Write("O");
            }

            // vẽ điểm ăn
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("*");

            // kiểm tra kí tự
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

            // di chuyển rắn theo thời gian
            if ((DateTime.Now - lastMove).TotalMilliseconds > level)
            {
                lastMove = DateTime.Now;

                // xóa đuôi rắn
                Point tail = snake[snake.Count - 1];
                Console.SetCursorPosition(tail.X, tail.Y);
                Console.Write(" ");
                snake.RemoveAt(snake.Count - 1);

                // thêm đầu rắn
                Point head = snake[0];
                Point newHead = head;

                switch (direction)
                {
                    case Direction.Up:
                        newHead.Y--;
                        break;
                    case Direction.Down:
                        newHead.Y++;
                        break;
                    case Direction.Left:
                        newHead.X--;
                        break;
                    case Direction.Right:
                        newHead.X++;
                        break;
                }

                // kiểm tra va chạm với biên và thân rắn
                if (newHead.X == 0 || newHead.X == width - 1
                    || newHead.Y == 0 || newHead.Y == height - 1
                    || snake.Any(s => s.X == newHead.X && s.Y == newHead.Y))
                {
                    Console.SetCursorPosition(width / 2 - 5, height / 2);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(width / 2 - 5, height / 2 + 1);
                    Console.WriteLine("Your score: " + score);
                    Console.SetCursorPosition(width / 2 - 12, height / 2 + 2);
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                snake.Insert(0, newHead);

                // kiểm tra ăn điểm và tăng độ dài rắn
                if (newHead.X == food.X && newHead.Y == food.Y)
                {
                    score++;
                    snake.Add(tail);
                    food = new Point(rand.Next(1, width - 1), rand.Next(1, height - 1));
                }

                Thread.Sleep(1);
                Console.SetCursorPosition(0, height + 1);
                Console.WriteLine("Score: " + score);
            }

        }
        Console.SetCursorPosition(0, height + 1);
        
    }

    public static void Main()
    {
        int choiceMenu = -1;
        Console.CursorVisible = false;

        while (true)
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
                            level = 250;
                            break;
                        case 2:
                            Console.WriteLine("Starting Medium level...");
                            level = 150;
                            break;
                        case 3:
                            Console.WriteLine("Starting Hard level...");
                            level = 50;
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
        }
    }
}