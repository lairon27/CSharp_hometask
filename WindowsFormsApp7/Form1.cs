using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string CurrentFile = "";
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Do you want to save the form or the content will be lost?",
                    "My First Application",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    CurrentFile = "";
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    
                    var filename = saveFileDialog1.FileName;
                    File.WriteAllText(filename, richTextBox1.Text);
                    MessageBox.Show("save successfully", "Address File : " + filename, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            var filename = openFileDialog1.FileName;
            var fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("File open");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Tesr files|*.txt";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                using (var sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
            }
            MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void rtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlgSave = new SaveFileDialog())
                try
                {
                    // Default file extension
                    dlgSave.DefaultExt = "*.rtf"; 
                    // SaveFileDialog title
                    dlgSave.Title = "Save File As";
                    // Available file extensions
                    dlgSave.Filter = "RTF Files (*.rtf)|*.rtf"; 
                    // Show SaveFileDialog box and save file
                    if (dlgSave.ShowDialog() == DialogResult.OK) 
                    {
                        if (Path.GetExtension(dlgSave.FileName) == ".rtf")
                        {
                            richTextBox1.SaveFile(dlgSave.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                    MessageBox.Show("save successfully", "Address File : " + dlgSave.FileName, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }catch (Exception errorMsg)
                {
                    MessageBox.Show(errorMsg.Message);
                }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile1 = new SaveFileDialog();

            using (var dlgSave = new SaveFileDialog())
                try
                {
                    // Default file extension
                    dlgSave.DefaultExt = "*.rtf"; 
                    // SaveFileDialog title
                    dlgSave.Title = "Save File As";
                    // Available file extensions
                    dlgSave.Filter = "RTF Files (*.rtf)|*.rtf|Txt Files (*.txt)|*.txt|Doc Files (*.doc)|*.doc"; 
                    // Show SaveFileDialog box and save file
                    if (dlgSave.ShowDialog() == DialogResult.OK) 
                    {
                        if (Path.GetExtension(dlgSave.FileName) == ".rtf")
                        {
                            richTextBox1.SaveFile(dlgSave.FileName, RichTextBoxStreamType.PlainText);
                        }
                        if (Path.GetExtension(dlgSave.FileName) == ".txt")
                        {
                            richTextBox1.SaveFile(dlgSave.FileName, RichTextBoxStreamType.PlainText);
                        }
                        if (Path.GetExtension(dlgSave.FileName) == ".doc")
                        {
                            richTextBox1.SaveFile(dlgSave.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                    MessageBox.Show("save successfully", "Address File : " + dlgSave.FileName, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }catch (Exception errorMsg)
                {
                    MessageBox.Show(errorMsg.Message);
                }
            
            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            // saveFile1.DefaultExt = "*.doc";
            // saveFile1.Filter = "DOC Files|*.doc";
            //
            // // Determine if the user selected a file name from the saveFileDialog.
            // if (saveFile1.ShowDialog() == DialogResult.OK &&
            //     saveFile1.FileName.Length > 0)
            // {
            //     // Save the contents of the RichTextBox into the file.
            //     richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            //     MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK,
            //         MessageBoxIcon.Information);
            // }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }
        
        private void closeCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the form?",
                "Ending",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.No)
            {
                
            }
            else
            {
                var saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.txt";
                saveFile1.Filter = "Tesr files|*.txt";
                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
                {
                    using (var sw = new StreamWriter(saveFile1.FileName, true))
                    {
                        sw.WriteLine(richTextBox1.Text);
                        sw.Close();
                    }
                }
            }
            Application.Exit();
        }
       
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                var reader = new StringReader(richTextBox1.Text);
                printDocument1.PrintPage += DocumentToPrint_PrintPage;
                printDocument1.Print();    
            }
        }
        private void DocumentToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            var reader = new StringReader(richTextBox1.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            var Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            var PrintFont = this.richTextBox1.Font;
            var PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoCtrlRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
              richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void baToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private char[] splitWordsBy = "\n .,:;\"'?!".ToArray();
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int currentIndex = richTextBox1.SelectionStart;
            int Ln = richTextBox1.GetLineFromCharIndex(currentIndex);
            int firstLineCharIndex = richTextBox1.GetFirstCharIndexFromLine(Ln);
            int Col = currentIndex;
            int wordCount = richTextBox1.Text.Split(splitWordsBy, StringSplitOptions.RemoveEmptyEntries).Length;
            toolStripLabel1.Text = "Letters:" + (Col + 1) + "   Line:" + (Ln + 1) + "  Words:" + wordCount;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Notepad\nDate of creation:2021", "Info",MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
        
        private void CheckMenuFontCharacterStyle()
        {
            if(richTextBox1.SelectionFont.Bold == true)
            {
                boldToolStripMenuItem.Checked = true;
            }
            else
            {
                boldToolStripMenuItem.Checked = false;
            }

            if(richTextBox1.SelectionFont.Italic == true)
            {
                italicToolStripMenuItem.Checked = true;
            }
            else
            {
                italicToolStripMenuItem.Checked = false;
            }

            if(richTextBox1.SelectionFont.Underline == true)
            {
                underlineToolStripMenuItem.Checked = true;
            }
            else
            {
                underlineToolStripMenuItem.Checked = false;
            }

            if(richTextBox1.SelectionFont.Strikeout == true)
            {
                strikeoutToolStripMenuItem.Checked = true;
            }
            else
            {
                strikeoutToolStripMenuItem.Checked = false;
            }
        }
        
        private void SetBold()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBold();
        }
        
        private void SetItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetItalic();
        }

        private void SetUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUnderline();
        }

        private void SetStrikeout()
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Strikeout;
                }

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        
        private void strikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStrikeout();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        
        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the form or the content will be lost?",
                "My First Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.No)
            {
                richTextBox1.Text = "";
                CurrentFile = "";
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                    
                var filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("File save");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            var filename = openFileDialog1.FileName;
            var fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("File open");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Tesr files|*.txt";
            if (saveFile1.ShowDialog() == DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                using (var sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
            }
            MessageBox.Show("File save");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 8);
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 9);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 10);
        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 11);
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 12);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 14);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 16);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 18);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 20);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 22);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 24);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 26);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 28);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 36);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 48);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
             richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 72);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
             richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void clearAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             richTextBox1.Clear();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        
        private void redoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void docToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.doc";
            saveFile1.Filter = "DOC Files|*.doc";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Tesr files|*.txt";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                using (var sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
            }
            MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}