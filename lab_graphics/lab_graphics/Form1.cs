using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_graphics
{
    public partial class Form1 : Form
    {
        Graphics myGraphics;
        Timer t = new Timer();
        int x=42, y=68, dx=10;
        public Form1()
        {
            InitializeComponent();
            myGraphics = this.CreateGraphics();
            t.Tick += new EventHandler(MoveObject);
            t.Start();
        }

        private void MoveObject(object sender, EventArgs e)
        {
            if (x + 25 > Width)
                dx = -10;
            else if (x < 0)
                dx = 10;

            x += dx;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] spaceShip = {
                new Point(390, 170),
                new Point(430, 200),
                new Point(430, 250),
                new Point(390, 280),
                new Point(350, 250),
                new Point(350, 200)
            };
            myGraphics.FillPolygon(Brushes.Yellow, spaceShip);

            myGraphics.FillEllipse(Brushes.White, x, y, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 55, 327, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 263, 51, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 420, 93, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 594, 170, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 267, 305, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 615, 378, 25, 25);
            myGraphics.FillEllipse(Brushes.White, 547, 250, 25, 25);

            Point[] gun = {
                new Point(390, 200),
                new Point(405, 225),
                new Point(395, 225),
                new Point(395, 250),
                new Point(385, 250),
                new Point(385, 225),
                new Point(375, 225)
            };
            myGraphics.FillPolygon(Brushes.Green, gun);

            Point[] bullet = {
                new Point(350, 125),
                new Point(365, 120),
                new Point(370, 105),
                new Point(375, 120),
                new Point(390, 125),
                new Point(375, 130),
                new Point(370, 145),
                new Point(365, 130),
            };
            myGraphics.FillPolygon(Brushes.Green, bullet);

            Point[] stars1_1 = {
                new Point(120, 120),
                new Point(140, 140),
                new Point(100, 140),
            };
            myGraphics.FillPolygon(Brushes.Red, stars1_1);

            Point[] stars1_2 = {
                new Point(100, 127),
                new Point(140, 127),
                new Point(120, 147),
            };
            myGraphics.FillPolygon(Brushes.Red, stars1_2);

            Point[] stars2_1 = {
                new Point(220, 220),
                new Point(240, 240),
                new Point(200, 240),
            };
            myGraphics.FillPolygon(Brushes.Red, stars2_1);

            Point[] stars2_2 = {
                new Point(200, 227),
                new Point(240, 227),
                new Point(220, 247),
            };
            myGraphics.FillPolygon(Brushes.Red, stars2_2);

            Point[] stars3_1 = {
                new Point(420, 320),
                new Point(440, 340),
                new Point(400, 340),
            };

            myGraphics.FillPolygon(Brushes.Red, stars3_1);

            Point[] stars3_2 = {
                new Point(400, 327),
                new Point(440, 327),
                new Point(420, 347),
            };
            myGraphics.FillPolygon(Brushes.Red, stars3_2);

            Point[] stars4_1 = {
                new Point(520, 120),
                new Point(540, 140),
                new Point(500, 140),
            };
            myGraphics.FillPolygon(Brushes.Red, stars4_1);
       
            Point[] stars4_2 = {
                new Point(500, 127),
                new Point(540, 127),
                new Point(520, 147),
            };
            myGraphics.FillPolygon(Brushes.Red, stars4_2);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
            Console.WriteLine(e.Location);
        }
    }
}
