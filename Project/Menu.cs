using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project
{
    public partial class Menu : Form
    {
        private OleDbConnection myConnection = new OleDbConnection();
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Menu()
        {
            InitializeComponent();
            myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=catalog.mdb;";
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'catalogDataSet.table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.catalogDataSet.table);
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myConnection.Open();
            string query = "SELECT NameGame, TypeGame FROM table";
            OleDbCommand command = new OleDbCommand(query, myConnection);

            OleDbDataReader reader = command.ExecuteReader();

            List<string[]> resume = new List<string[]>();

            while (reader.Read())
            {
                resume.Add(new string[10]);
                resume[resume.Count - 1][0] = reader[0].ToString();
                resume[resume.Count - 1][1] = reader[1].ToString();
                resume[resume.Count - 1][2] = reader[2].ToString();
                resume[resume.Count - 1][3] = reader[3].ToString();
                resume[resume.Count - 1][4] = reader[4].ToString();
                resume[resume.Count - 1][5] = reader[5].ToString();

            }
            reader.Close();
            myConnection.Close();

            foreach (string[] s in resume)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Validate();
            tableBindingSource.EndEdit();
            this.tableTableAdapter.Update(this.catalogDataSet);
            this.tableTableAdapter.Fill(this.catalogDataSet.table);
            //try
            //{

            //    myConnection.Open();
            //    OleDbCommand command = new OleDbCommand();
            //    command.Connection = myConnection;
            //    command.CommandText = "insert into table (NameGame, TypeGame, AgeGame, MissionGame, RulesGame) values('" + textBox1.Text + "', '" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";

            //    command.ExecuteNonQuery();
            //    MessageBox.Show("Успішно додано");

            //    myConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error " + ex);
            //    myConnection.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableBindingSource.Filter =  textBox1.Text + " = " + "\'" + textBox2.Text + "\'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableBindingSource.Sort = textBox3.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
