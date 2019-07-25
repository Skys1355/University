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
    public partial class add_attest_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public add_attest_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [ID Аттестации] from Аттестация";
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
                        MessageBox.Show("Такая аттестация уже существует");
                        return;
                    }
                    i++;
                }
                if (dateTimePicker1.Value >= DateTime.Now)
                {
                    MessageBox.Show("Такой день еще не наступил");
                    return;
                }

                query = "insert into Аттестация ([ID Аттестации],Дата,Преподаватель,Предмет,[№ зачетной книжки],Оценка) values('"+textBox1.Text+"','"+dateTimePicker1.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"',"+Convert.ToInt32(comboBox4.Text)+",'"+comboBox3.Text+"');";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            query = "SELECT * from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            query = "SELECT * from Аттестация";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void add_attest_form_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "select [ID Преподаватель_кафедра] from Преподаватель_кафедра";
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
            dt = new DataTable();
            ds = new DataSet();
            query = "select [Название предмета] From Предмет";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox2.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "select [№ зачетной книжки] from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
             i = 0;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox4.Items.Add(st);
                i++;
            }
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            query = "SELECT * from Студент";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            query = "SELECT * from Аттестация";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            dataGridView2.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeRowsMode =DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
