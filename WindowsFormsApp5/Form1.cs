using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            toolStripLabel1.Text = "Amount: " + dataGridView1.RowCount.ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row  in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
                dataGridView1.Refresh();
            }
            toolStripLabel1.Text = "Amount: " + dataGridView1.RowCount.ToString();
        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Прізвище"], ListSortDirection.Ascending);
        }

        private void сортНомерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Номер"], ListSortDirection.Ascending);
        }

        private void сортГрупаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Група"], ListSortDirection.Ascending);
        }

        private void сортРікToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Рік"], ListSortDirection.Ascending);
        }
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].Visible = true;
                            break;
                        }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount-1].Cells[dataGridView1.ColumnCount-1];
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + 1]
                    .Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
            catch
            {
                MessageBox.Show("Останній рядок");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex - 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
            catch
            {
                MessageBox.Show("Перший рядок");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            var filename = saveFileDialog1.FileName;
            var sw = new StreamWriter(filename);
            for(var i = 0; i < dataGridView1.RowCount; i++)
            {
                for(var j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    sw.Write(Convert.ToString(dataGridView1[j, i].Value) + " ");
                }
                sw.WriteLine();
            }
            sw.Close();
            MessageBox.Show("File save");
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            var filename = openFileDialog1.FileName;
            var fileText = File.ReadAllLines(filename);
            dataGridView1.Columns.Add("Прізвище", "Прізвище");
            dataGridView1.Columns.Add("Номер", "Номер студентського");
            dataGridView1.Columns.Add("Група", "Група");
            dataGridView1.Columns.Add("Рік", "Рік народження");
            foreach (var line in fileText)
            {
                var array = line.Split();
                dataGridView1.Rows.Add(array);
            }
        
            dataGridView1.Rows[0].Selected = false;
          
            toolStripLabel1.Text ="Amount: " + dataGridView1.RowCount.ToString();
            MessageBox.Show("File open");
        }
    }
}