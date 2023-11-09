using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Telphone
{
    internal class Accounts
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Номер телефона")]
        public BigInteger ContactNumber { get; set; }
        [DisplayName("Лицевой счет")]
        public BigInteger AccountNumber { get; set; }
        [DisplayName("Баланс")]
        public int Balance { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }

        static public List<string> ComboboxValue(NpgsqlConnection connection, string str)
        {
            connection.Open();
            var status = new List<string>();
            NpgsqlCommand command = new NpgsqlCommand(str, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                status.Add(reader.GetString(0));
            }
            connection.Close();
            return status;
        }
    }
    public class StatusDictionary
    {
        private string _ikey;
        public string IKey
        {
            get
            {
                return _ikey;
            }
            set
            {
                _ikey = value;
            }
        }
        private string _ivalue;
        public string IValue
        {
            get
            {
                return _ivalue;
            }
            set
            {
                _ivalue = value;
            }
        }
        public override string ToString()
        {
            return _ivalue;
        }
    }
}
