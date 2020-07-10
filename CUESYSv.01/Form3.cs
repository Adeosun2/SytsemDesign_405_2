using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUESYSv._01
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            string varPaid;
            if (checkBox1.Checked == true) { varPaid = "Y"; }
            else { varPaid = "N"; }


        }
    }
}
