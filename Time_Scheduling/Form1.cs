using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Scheduling
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();         
            Data_Class.University Uni = new Data_Class.University(1, 1);
            Uni.Fill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
