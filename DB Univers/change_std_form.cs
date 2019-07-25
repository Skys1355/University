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
    public partial class change_std_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public change_std_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void change_std_form_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            dt = new DataTable();
            ds = new DataSet();
            query = "select [№ зачетной книжки] from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            int i = 0;            
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox1.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "select [№ группы] from Группа";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox2.Items.Add(st);
                comboBox3.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "select [ФИО] from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox4.Items.Add(st);
                i++;
            }
            query = "select * from Студент";
            adapterSql = new SqlDataAdapter(query, connect);            
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*query = "select [№ группы] from Группа where [№ зачетной книжки]='" + comboBox1.Text + "'";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            int i = 0;
            while (i < dt.Rows.Count)
            {
                label7.Text = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);

                i++;

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "select * from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            
                n = Convert.ToInt32(textBox1.Text);
                if (textBox1.Text == "" | comboBox1.Text == "" | textBox2.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == "")
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
                            MessageBox.Show("Такой студент уже существует");
                            return;
                        }
                        i++;
                    }

                    query = "update Студент set [№ зачетной книжки]=" + Convert.ToInt32(textBox1.Text) + " , [№ группы]='"+ comboBox3.Text+"' , ФИО='"+textBox2.Text+"' where [№ зачетной книжки]=" +Convert.ToInt32( comboBox1.Text) + " and [№ группы]='"+comboBox2.Text+"' and ФИО='"+comboBox4.Text+"';";
                    adapterSql = new SqlDataAdapter(query, connect);
                    adapterSql.Fill(ds);
                    dt.Dispose();
                    ds.Dispose();
                }
            }
            
        }
    }

