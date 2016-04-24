using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Drawer draw;
        public Form1()
        {
            InitializeComponent();
            draw = new Drawer(pictureBox1);
        }

        private void Pen_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Pencil;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw.previous = e.Location;
            draw.getStarted = true;
            if (draw.tool == Tool.Brush) {
                draw.floodFill();
                draw.getStarted = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw.getStarted)
                draw.Draw(e.Location);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw.getStarted = false;
            draw.saveLastPath();
        }

        private void eraser_click(object sender, EventArgs e)
        {
            draw.tool = Tool.Eraser;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            draw.pen.Width = trackBar1.Value;
        }

        private void color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            draw.pen.Color = colorDialog1.Color;
        }

        private void line_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Line;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw.myGraphics.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG Files (*.jpg)| *jpg| PNG Files(*.png)| *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                draw.saveImage(saveFileDialog1.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files (*.jpg)| *jpg| PNG Files(*.png)| *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                draw.openImage(openFileDialog1.FileName);
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Ellipse;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Rectangle;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void triangle_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Triangle;
        }
        private void Brush_Click (object sender, EventArgs e)
        {
            draw.tool = Tool.Brush;
        }

        private void Cube_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Cube;
        }

        private void Six_Click(object sender, EventArgs e)
        {
            draw.tool = Tool.Six;
        }
    }

}
