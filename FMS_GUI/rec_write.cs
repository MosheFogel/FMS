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
    public partial class rec_write : Form
    {
        public rec_write()
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
        private void BT_write_Click(object sender, EventArgs e)
        {
            try
            {
                //constraints according the student class structure
                if (TB_StudID.Text.ToString().Length > 4 || TB_StudID.Text.ToString().Length < 1)
                    throw new Exception("ID length must be  1-4 letters/digits");
                if (TB_RegNR.Text.ToString().Length > 2 || TB_RegNR.Text.ToString().Length < 1)
                    throw new Exception("Registration Number length must be one or two letters/digits");
                //chooses the right struct- int key or string key
                if (isint(TB_StudID.Text)==true)
                {
                    StudCourseI SC = new StudCourseI();
                    SC.StudID = int.Parse(TB_StudID.Text);
                    SC.RegNr = int.Parse(TB_RegNR.Text);
                    SC.Key = SC.StudID * (int)(Math.Pow(10.0, SC.DigitCount(SC.RegNr))) + SC.RegNr;
                    SC.FirstName = TB_FN.Text;
                    SC.FamilyName = TB_LN.Text;
                    SC.CourseName = TB_C.Text;
                    SC.Grade =(TB_G.Text);
                    HashFileStat.HFStatic.Write(SC.Key, SC);
                    MessageBox.Show("Record was written succefully!", "Message");
                    Close();
                }
                else
                {
                    StudCourseC SC = new StudCourseC();
                    SC.StudID = int.Parse(TB_StudID.Text);
                    SC.RegNr = int.Parse(TB_RegNR.Text);
                    SC.Key = TB_StudID.Text + TB_RegNR.Text;
                    SC.FirstName = TB_FN.Text;
                    SC.FamilyName = TB_LN.Text;
                    SC.CourseName = TB_C.Text;
                    SC.Grade = (TB_G.Text);
                    HashFileStat.HFStatic.Write(SC.Key, SC);
                    MessageBox.Show("Record was written succefully!", "Message");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LBL_stu_Click(object sender, EventArgs e)
        {

        }

        private void LBL_SID_Click(object sender, EventArgs e)
        {

        }

        private void LBL_RNR_Click(object sender, EventArgs e)
        {

        }

        private void LBL_FN_Click(object sender, EventArgs e)
        {

        }

        private void LBL_LN_Click(object sender, EventArgs e)
        {

        }

        private void LBL_c_Click(object sender, EventArgs e)
        {

        }

        private void rec_write_Load(object sender, EventArgs e)
        {

        }

        private void LBL_G_Click(object sender, EventArgs e)
        {

        }
    }
}
