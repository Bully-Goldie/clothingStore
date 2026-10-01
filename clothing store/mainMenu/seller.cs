using clothing_store.controlMenu.seller;
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
    public partial class seller : Form
    {
        public seller()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderProduct orderProduct = new orderProduct();
            this.Visible = false;
            orderProduct.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewProduct viewProduct = new viewProduct();
            this.Visible = false;
            viewProduct.ShowDialog();
            this.Visible = true;
        }
    }
}
