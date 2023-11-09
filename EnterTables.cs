using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Telphone
{
    internal class EnterTables
    {
        public NpgsqlConnection connection;
        public Tables tables;
        public EnterTables(NpgsqlConnection connection, Tables tables)
        {
            this.connection = connection;
            this.tables = tables;
        }

        public void EnterClients()
        {
            tables.connection.Open();
            var listAccount = new List<Accounts>();
            var str = "SELECT * FROM accounts";
            var command = new NpgsqlCommand(str, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var accounts = new Accounts()
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    Surname = reader["surname"].ToString(),
                    Name = reader["name"].ToString(),
                    ContactNumber = BigInteger.Parse(reader["contact_number"].ToString()),
                    AccountNumber = BigInteger.Parse(reader["account_number"].ToString()),
                    Balance = Int32.Parse(reader["balance"].ToString()),
                    Status = reader["status"].ToString(),
                };
                listAccount.Add(accounts);
            }
            tables.dataGridView1.Visible = true;
            tables.dataGridView1.DataSource = listAccount;
            tables.dataGridView1.Columns[0].Visible = false;
            connection.Close();
        }

        public void EnterStatus()
        {
            tables.connection.Open();
            var listStatus = new List<Status>();
            var str = "select * from view_status";
            var command = new NpgsqlCommand(str, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var services = new Status()
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    Name = reader["name"].ToString(),
                    Count_Subs = reader["count_subs"].ToString(),
                };
                listStatus.Add(services);
            }
            tables.dataGridView1.Visible = true;
            tables.dataGridView1.DataSource = listStatus;
            tables.dataGridView1.Columns[0].Visible = false;
            connection.Close();
        }

        public void EnterServices()
        {
            tables.connection.Open();
            var listServices = new List<Services>();
            var str = "SELECT * FROM view_services";
            var command = new NpgsqlCommand(str, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var services = new Services()
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    NameServices = reader["name_service"].ToString(),
                    Price = Int32.Parse(reader["price"].ToString()),
                    Explain = reader["explain"].ToString(),
                    CountServices = Int32.Parse(reader["sum_services"].ToString())
                };
                listServices.Add(services);
            }
            tables.dataGridView1.Visible = true;
            tables.dataGridView1.DataSource = listServices;
            tables.dataGridView1.Columns[0].Visible = false;
            connection.Close();

        }
        public void EnterIndivAccount()
        {
            tables.connection.Open();
            var listAccount = new List<IndividualAccount>();
            var str = "SELECT * FROM view_indivacc";
            var command = new NpgsqlCommand(str, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var indAccounts = new IndividualAccount()
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    AccountNumber = BigInteger.Parse(reader["account_number"].ToString()),
                    NameService = reader["name_service"].ToString()
                };
                listAccount.Add(indAccounts);
            }
            tables.dataGridView1.Visible = true;
            tables.dataGridView1.DataSource = listAccount;
            tables.dataGridView1.Columns[0].Visible = false;
            connection.Close();
        }
    }
}
