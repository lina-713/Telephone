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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telphone
{
    public partial class Menu : Form
    {
        public NpgsqlConnection connection;
        public Menu(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table = new Tables(connection, Key.Account);
            table.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var table = new Tables(connection, Key.Services);
            table.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var table = new Tables(connection, Key.Status);
            table.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var table = new Tables(connection, Key.IndivAccount);
            table.Show();
            this.Close();
        }
    }
}
