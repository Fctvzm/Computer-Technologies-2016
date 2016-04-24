using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakegame
{
    [Serializable]
    class Snake : Drawer
    {
        public Snake()
        {
            color = ConsoleColor.White;
            sign = 'o';
        }

        /*public override void Draw()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                    color = ConsoleColor.Red;
                else 
                    color = ConsoleColor.White;
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }*/
        public int score = 0;
        public void move(int dx, int dy)
        {
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.Write(" ");

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

         

            if (body[0].x == Game.food.body[0].x &&
                body[0].y == Game.food.body[0].y)
            {
                score++;
                Game.food.SetPosition();
                body.Add(new Point(Game.food.body[0].x, Game.food.body[0].y));
            }
            CollisionWithConsoleWindow();


        }
        public void CollisionWithConsoleWindow()
        {
            if (body[0].x > Console.WindowWidth) body[0].x = 0;
            if (body[0].y > Console.WindowHeight) body[0].y = 0;
            if (body[0].x < 0) body[0].x = Console.WindowWidth;
            if (body[0].y < 0) body[0].y = Console.WindowHeight;
        }
        public bool collisionWithWall()
        {
            foreach (Point p in Game.wall.body)
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            return false;
        }
        public bool collisionWithSnake()
        {
            for (int i=4; i<body.Count; i++)
                if (body[i].x == body[0].x && body[i].y == body[0].y)
                    return true;
            return false;
        }
    }
}
