using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace end_term
{
    public partial class Form1 : Form
    {
        Graphics g;
        static int x = 15; static int y = 15;
        Rectangle r=new Rectangle(5,5,470,450);
        Pen pen = new Pen(Color.Black, 5);
       
        SolidBrush brush= new SolidBrush(Color.Red);
        Timer t;
        int dx = 10;
       
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            t = new Timer();
            t.Tick += new EventHandler(moveObject);
            t.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawRectangle(pen, r);
            g.FillRectangle(brush, x, y, 50, 50);
            g.FillEllipse(Brushes.Black, x, y + 50, 20, 20);
            g.FillEllipse(Brushes.Black, x + 30, y + 50, 20, 20);
        }

        public void moveObject(object sender, EventArgs e)
        {
            if (x + 50 > r.Width)
            {
                brush = new SolidBrush(Color.Yellow);
                dx = -10;
            }
            if (x < 10)
            {
                brush = new SolidBrush(Color.Blue);
                dx = 10;
            }
            x += dx;
            Refresh();
        }
    }
}
