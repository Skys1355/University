using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DB_Univers
{
    public partial class add_prepod_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public add_prepod_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                if (textBox1.Text == ""  | textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
                else
                {
                    dt = new DataTable();
                    ds = new DataSet();
                    query = "select [ID Преподавателя] from Преподаватель";
                    adapterSql = new SqlDataAdapter(query, connect);
                    adapterSql.Fill(ds);
                    dt = ds.Tables[0];
                    int i = 0;
                    string st;
                    while (i < dt.Rows.Count)
                    {
                        st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]).Replace(" ", "");
                        if (textBox1.Text == st)
                        {
                            MessageBox.Show("Такое Преподаватель уже внесён");
                            return;
                        }
                        i++;
                    }

                    query = "insert into Преподаватель([ID Преподавателя],[ФИО Преподавателя]) values('" + textBox1.Text + "','" + textBox2.Text + "');";
                    adapterSql = new SqlDataAdapter(query, connect);
                    adapterSql.Fill(ds);
                    dt.Dispose();
                    ds.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("ID Преподавателя - числовое значение");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "SELECT * from Преподаватель";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void add_prepod_form_Load(object sender, EventArgs e)
        {
            query = "SELECT * from Преподаватель";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
