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
    public partial class UpdateInsertServices : Form
    {
        public NpgsqlConnection connection;
        public Tables tables;
        public int id;

        public UpdateInsertServices(NpgsqlConnection connection, Tables tables, int id)
        {
            InitializeComponent();
            this.connection = connection;
            this.tables = tables;
            this.id = id;
            if (id != 0)
            {
                EnterInfo(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void EnterInfo(int id)
        {
            var services = new Services();
            var str = $"SELECT name_service, price, explain from services where id = '{id}'";
            var command = new NpgsqlCommand(str, connection);
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                textBox1.Text = reader.GetString(0);
                textBox2.Text = reader.GetString(1);
                textBox3.Text = reader.GetInt64(2).ToString();
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                connection.Close();
            }

            var serviceTable  = new EnterTables(connection, tables);
            serviceTable.EnterServices();
            this.Close();
        }
    }
}
