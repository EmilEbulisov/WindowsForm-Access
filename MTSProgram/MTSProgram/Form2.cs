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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MTSProgram
{
    public partial class Form2 : Form
    {
        Query controller;
        public Form2()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdateUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.AddUser(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.DeleteUser(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateUser();
            textBox1.Clear();
            textBox2.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();        
        }
    }
}
