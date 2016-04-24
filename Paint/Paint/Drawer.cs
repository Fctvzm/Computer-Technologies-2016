using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public enum Tool { Pencil, Rectangle, Ellipse, Eraser, Line, Triangle, Brush, Romb };

    class Drawer
    {
        public Graphics myGraphics;
        public Pen pen = new Pen(Color.Red);
        public Bitmap image;
        public PictureBox picture;
        public bool getStarted = false;
        public Point previous;
        public Tool tool;
        public GraphicsPath path;
        public GraphicsPath path_e;
        public GraphicsPath path_2;
        public GraphicsPath path_3;
        public Drawer(PictureBox p)
        {
            this.picture = p;
            openImage("");
            picture.Paint += picturePaint;
        }

        public void picturePaint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                if (tool == Tool.Romb)
                {
                    e.Graphics.DrawPath(pen, path_e);
                    e.Graphics.DrawPath(pen, path_2);
                    e.Graphics.DrawPath(pen, path_3);
                }
                e.Graphics.DrawPath(pen, path);
            }
        }

        public void saveLastPath ()
        {
            if (path != null)
            {
                myGraphics.DrawPath(pen, path);
                if (tool == Tool.Romb)
                {
                    myGraphics.DrawPath(pen, path_e);
                    myGraphics.DrawPath(pen, path_2);
                    myGraphics.DrawPath(pen, path_3);
                }
                path = null;
            }
        }

        public void openImage (string fileName)
        {
            image = fileName == "" ? new Bitmap(picture.Width, picture.Height) : new Bitmap(fileName);
            myGraphics = Graphics.FromImage(image);
            picture.Image = image;
        }

        public void saveImage (string fileName)
        {
            image.Save(fileName);
        }

        public void Draw(Point current)
        {
            switch (tool)
            {
                case Tool.Pencil:
                    myGraphics.DrawLine(pen, previous, current);
                    previous = current;
                    break;
                case Tool.Line:
                    path = new GraphicsPath();
                    path.AddLine(previous, current);
                    break;
                case Tool.Rectangle:
                    path = new GraphicsPath();
                    int fx = previous.X; int fy = previous.Y;
                    if (previous.X > current.X)
                        fx = current.X;
                    if (previous.Y > current.Y)
                        fy = current.Y;
                    path.AddRectangle(new Rectangle
                        (fx, fy, Math.Abs(current.X - previous.X), Math.Abs(current.Y - previous.Y)));
                    break;
                case Tool.Ellipse:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle
                        (previous.X, previous.Y, current.X - previous.X, current.Y - previous.Y));
                    break;
                case Tool.Triangle:
                    path = new GraphicsPath();
                    Point[] triangle = { previous, current, new Point(2 * previous.X - current.X, current.Y) };
                    path.AddPolygon(triangle);
                    break;
                case Tool.Eraser:
                    path_e = new GraphicsPath();
                    int width = (int)pen.Width;
                    path_e.AddRectangle(new Rectangle(previous.X, previous.Y, width+10, width+10));
                    myGraphics.FillPath(Brushes.White, path_e);
                    previous = current;
                    break;
                case Tool.Romb:
                    path = new GraphicsPath();
                    path_e = new GraphicsPath();
                    path_2 = new GraphicsPath();
                    path_3 = new GraphicsPath();
                    int dx = previous.X; int dy = previous.Y;
                    if (previous.X > current.X)
                        dx = current.X;
                    if (previous.Y > current.Y)
                        dy = current.Y;
                    path.AddRectangle(new Rectangle(dx, dy, Math.Abs(current.X - previous.X), Math.Abs(current.Y - previous.Y)));
                    path.AddRectangle(new Rectangle(dx + 50, dy - 50, Math.Abs(current.X - previous.X), Math.Abs(current.Y - previous.Y)));
                    path.AddLine(new Point(previous.X, previous.Y), new Point(previous.X + 50,previous.Y-50));
                    path_2.AddLine(new Point(current.X, previous.Y), new Point(current.X + 50, previous.Y - 50));
                    path_e.AddLine(new Point(previous.X, current.Y), new Point(previous.X + 50, current.Y - 50));
                    path_3.AddLine(new Point(current.X, current.Y), new Point(current.X + 50, current.Y - 50));
                    break;
                default:
                    break;
            }
            picture.Refresh();
        }


        Queue<Point> q = new Queue<Point>();
        bool[,] used;
        Color clickedColor;

        public void floodFill ()
        {
            used = new bool[339, 345];
            clickedColor = image.GetPixel(previous.X, previous.Y);
            check(previous.X, previous.Y);

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                check(p.X, p.Y - 1);
                check(p.X + 1, p.Y);
                check(p.X - 1, p.Y);
                check(p.X, p.Y + 1);
            }
            picture.Refresh();
              
        }

        public void check(int x, int y)
        {
            if (x > 0 && y > 0 && x < picture.Width && y < picture.Height)
            {
                if (used[x, y] == false && image.GetPixel(x, y) == clickedColor)
                {
                    used[x, y] = true;
                    q.Enqueue(new Point(x, y));
                    image.SetPixel(x, y, pen.Color);
                }
            }

        }
    }
}
