using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothing_store.controlMenu.manager
{
    public partial class controlProduct : Form
    {
        public controlProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addProduct addProduct = new addProduct();
            this.Visible = false;
            addProduct.ShowDialog();
            this.Visible = true;
        }
    }
}
