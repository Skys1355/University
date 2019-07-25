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
    public partial class add_std_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public add_std_form(Form1 main_form)
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
                if (textBox1.Text == "" | comboBox1.Text == "" | textBox2.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
                else
                {
                    dt = new DataTable();
                    ds = new DataSet();
                    query = "select [№ зачетной книжки] from Студент";
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
                            MessageBox.Show("Такое студент уже внесён");
                            return;
                        }
                        i++;
                    }

                    query = "insert into Студент([№ группы],[№ зачетной книжки],[ФИО]) values('" + comboBox1.Text + "','" + textBox1.Text + "','"+textBox2.Text+"');";
                    adapterSql = new SqlDataAdapter(query, connect);
                    adapterSql.Fill(ds);
                    dt.Dispose();
                    ds.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("№ зачетной книжки - числовое значение");
                
            }


                
            }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "SELECT * from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void add_std_form_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "select [№ группы] from Группа";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            int i = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox1.Items.Add(st);
                i++;
            }
            query = "SELECT * from Студент";
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
