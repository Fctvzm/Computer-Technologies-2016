using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakegame
{
    class Game
    {
        public static Food food = new Food();
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public enum Direction { up, down, left, right};
        public static Direction direction=Direction.up;
        public static bool gameOver = false;
        public static int speed = 150;

        public Game()
        {
            Console.SetWindowSize(70, 40);
            food.SetPosition();
            wall.Loadlevel(1);
            snake.body.Add(new Point(10, 10));
            snake.body.Add(new Point(10, 9));
            snake.body.Add(new Point(10, 8));

            //Thread t = new Thread(moveSnake);
            //t.IsBackground = true;
            //t.Start();

            Timer t = new Timer(moveSnake);
            t.Change(0, 150);
            
            bool left,right,up,down;
            left = right = up = down = false;
            int cnt = 2;
            while (!gameOver)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(30, 0);
                Console.Write("Score: {0}",snake.score);
                Console.SetCursorPosition(30, 1);
                Console.Write("Speed: {0}",speed);

                if (food.foodInSnake() && food.foodInWall())
                {
                    food.body.Clear();
                    food.SetPosition();
                }
                if (snake.score == 2)
                {
                    if (cnt == 4)
                    {
                        break;
                        Console.Clear();
                    }
                    Console.Clear();
                    wall.Loadlevel(cnt);
                    snake.score = 0;
                    cnt++;
                    
                }


                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!down) 
                            direction = Direction.up;
                        up = true;
                        left = right = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (!up)
                            direction = Direction.down;
                        down = true;
                        left = right = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (!right)
                            direction = Direction.left;
                        left = true;
                        down = up = false;
                        break;
                    case ConsoleKey.RightArrow:
                        if (!left)
                            direction = Direction.right;
                        right = true;
                        down = up = false;
                        break;
                    case ConsoleKey.F2:
                        Save();
                        break;
                    case ConsoleKey.F3:
                        Resume();
                        break;
                }
                if (snake.collisionWithSnake() || snake.collisionWithWall())
                    gameOver = true;
            }
            GameOver();
        }
        public static void Draw ()
        {
            food.Draw();
            snake.Draw();
            wall.Draw();
        }
        
        public static void moveSnake (object state)
        {
            //if (snake.body.Count % 4 == 0)
            //    speed -= 25;
           
            if (!gameOver)
            {
                switch (direction)
                {
                    case Direction.up:
                        Game.snake.move(0, -1);
                        break;
                    case Direction.down:
                        Game.snake.move(0, 1);
                        break;
                    case Direction.left:
                        Game.snake.move(-1, 0);
                        break;
                    case Direction.right:
                        Game.snake.move(1, 0);
                        break;
                }
                Draw();
                //Thread.Sleep(speed);
                if (snake.collisionWithSnake() || snake.collisionWithWall())
                    gameOver = true;
            }
            //GameOver();
        }
        public static void GameOver ()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
        public static void Resume()
        {
            snake.Resume();
            wall.Resume();
            food.Resume();
        }

        public static void Save()
        {
            snake.Save();
            wall.Save();
            food.Save();
        }
    }
}
