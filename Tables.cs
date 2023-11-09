using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telphone
{
    public partial class Tables : Form
    {
        public readonly NpgsqlConnection connection;
        public readonly Key key;
        public Tables(NpgsqlConnection connection,  Key key )
        {
            InitializeComponent();
            this.connection = connection;
            this.key = key;
            EnterTable();
        }
        public Tables(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            EnterTable();
        }

        public void EnterTable()
        {
            switch (key)
            {
                case Key.Account:
                    var tables = new EnterTables(connection, this);
                    tables.EnterClients();
                    break;

                case Key.Services:
                    tables = new EnterTables(connection, this);
                    tables.EnterServices();
                    break;

                case Key.Status:
                    tables = new EnterTables(connection, this);
                    tables.EnterStatus();
                    break;

                case Key.IndivAccount:
                    tables = new EnterTables(connection, this);
                    tables.EnterIndivAccount();
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (key)
            {
                case Key.Account:
                    var insert = new UpdateInsertAccounts(connection, this, 0);
                    insert.Show();
                    break;

                case Key.Services:
                    break;

                case Key.Status:
                    break;

                case Key.IndivAccount:
                    break;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            var menu = new Menu(connection);
            menu.Show();
        }
    }
}
