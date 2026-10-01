using clothing_store.controlMenu.manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothing_store.mainMenu
{
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            viewOrders viewOrders = new viewOrders();
            this.Visible = false;
            viewOrders.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controlProduct controlProduct = new controlProduct();
            this.Visible = false;
            controlProduct.ShowDialog();
            this.Visible = true;
        }
    }
}
