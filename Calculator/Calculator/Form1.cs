using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Calc calc = new Calc ();

        private void number_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            textBox1.Text += b.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            calc.first = double.Parse(textBox1.Text);
            calc.operation = b.Text;
            textBox1.Text = "";
            show = false;
        }
        public bool show = false;
        private void result_click(object sender, EventArgs e)
        {
            if (!show)
            {
                calc.second = double.Parse(textBox1.Text);
                show = true;
            }
            else
                calc.first = double.Parse(textBox1.Text);
            calc.Calculate();
            textBox1.Text = calc.Result.ToString();
        }

        private void back_click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }
        public string mem;
        private void memory_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Text)
            {
                case "MS":
                    mem = textBox1.Text;
                    break;
                case "MR":
                    textBox1.Text = mem;
                    break;
                case "MC":
                    mem = "";
                    break;
                case "M+":
                    double a = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(mem);
                    mem = Convert.ToString(a);
                    break;
            }
        }

        private void extra_click(object sender, EventArgs e)
        {
           double sum = 1;
           for (int i = 2; i <=int.Parse(textBox1.Text); i++)
                sum*= i;
            textBox1.Text = Convert.ToString(sum);
        }

        private void sqrt_click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            textBox1.Text = (Math.Sqrt(a)).ToString();
        }
        public bool comaUse=false;

        private void coma_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0,";
            else if (!comaUse)
            {
                textBox1.Text += ",";
                comaUse = true;
            }
        }

        private void clear_click(object sender, EventArgs e)
        {
            calc.first = calc.second = calc.result = 0;
            calc.operation = textBox1.Text = "";
        }

        private void a_click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
                textBox1.Text = (a*a*a).ToString();
        }
    }
}
