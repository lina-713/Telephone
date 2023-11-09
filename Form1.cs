using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Telphone
{
    public partial class Form1 : Form
    {
        public NpgsqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            string log = textBox1.Text;
            string pass = textBox2.Text;

            switch (log + pass)
            {
                case ("guest" + "guest"):
                    str = "Host=localhost;Port=5432;Database=Telephone_network;Username=guest;Password=guest";
                    break;

                case ("admin" + "admin"):
                    str = "Host=localhost;Port=5432;Database=Telephone_network;Username=admin;Password=admin";
                    break;
                default:
                    MessageBox.Show("Неправильный логин или пароль!");
                    return;
            }

            NpgsqlConnection conn = new NpgsqlConnection(str);
            connection = conn;
            var menu = new Menu(connection);
            menu.Show();
        }
    }
}
