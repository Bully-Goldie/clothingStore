using clothing_store.controlMenu.admin;
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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controlDB controlDB = new controlDB();
            this.Visible = false;
            controlDB.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            referenceBooks referenceBooks = new referenceBooks();
            this.Visible = false;
            referenceBooks.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlWorker controlWorker = new controlWorker();
            this.Visible = false;
            controlWorker.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
