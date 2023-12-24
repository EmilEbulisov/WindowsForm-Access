using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTSProgram.Controller;
using System.Data.OleDb;

namespace MTSProgram
{
    public partial class Form1 : Form
    {
        Query controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdateAbonents();
        }

        private void button4_Click(object sender, EventArgs e)//кнопка выхода [Х]
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateAbonents();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["счет"].Value.ToString()));
        }
    }
}
