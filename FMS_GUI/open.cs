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
    public partial class open : Form
    {
        string filename = "";
        public open()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HashFileStat.HFStatic.hopen(textBox1.Text, textBox2.Text, textBox4.Text, comboBox1.SelectedItem.ToString());
                HashFileStat.is_opened = true;
                MessageBox.Show(" הקובץ: " + textBox1.Text + " נפתח בהצלחה ","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filename = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HASH Files|*.HASH;|All files (*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filename = ofd.FileName;
                textBox4.Text = filename.Replace(".hash", "");
                textBox4.Text = textBox4.Text.Replace(textBox1.Text, "");
            }
            if (filename != "")
            {

            }
        }
    }
}
