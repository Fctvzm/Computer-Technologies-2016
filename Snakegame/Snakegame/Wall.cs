using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snakegame
{
    [Serializable]
    class Wall : Drawer
    {
        public Wall()
        {
            color = ConsoleColor.Cyan;
            sign = '#';
        }
        public void Loadlevel(int level)
        {
            string fileName = string.Format(@"level{0}.txt", level);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string[] token = sr.ReadToEnd().Split('\n');
            body.Clear();

            for (int i = 0; i < token.Length; i++)
                for (int j = 0; j < token[i].Length; j++)
                    if (token[i][j] == '#')
                        body.Add(new Point(j,i));

            sr.Close();
            fs.Close();
        }
    }
}