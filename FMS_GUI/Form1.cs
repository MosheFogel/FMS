using FMS_adapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FMS_GUI
{
    public partial class Form1 : Form
    {
        public static bool already_created = false;
        public static bool open = true;
        public static HashFile my_file;
        public Form1()
        {

            InitializeComponent();
            my_file = new HashFile();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            new_file n = new new_file();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblb_title.Left += 3;
            if (lblb_title.Left >= ClientRectangle.Right)
                lblb_title.Left = ClientRectangle.Left - lblb_title.Width;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            open o = new open();
            o.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                Form1.my_file.hdelete();
                MessageBox.Show("הקובץ נמחק בהצלחה ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rec_write r = new rec_write();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rec_Read r = new Rec_Read();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Visible = true;
                textBox1.Text = "הזן מפתח ";
                my_file.Del_rec_Casing(textBox1.Text);

                MessageBox.Show(" !!!הרשומה נמחקה בהצלחה ", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Visible = false;
            }
            catch (Exception ex)
            {
                textBox1.Visible = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            chart c = new chart();
            c.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            try
            {
                HashFileStat.HFStatic.hdelete();
                MessageBox.Show("הקובץ נמחק בהצלחה ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new_file n = new new_file();
            n.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open o = new open();
            o.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                HashFileStat.HFStatic.hclose();
                MessageBox.Show("הקובץ נסגר בהצלחה ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_file n = new new_file();
            n.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open o = new open();
            o.Show();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HashFileStat.HFStatic.hclose();
                MessageBox.Show("הקובץ נסגר בהצלחה ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" :) להתראות בקרוב ", "EXIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HashFileStat.HFStatic.hdelete();
                MessageBox.Show("הקובץ נמחק בהצלחה ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            rec_write r = new rec_write();
            r.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Rec_Read r = new Rec_Read();
            r.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
                try
                {
                   groupBox4.Visible= true;
                   groupBox4.Show();
                  
                    
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rec_write r = new rec_write();
            r.Show();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rec_Read r = new Rec_Read();
            r.Show();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox4.Visible = true;
                groupBox4.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("studcourses.txt");
        }

        private void קובץהסטודנטיםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("studcourses.txt");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                float A = HashFileStat.HFStatic.load_factor();
                MessageBox.Show("מקדם העומס הוא :" + A, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://dl.dropboxusercontent.com/u/35507993/about.jpg");
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart c = new chart();
            c.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            chart c = new chart();
            c.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text.Length < 6)
                {
                    MessageBox.Show(" מלא את השדה נכונה - 6 ספרות.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                HashFileStat.HFStatic.Del_rec_Casing(textBox1.Text);
                groupBox4.Visible = false;
                MessageBox.Show(" !!!הרשומה נמחקה בהצלחה ", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                groupBox4.Visible = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void ביטולעדכוןToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            File_Properties R = new File_Properties();
            R.ShowDialog();
        }

        private void מאפייניהקובץToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Properties R = new File_Properties();
            R.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("דוחות למיני פרויקט.pdf");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("דוחות למיני פרויקט.pdf");
        }
    }
}
