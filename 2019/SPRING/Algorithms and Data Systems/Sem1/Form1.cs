using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Title = "number of elements";
            chart1.ChartAreas[0].AxisY.Title = "number of operations";
            var timer = new Timer();
            var times = timer.GetTimes();

            for (int i = 0; i < 50; i++)
            {
                chart1.Series[0].Points.AddXY(times.intArrayRes[i, 0], times.intArrayRes[i, 1]);
                chart1.Series[1].Points.AddXY(times.intListRes[i, 0], times.intListRes[i, 1]);
            }
        }
    }
}
