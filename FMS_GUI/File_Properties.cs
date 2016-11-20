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
    public partial class File_Properties : Form
    {
        public File_Properties()
        {
            InitializeComponent();
            label9.Text = HashFileStat.HFStatic.filename();
            label10.Text = HashFileStat.HFStatic.OwnerName();
            label11.Text = HashFileStat.HFStatic.CreationDate();
            label12.Text = HashFileStat.HFStatic.FileSize().ToString();
            label13.Text = HashFileStat.HFStatic.RecordSize().ToString();
            label14.Text = HashFileStat.HFStatic.HashFuncID().ToString();
            label15.Text = HashFileStat.HFStatic.NrOfRecsInFile().ToString();
            label16.Text = HashFileStat.HFStatic.OverflowAreaStart().ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void File_Properties_Load(object sender, EventArgs e)
        {
            


        }
    }
}
