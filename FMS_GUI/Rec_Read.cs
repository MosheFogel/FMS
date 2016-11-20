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

namespace FMS_GUI
{
    public partial class Rec_Read : Form
    {
        bool did = false;
        public Rec_Read()
        {
            InitializeComponent();
        }
        public bool isint(string s)
        {
            bool flag = false;
            foreach (var item in s)
            {
                if ("0123456789".Contains(item))
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }
        private void BT_key_Click(object sender, EventArgs e)
        {
            if (ReedToUpdate.Checked == true)
            {
                if (did == false)
                {
                    this.Height += 200;
                    did = true;
                }
                try
                {
                    TB_c.Enabled = false; TB_gr.Enabled = false; TB_rnr.Enabled = false;
                    TB_sid.Enabled = false; TB_stun.Enabled = false;
                    //chooses the right struct- int key or string key
                    if (isint(TB_key.Text) == true)
                    {
                        if (isint(TB_key.Text))
                        {
                            StudupdateI SC = new StudupdateI();
                            HashFileStat.HFStatic.Read(int.Parse(TB_key.Text), SC, 0);
                            SC.StudID = int.Parse(TB_sid.Text);
                            SC.RegNr = int.Parse(TB_rnr.Text);
                            SC.Key = SC.StudID * (int)(Math.Pow(10.0, SC.DigitCount(SC.RegNr))) + SC.RegNr;
                            SC.Name = TB_stun.Text;
                            SC.CourseName = TB_c.Text;
                            SC.Grade = TB_gr.Text;
                            HashFileStat.HFStatic.Update(SC);
                            MessageBox.Show("The record updated successfully! ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            StudupdateC SC = new StudupdateC();
                            HashFileStat.HFStatic.Read(int.Parse(TB_key.Text), SC, 0);
                            SC.StudID = int.Parse(TB_sid.Text);
                            SC.RegNr = int.Parse(TB_rnr.Text);
                            SC.Key = TB_sid.Text + TB_rnr.Text;
                            SC.Name = TB_stun.Text;
                            SC.CourseName = TB_c.Text;
                            SC.Grade = TB_gr.Text;
                            HashFileStat.HFStatic.Update(SC);
                            MessageBox.Show("The record updated successfully! ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (did == false)
                {
                    this.Height += 200;
                    did = true;
                }
                try
                {
                    if (TB_key.Text == "")
                        throw new Exception("הכנס מפתח!");
                    TB_c.Enabled =  false; TB_gr.Enabled = false; TB_rnr.Enabled =false;
                    TB_sid.Enabled =false;  TB_stun.Enabled =false;
                    //chooses the right struct- int key or string key
                    if (isint(TB_key.Text))
                    {
                        StudCourseI SC = new StudCourseI();
                        HashFileStat.HFStatic.Read(int.Parse(TB_key.Text), SC, 0);
                        TB_sid.Text = SC.StudID.ToString();
                        TB_rnr.Text = SC.RegNr.ToString();
                        TB_stun.Text = SC.FirstName + " " + SC.FamilyName;
                        TB_c.Text = SC.CourseName;
                        TB_gr.Text = SC.Grade.ToString();
                    }
                    else
                    {
                        StudCourseC SC = new StudCourseC();
                        HashFileStat.HFStatic.Read(int.Parse(TB_key.Text), SC, 0);
                        TB_sid.Text = SC.StudID.ToString();
                        TB_rnr.Text = SC.RegNr.ToString();
                        TB_stun.Text = SC.FirstName + " " + SC.FamilyName;
                        TB_c.Text = SC.CourseName;
                        TB_gr.Text = SC.Grade.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Rec_Read_Load(object sender, EventArgs e)
        {
            this.Icon = Form1.ActiveForm.Icon;
        }

        private void ReedToUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (ReedToUpdate.Checked == true)
            {
                TB_c.Enabled = true;
                TB_gr.Enabled = true;
                TB_rnr.Enabled = true;
                TB_sid.Enabled = true;
                TB_stun.Enabled = true;
                BT_key.Text = "עדכן רשומה";
                if (did == false)
                {
                    this.Height += 200;
                    did = true;
                }
            }
            else
            {
                BT_key.Text = "קרא רשומה";
                this.Height -= 200;
                did = false;

            }
        }

        private void TB_sid_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
