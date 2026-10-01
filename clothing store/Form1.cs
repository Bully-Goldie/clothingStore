using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clothing_store.mainMenu;
using MySql.Data.MySqlClient;

namespace clothing_store
{
    public partial class MainMenu : Form
    {
        string str = "host=localhost;uid=root;pwd=root;database=store";

        public MainMenu()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string textBoxLogin = textBox1.Text;
            string textBoxPassword = textBox2.Text;

            string login = "";
            string password = "";
            int role = 0;

            try
            {
                MySqlConnection con = new MySqlConnection(str);
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"SELECT WorkerId, WorkerLogin, WorkerPassword, WorkerRole FROM worker 
                                                    WHERE WorkerLogin = @textBoxLogin;", con);

                cmd.Parameters.AddWithValue("@textBoxLogin", textBoxLogin);

                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    login = reader.GetString("WorkerLogin");
                    password = reader.GetString("WorkerPassword");
                    role = Convert.ToInt32(reader["WorkerRole"]);
                }


                if (textBoxLogin == login && textBoxPassword == password)
                {
                    if (role == 1)
                    {
                        admin admin = new admin();
                        this.Visible = false;
                        admin.ShowDialog();
                        this.Visible = true;
                        clearTextBox();
                    }
                    if (role == 2)
                    {
                        manager manager = new manager();
                        this.Visible = false;
                        manager.ShowDialog();
                        this.Visible = true;
                        clearTextBox();
                    }
                    if (role == 3)
                    {
                        seller seller = new seller();
                        this.Visible = false;
                        seller.ShowDialog();
                        this.Visible = true;
                        clearTextBox();
                    }
                }
                else
                {
                    MessageBox.Show("Вы неправилильно ввели логин или пароль! Попробуйте еще раз.");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            void clearTextBox()
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
