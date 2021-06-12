using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ConvetToPounds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += comboBox1_DrawItem;
            comboBox1.DropDownClosed += comboBox1_DropDownClosed;
        }
        
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(comboBox1);
        }
        
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            var text = comboBox1.GetItemText(comboBox1.Items[e.Index]);
            e.DrawBackground();
            using (var br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && comboBox1.Items[e.Index] == "Russian pound")
            {
                toolTip1.Show("1 російський фунт = 0,4095 кг", comboBox1, e.Bounds.Right, e.Bounds.Bottom);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && comboBox1.Items[e.Index] == "English pound")
            {
                toolTip1.Show("1 англійський фунт = 0,453592 кг", comboBox1, e.Bounds.Right, e.Bounds.Bottom);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && comboBox1.Items[e.Index] == "Austrian pound")
            {
                toolTip1.Show("1 австрійський фунт = 0,56001 кг", comboBox1, e.Bounds.Right, e.Bounds.Bottom);
            }
            e.DrawFocusRectangle();
        }        
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Visible = true;
                comboBox1.Location = new Point(32, 102);
                label2.Location = new Point(13, 140);
                groupBox2.Location = new Point(13, 160);
                textBox2.Location = new Point(233, 180);
                label2.Visible = true;
                groupBox2.Visible = true;
                textBox2.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox1.Location = new Point(32, 199);
                comboBox1.Visible = true;
                label2.Visible = true;
                groupBox2.Visible = true;
                textBox2.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Visible = false;
                label2.Visible = true;
                groupBox2.Visible = true;
                textBox2.Visible = true;
                label2.Location = new Point(13, 102);
                groupBox2.Location = new Point(13, 128);
                textBox2.Location = new Point(233, 144);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    if (comboBox1.SelectedItem == "Russian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.4095f);
                    }

                    if (comboBox1.SelectedItem == "English pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.45359f);
                    }

                    if (comboBox1.SelectedItem == "Austrian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.56001f);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Input pounds!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (comboBox1.SelectedItem == "Russian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) / 0.4095f, CultureInfo.InvariantCulture);
                    }
                    if (comboBox1.SelectedItem == "English pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) / 0.45359f);
                    }
                    if (comboBox1.SelectedItem == "Austrian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) / 0.56001f);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Input kilograms!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (radioButton4.Checked)
                {
                    if (comboBox1.SelectedItem == "Russian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.4095f);
                    }
                    if (comboBox1.SelectedItem == "English pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.45359f);
                    }
                    if (comboBox1.SelectedItem == "Austrian pound")
                    {
                        textBox2.Text = Convert.ToString(float.Parse(textBox1.Text) * 0.56001f);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Input pounds!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Location = new Point(13, 102);
            groupBox2.Location = new Point(13, 128);
            textBox2.Location = new Point(233, 144);
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox1.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}