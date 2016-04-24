using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paintWithMove
{
    public partial class Form1 : Form
    {
        Graphics g;
        Timer t;
        Pen myPen = new Pen(Color.Black);
        Rectangle r = new Rectangle(30, 30, 80, 80);
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            t = new Timer();
            g.TranslateTransform(100, 100);
            t.Tick += new EventHandler(rotateObject);
            t.Start();
        }

        public void rotateObject(object sender, EventArgs e)
        {
            g.TranslateTransform(r.Width / 2, r.Height / 2);
            g.RotateTransform(10);
            g.TranslateTransform(-r.Width / 2, -r.Height / 2);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawRectangle(myPen, r);
        }

    }
}
