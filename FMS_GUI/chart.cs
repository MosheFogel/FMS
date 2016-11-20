using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FMS_adapter;
using System.IO;

namespace FMS_GUI
{
    public partial class chart : Form
    {
        public chart()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart_Load(object sender, EventArgs e)
        {
            chart1.Series["free"].Points.Clear();
            //sets data at memory chart
            uint sumofrec = (uint)Math.Floor((float)HashFileStat.HFStatic.FileSize() / HashFileStat.HFStatic.RecordSize()*1000);
            uint used =(uint) HashFileStat.HFStatic.NrOfRecsInFile();
            uint free = sumofrec - used;

            chart1.Series["free"].Points.AddXY("free: " + (float)free / sumofrec * 100 + "%", free);
            chart1.Series["free"].Points.AddXY("used: " + (float)used / sumofrec * 100 + "%", used);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show(Environment.SpecialFolder.MyDocuments.ToString());
                chart1.SaveImage("C:\\save\\mypic.png", ChartImageFormat.Png);
                MessageBox.Show("התמונה נשמרה בהצלחה");
            }
            catch (Exception)
            {

                MessageBox.Show("נסיון שמירה כושל");
            }
        }
    }
}
