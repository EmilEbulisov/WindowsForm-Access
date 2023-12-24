using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MTSProgram.Controller
{
    internal class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();

        }

        public DataTable UpdateAbonents()//метод обновления
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Абонент", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }

        public void Add(string Фамилия, string Имя, int Телефон)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Абонент(Фамилия, Имя, Телефон) VALUES(@Фамилия, @Имя, Телефон)", connection);
            command.Parameters.AddWithValue("Фамилия", Фамилия);
            command.Parameters.AddWithValue("Имя", Имя);
            command.Parameters.AddWithValue("Телефон", Телефон);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int счет)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Абонент WHERE счет = {счет}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable UpdateUser()//метод обновления
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM [User]", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }

        public void AddUser(string Login, string Password)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [User](Login, Password) VALUES (@Login, @Password", connection);
            command.Parameters.AddWithValue("Login", Login);
            command.Parameters.AddWithValue("Password", Password);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteUser(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM [User] WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
