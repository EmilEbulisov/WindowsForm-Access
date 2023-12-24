using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;


namespace MTSProgram
{
    public partial class log : Form
    {
        bool a = false;
        public log()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // подключение файла базы данных
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=МТС.mdb");
            // запрос на проверку данных
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT COUNT(*) FROM [User] WHERE Login = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            Form1 ss = new Form1();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (a == true)
                {
                    this.Hide();
                    ss.Show();
                }
                else if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    button1.Visible = true;
                    a = true;
                }
                else
                {
                    this.Hide();
                    ss.Show();
                }
            }
            else
            {
                MessageBox.Show("Неправильно введен Логин и (или) Пароль");
            }
        }
    }
}