using clothing_store.controlMenu.admin.refBooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothing_store.controlMenu.admin
{
    public partial class referenceBooks : Form
    {
        public referenceBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            users users = new users();
            this.Visible = false;
            users.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            brand brand = new brand();
            this.Visible = false;
            brand.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            category category = new category();
            this.Visible = false;
            category.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            discount discount = new discount();
            this.Visible = false;
            discount.ShowDialog();
            this.Visible = true;
        }
    }
}
