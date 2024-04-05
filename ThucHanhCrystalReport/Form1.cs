using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhCrystalReport
{
    public partial class Form1 : Form
    {

        private string connectionString =
            ConfigurationManager.ConnectionStrings["th4hsk"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            form2.ShowReport();
        }
    }
}
