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
            if (Form1.already_created == false)
            {
                MessageBox.Show("לא נמצא קובץ למחיקה");
                return;
            }
            try
            {
                Form1.my_file.hdelete();
            }
            catch (Exception)
            {
                MessageBox.Show("!המחיקה נכשלה" + "אנא ודא כי הקובץ קיים ואינו סגור");
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
            my_file.hopen("mos","eli",@"C:\Users\idan\Desktop\","IO");
            MessageBox.Show("OK");
        }
    }
}
