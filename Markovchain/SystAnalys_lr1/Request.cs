using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    public partial class Request : Form
    {

        public Request()
        {
            InitializeComponent();
            this.AcceptButton = good;
            
        }

        public void good_Click(object sender, EventArgs e)
        {
            if (float.TryParse(wt.Text, out float u) && u >= 0 && u <= 1)
            {
                wt.Text = u.ToString();
                Close();
            }
            else
            {
                MessageBox.Show("Некоректное значение");
                wt.Clear();
            }

        }
    }
}
