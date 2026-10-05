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
        Random random = new Random();
        string[] img = { @"imgCaptha/one.jpg", @"imgCaptha/two.jpg", @"imgCaptha/three.jpg" };

        string str = "host=localhost;uid=root;pwd=root;database=store";

        int count = 0;
        int idCaptha;

        public MainMenu()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';

            pictureBox2.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            this.Height = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void imgCaptha()
        {
            int idx = random.Next(img.Length);

            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }

            pictureBox2.Image = Image.FromFile(img[idx]);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            idCaptha = idx;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textBoxLogin = textBox1.Text.Trim();
            string textBoxPassword = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(textBoxLogin) || string.IsNullOrEmpty(textBoxPassword))
            {
                MessageBox.Show("Вы не ввели логин или пароль");
                return;
            }

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
                    count = 0;
                }
                else
                {
                    this.Height = 567;
                    MessageBox.Show("Вы неправилильно ввели логин или пароль!");
                    count++;

                    if (count >= 1)
                    {
                        pictureBox2.Visible = true;
                        label3.Visible = true;
                        textBox3.Visible = true;

                        imgCaptha();
                        if (textBoxLogin == login && textBoxPassword == password)
                        {
                            if (auth(textBox3.Text))
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
                                count = 0;
                            }
                            else
                            {
                                MessageBox.Show("Вы неправильно ввели Captha!");
                                imgCaptha();
                            }
                        }
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            bool auth(string captha)
            {
                if (idCaptha == 0)
                {
                    captha = "FG4F";
                    return true;
                }
                else if (idCaptha == 1)
                {
                    captha = "AG1F";
                    return true;
                }
                else if (idCaptha == 2)
                {
                    captha = "SD1Q";
                    return true;
                }
                else
                {
                    return false;
                }
            }

            void clearTextBox()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                pictureBox2.Visible = false;
                label3.Visible = false;
                textBox3.Visible = false;
                this.Height = 500;
            }
        }
    }
}
