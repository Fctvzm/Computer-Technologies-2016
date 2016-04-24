using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snakegame
{
    [Serializable]
    class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();
        public virtual void Draw ()
        {
            foreach (Point p in body) 
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        public void Save()
        {
            string fileName = "";
            if (sign == '$')
                fileName = "food.ser";
            if (sign == 'o')
                fileName = "snake.ser";
            if (sign == '#')
                fileName = "wall.ser";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            bf.Serialize(fs, this);

            fs.Close();
        }
        public void Resume()
        {
            string fileName = "";
            if (sign == '$')
                fileName = "food.ser";
            if (sign == 'o')
                fileName = "snake.ser";
            if (sign == '#')
                fileName = "wall.ser";
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                if (sign == '$')
                    Game.food = bf.Deserialize(fs) as Food;
                if (sign == '#')
                    Game.wall = bf.Deserialize(fs) as Wall;

                if (sign == 'o')
                    Game.snake = bf.Deserialize(fs) as Snake;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }


    }
}
