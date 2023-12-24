using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.Controller
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
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Абоненты", connection);
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
    }
}