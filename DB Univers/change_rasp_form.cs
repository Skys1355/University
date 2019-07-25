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
    public partial class change_rasp_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public change_rasp_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" |  comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == "" | comboBox5.Text == "" | comboBox6.Text == "" | comboBox7.Text == "" | comboBox8.Text == "" | comboBox9.Text == "" )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [ID Расписание] from Расписание";
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
                        MessageBox.Show("Такое расписание уже существует");
                        return;
                    }
                    i++;
                }
                query = "update Расписание set [ID Расписание]='" + textBox1.Text + "' , [ID Преподаватель_кафедра]='" + comboBox2.Text + "' , [№ аудитории]='" + comboBox4.Text + "', Время='" + comboBox6.Text + "', [группа-предмет]='" + comboBox8.Text + "' where [ID Расписание]=" + comboBox9.Text + " and [ID Преподаватель_кафедра]='" + comboBox1.Text + "' and [№ аудитории]='" + comboBox3.Text + "'and Время='" + comboBox5.Text + "'and [группа-предмет]='" + comboBox7.Text + "';";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "select * from Расписание";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя]  as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            query = " Select [ID УП] as 'группа-предмет',Группа+' '+Предмет группа_и_предмет from [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void change_rasp_form_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "SELECT [ID Преподаватель_кафедра] From Преподаватель_кафедра";
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
            query = "SELECT [ID Преподаватель_кафедра] From Преподаватель_кафедра";
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
            query = "select [№ аудитории] from Аудитория";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox3.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "select [№ аудитории] from Аудитория";
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
            dt = new DataTable();
            ds = new DataSet();
            query = "select Время from Время";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox5.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "select Время from Время";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox6.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "SELECT [ID УП] From [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox7.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "SELECT [ID УП] From [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox8.Items.Add(st);
                i++;
            }
            dt = new DataTable();
            ds = new DataSet();
            query = "SELECT [ID Расписание] from Расписание";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox9.Items.Add(st);
                i++;
            }
            query = "select * from Расписание";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя]  as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            query = " Select [ID УП] as 'группа-предмет',Группа+' '+Предмет группа_и_предмет from [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

