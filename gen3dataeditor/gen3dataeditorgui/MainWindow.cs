using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gen3dataeditorgui
{
    public partial class MainWindow : Form
    {
        OpenFileDialog browse;
        StringBuilder program;
        public MainWindow()
        {

           
            InitializeComponent();
            rb_get.Checked = true;
            tb_rompath.Multiline = false;
            browse = new OpenFileDialog();
            browse.CheckFileExists = true;
            browse.Filter = "GBA ROM file (*.gba) | *.gba";
            browse.FilterIndex = 0;
            program = new StringBuilder();
           
            
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            DialogResult result = browse.ShowDialog();

            if(result == DialogResult.OK)
            {
                tb_rompath.Text = browse.FileName;
            }
        }

        private void rb_get_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_get.Checked)
            {
                rb_set.Checked = false;
                tb_setvalue.Enabled = false;
            }
            else if(rb_set.Checked)
            {
                rb_get.Checked = false;
                tb_setvalue.Enabled = true;
            }
        }

        private void button_exec_Click(object sender, EventArgs e)
        {
            tb_console.Text = string.Empty;
            program.Clear();
            if (string.IsNullOrWhiteSpace(tb_rompath.Text))
            {
                MessageBox.Show("Please enter the ROM path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                program.Append(" --rom-file " + "\"" + tb_rompath.Text + "\" ");
            }
            if (rb_get.Checked)
            {
                if(cb_isstring.Checked)
                {
                    program.Append("--get-value-string ");
                }
                else
                {
                    program.Append("--get-value-int ");
                }
            }
            else if(rb_set.Checked)
            {

                if (cb_isstring.Checked)
                {
                    program.Append("--set-value-string ");
                    if (string.IsNullOrWhiteSpace(tb_setvalue.Text))
                    {
                        MessageBox.Show("Please enter the set value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        program.Append("\"" +tb_setvalue.Text + "\" ");
                    }
                }
                else
                {
                    program.Append("--set-value-int ");
                    
                    if (string.IsNullOrWhiteSpace(tb_setvalue.Text))
                    {
                        MessageBox.Show("Please enter the set value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        program.Append(tb_setvalue.Text + " ");
                    }
                }
            }

            if(string.IsNullOrWhiteSpace(tb_structname.Text))
            {
                MessageBox.Show("Please enter the structname", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                program.Append("--struct " + "\"" + tb_structname.Text + "\" ");
            }
            if(string.IsNullOrWhiteSpace(tb_offsetname.Text))
            {
                MessageBox.Show("Please enter the offsetname", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                program.Append("--offset " + "\"" + tb_offsetname.Text + "\" ");
            }
            if(string.IsNullOrWhiteSpace(tb_index.Text))
            {
                MessageBox.Show("Please enter an index number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                program.Append("--index " + tb_index.Text + " ");
            }

            if(cb_printhex.Checked)
            {
                program.Append("--print-hex ");
            }
            else
            {

            }
            tb_console.Text = string.Empty;
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "gen3dataeditor.exe";
            process.StartInfo.Arguments = program.ToString();
            process.Start();
            tb_console.Text = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            tb_value.Text = getValueConsole(tb_console.Text);
            
        }

        private void rb_set_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_get.Checked)
            {
                rb_set.Checked = false;
                tb_setvalue.Enabled = false;
            }
            else if (rb_set.Checked)
            {
                rb_get.Checked = false;
                tb_setvalue.Enabled = true;
            }
        }

        private string getValueConsole(string consoletext)
        {
            int start;
            if(rb_get.Checked)
            {
                if (consoletext.Contains("Value:"))
                {
                    start = consoletext.IndexOf("Value: ", 0) + "Value: ".Length;
                    return consoletext.Substring(start);

                }
                else
                {
                    return string.Empty;
                }
            }
            else if (rb_set.Checked)
            {
                if (consoletext.Contains("Value after: "))
                {
                    start = consoletext.IndexOf("Value after: ", 0) + "Value after: ".Length;
                    return consoletext.Substring(start);

                }
                else
                {
                    return string.Empty;
                }
            }

            return string.Empty;

        }

        private void button_liststructs_Click(object sender, EventArgs e)
        {

            StringBuilder str = new StringBuilder();
            str.Clear();
            if(string.IsNullOrWhiteSpace(tb_rompath.Text))
            {
                MessageBox.Show("Please enter the ROM path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                str.Append("--rom-file " + tb_rompath.Text + " ");
            }
            str.Append("--list-structs ");


            tb_console.Text = string.Empty;
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = "gen3dataeditor.exe";
            
            
            proc.StartInfo.Arguments = str.ToString();

            proc.Start();

            tb_console.Text = proc.StandardOutput.ReadToEnd();
            

        }

        private void button_listoffsets_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.Clear();
            if (string.IsNullOrWhiteSpace(tb_rompath.Text))
            {
                MessageBox.Show("Please enter the ROM path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                str.Append("--rom-file " + tb_rompath.Text + " ");
            }

            if(string.IsNullOrWhiteSpace(tb_structname.Text))
            {
                MessageBox.Show("Please enter a struct name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                str.Append("--list-offsets " + tb_structname.Text + " ");
            }

            tb_console.Text = string.Empty;
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = "gen3dataeditor.exe";
            
            proc.StartInfo.Arguments = str.ToString();

            proc.Start();

            tb_console.Text = proc.StandardOutput.ReadToEnd();
        }

        private void cb_printhex_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_printhex.Checked)
            {
                cb_isstring.Checked = false;
                cb_isstring.Enabled = false;
            }
            else
            {
                cb_isstring.Enabled = true;
            }
            
        }
    }
}
