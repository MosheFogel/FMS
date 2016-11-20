using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMS_adapter;

namespace FMS_GUI
{
    public partial class new_file : Form
    {
        string folderpath = "";
        public new_file()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderpath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                folderpath = fbd.SelectedPath;
                textBox4.Text = folderpath;
            }

            if (folderpath != "")
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(textBox3.Text) < 120))
            {
                MessageBox.Show("יש להזין מספר רשומות גדול מ-120 ");
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("אנא מלא את כל השדות", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    HashFileStat.HFStatic.hcreate(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), folderpath, Convert.ToInt32(textBox5.Text), 0, "IO", 6, Convert.ToInt32(comboBox1.Text));
                    MessageBox.Show("הקובץ נוצר בהצלחה","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void new_file_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_SelectedItemChanged(object sender, EventArgs e)
        {
      
            

        }
    }
}
