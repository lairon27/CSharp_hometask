using System;
using System.Drawing;
using System.Windows.Forms;

namespace Questionnaire
{
    public partial class Form1 : Form
    {
        public static int flag;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            
            switch (flag)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\ab.jpg");
                    break;
                    
                case 1:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\or1.jpg");

                    break;
                
                case 2:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\Sadie-Soverall1.jpg");
                    break;
                
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\aron2.jpg");
                    break;
            }
            
           
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;

            switch (flag)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\allen1.jpg");
                    break;
                    
                case 1:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\mm1.jpg");
                    break;
                
                case 2:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\bv1.jpg");
                    break;
                
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\38066\RiderProjects\Univer\Questionnaire\bin\Debug\.jpg.jpg");
                    break;
            }
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            button4.Visible = false;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            flag = 0;
            pictureBox1.Image = null;
            label1.Text = "Barry Allen\n23 y.o.\nFaculty of Law\nDepartment of Criminalistics\nYURD – 11BMz";
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            toolStripStatusLabel1.Text = "Page: 1";
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            flag = 1;
            pictureBox1.Image = null;
            label1.Text = "Peter Parker\n18 y. o.\nFaculty of Economics\nEKE-21";
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            toolStripStatusLabel1.Text = "Page: 2";
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            flag = 2;
            pictureBox1.Image = null;
            label1.Text = "Lydia Martin\n20 y.o.\nFaculty of Foreign Languages\nIna - 43";
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            toolStripStatusLabel1.Text = "Page: 3";
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            flag = 3;
            pictureBox1.Image = null;
            label1.Text = "Aron Piper\n19 y.o.\nFaculty of Applied Mathematics\nPMa - 32";
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            toolStripStatusLabel1.Text = "Page: 4";
        }
    }
}