using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Dictionary<double, double> dict = new Dictionary<double, double>();
        public Form1()
        {
            InitializeComponent();
            textBox4.ContextMenuStrip = contextMenuStrip2;
        }

        private void протабулюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = Double.Parse(textBox1.Text);
            var b = Double.Parse(textBox2.Text);
            var h = Double.Parse(textBox3.Text);
            dataGridView1.Columns.Add("Index", "Index");
            dataGridView1.Columns.Add("Value", "Dice Value");
           
            if (b > a)
            {
                var x = a;
                do
                {
                    var func = textBox4.Text;
                    double func1 = 0;
                    if (func.Contains("sin(x)"))
                    {
                        func1 += Math.Sin(x);
                    }
                    if (func.Contains("cos(x)"))
                    {
                        func1 += Math.Cos(x);
                    }
                    if (func.Contains("tan(x)"))
                    {
                        func1 += Math.Tan(x);
                    }
                    if (func.Contains("cot(x)"))
                    {
                        func1 += 1 / Math.Tan((x));
                    }
                    // var y = (Math.Sin(x) + Math.Cos(x));
                    var y = func1;
                    dict.Add(x, y);
                   
                    x = x + h;
                } while (x <= b);

                if (checkBox2.Checked && checkBox1.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
                else if (checkBox2.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                }
                else
                {
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
            }
            else
                MessageBox.Show("a>b");
        }

        private void максимальнеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Text = "Max = " + dict.Values.Max().ToString();
        }

        private void мінімальнеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Text = "Min = " + dict.Values.Min().ToString();
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dict.Clear();
        }

        private void графікToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var t = new graphic();
            t.chart1.Series[0].LegendText = textBox4.Text;
            foreach (var pair in dict)
            {
                t.chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
            t.Show();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ця програма створена для табулювання функцій на проміжку [a, b] та кроком h. Також" +
                            " можна найти максимум та мінімум, побудувати графік.", "Info",MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var a = Double.Parse(textBox1.Text);
            var b = Double.Parse(textBox2.Text);
            var h = Double.Parse(textBox3.Text);
            dataGridView1.Columns.Add("Index", "Index");
            dataGridView1.Columns.Add("Value", "Dice Value");
            
            if (b > a)
            {
                var x = a;
                do
                {
                    var func = textBox4.Text;
                    double func1 = 0;
                    if (func.Contains("sin(x)"))
                    {
                        func1 += Math.Sin(x);
                    }
                    if (func.Contains("cos(x)"))
                    {
                        func1 += Math.Cos(x);
                    }
                    if (func.Contains("tan(x)"))
                    {
                        func1 += Math.Tan(x);
                    }
                    if (func.Contains("cot(x)"))
                    {
                        func1 += 1 / Math.Tan((x));
                    }
                    // var y = (Math.Sin(x) + Math.Cos(x));
                    var y = func1;
                   
                    dict.Add(x, y);
                   
                    x = x + h;
                } while (x <= b);
                
                if (checkBox2.Checked && checkBox1.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
                else if (checkBox2.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                }
                else
                {
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
            }
            else
                MessageBox.Show("a>b");
        }

        private void протабулюватиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var a = Double.Parse(textBox1.Text);
            var b = Double.Parse(textBox2.Text);
            var h = Double.Parse(textBox3.Text);
            dataGridView1.Columns.Add("Index", "Index");
            dataGridView1.Columns.Add("Value", "Dice Value");
            if (b > a)
            {
                var x = a;
                do
                {
                    var func = textBox4.Text;
                    double func1 = 0;
                    if (func.Contains("sin(x)"))
                    {
                        func1 += Math.Sin(x);
                    }
                    if (func.Contains("cos(x)"))
                    {
                        func1 += Math.Cos(x);
                    }
                    if (func.Contains("tan(x)"))
                    {
                        func1 += Math.Tan(x);
                    }
                    if (func.Contains("cot(x)"))
                    {
                        func1 += 1 / Math.Tan((x));
                    }
                    // var y = (Math.Sin(x) + Math.Cos(x));
                    var y = func1;
                   
                    dict.Add(x, y);
                   
                    x = x + h;
                } while (x <= b);
                
                if (checkBox2.Checked && checkBox1.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
                else if (checkBox2.Checked)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    var filename = saveFileDialog1.FileName;
                    var sb = new StringBuilder();
                    foreach (var pair in dict)
                    {
                        sb.AppendLine($"{pair.Key}\t{pair.Value}");
                    }
                    File.WriteAllText(filename, sb.ToString());
                    MessageBox.Show("File save");
                }
                else
                {
                    foreach (var pair in dict)
                    {
                        dataGridView1.Rows.Add(pair.Key, pair.Value);
                    }
                }
            }
            else
                MessageBox.Show("a>b");
        }

        private void очиститиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dict.Clear();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var t = new graphic();
            t.chart1.Series[0].LegendText = textBox4.Text;
            foreach (var pair in dict)
            {
                t.chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
            t.Show();
        }

        private void намалюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new graphic();
            t.chart1.Series[0].LegendText = textBox4.Text;
            foreach (var pair in dict)
            {
                t.chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
            t.Show();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            label5.Text = "Min = " + dict.Values.Min().ToString();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dict.Clear();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ця програма створена для табулювання функцій на проміжку [a, b] та кроком h. Також" +
                            " можна найти максимум та мінімум, побудувати графік.", "Info",MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            label5.Text = "Max = " + dict.Values.Max().ToString();
        }

        private void sinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text += "sin(x)";
            
        }

        private void cosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text += "cos(x)";
        }

        private void tanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text += "tan(x)";
        }

        private void cotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text += "cot(x)";
        }
    }
}