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
    public partial class change_grp_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public change_grp_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void change_grp_form_Load(object sender, EventArgs e)
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
            query = "select * from Группа";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "select * from Группа";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | comboBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [№ группы] from Группа";
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
                        MessageBox.Show("Такая группа уже существует");
                        return;
                    }
                    i++;
                }

                query = "update Группа set [№ группы]='" + textBox1.Text + "' where [№ группы]='" + comboBox1.Text + "';";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
            }
        }
    }
}
