using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakegame
{
    [Serializable]
    class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
            
        }
        public void SetPosition()
        {
            int x = (new Random().Next())% 40;
            int y = (new Random().Next())% 40;
            if (body.Count == 0)
                body.Add(new Point(x, y));
            else {
                body[0].x = x;
                body[0].y = y;
            }
        }
        public bool foodInSnake()
        {
            foreach (Point p in Game.snake.body)
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            return false;
        }
        public bool foodInWall()
        {
            foreach (Point p in Game.wall.body)
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            return false;
        }
    }
}
