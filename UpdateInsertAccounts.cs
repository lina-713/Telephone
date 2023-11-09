using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telphone
{
    public partial class UpdateInsertAccounts : Form
    {

        public NpgsqlConnection connection;
        public Tables tables;
        public int id;
        public UpdateInsertAccounts(NpgsqlConnection connection, Tables tables, int id)
        {
            InitializeComponent();
            this.connection = connection;
            this.tables = tables;
            this.id = id;
            StatusDictionary();
            if (id != 0)
            {
                EnterInfo(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            connection.Close();
            if (id == 0)
                InsertClient();
            else
                UpdateClient(id);
            var tables = new Tables(connection);
            var enterTables = new EnterTables(connection, tables);
            //client.EnterClients();
        }

        private void InsertClient()
        {
            connection.Open();
            var command = new NpgsqlCommand("add_new_subs", connection);
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@new_surname", textBox1.Text);
                command.Parameters.AddWithValue("@new_name", textBox2.Text);
                command.Parameters.AddWithValue("@new_contact", BigInteger.Parse(textBox3.Text));
                command.Parameters.AddWithValue("@new_accnumber", BigInteger.Parse(textBox4.Text));
                command.Parameters.AddWithValue("@new_status", comboBox1.SelectedIndex + 1);
                command.Parameters.AddWithValue("@new_balance", Int32.Parse(textBox5.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Аккаунт добавлен!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
            var client = new EnterTables(connection, tables);
            client.EnterClients();
            this.Close();
        }

        private void UpdateClient(int id)
        {
            connection.Open();
            var command = new NpgsqlCommand("update_subs", connection);
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@new_id", id);
                command.Parameters.AddWithValue("@new_surname", textBox1.Text);
                command.Parameters.AddWithValue("@new_name", textBox2.Text);
                command.Parameters.AddWithValue("@new_contact", BigInteger.Parse(textBox3.Text));
                command.Parameters.AddWithValue("@new_accnumber", BigInteger.Parse(textBox4.Text));
                command.Parameters.AddWithValue("@new_status", comboBox1.SelectedIndex + 1);
                command.Parameters.AddWithValue("@new_balance", Int32.Parse(textBox5.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Аккаунт изменен!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
            var client = new EnterTables(connection, tables);
            client.EnterClients();

            this.Close();
        }

        public void EnterInfo(int id)
        {
            var client = new Accounts();
            var str = $"SELECT surname, name, contact_number, account_number, status, balance from subscribers where id = '{id}'";
            var command = new NpgsqlCommand(str, connection);
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                textBox1.Text = reader.GetString(0);
                textBox2.Text = reader.GetString(1);
                textBox3.Text = reader.GetInt64(2).ToString();
                textBox4.Text = reader.GetInt64(3).ToString();
                comboBox1.SelectedIndex = reader.GetInt32(4) - 1;
                textBox5.Text = reader.GetInt32(5).ToString();
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

            var clients = new EnterTables(connection, tables);
            clients.EnterClients();
            this.Close();
        }

        public void StatusDictionary()
        {
            string str = "SELECT name FROM status";
            var teamList = Accounts.ComboboxValue(connection, str);
            var dictionaries = new ObservableCollection<StatusDictionary>();
            teamList.ForEach(Name => dictionaries.Add(new StatusDictionary() { IKey = String.Empty, IValue = Name }));
            comboBox1.DataSource = dictionaries.ToList();
        }
    }
}
