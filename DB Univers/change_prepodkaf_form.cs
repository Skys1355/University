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
    public partial class change_prepodkaf_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public change_prepodkaf_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == "" | comboBox5.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [ID Преподаватель_кафедра] from Преподаватель_кафедра";
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
                        MessageBox.Show("Такой ID Преподаватель_кафедра уже существует");
                        return;
                    }
                    i++;
                }
                query = "update Преподаватель_кафедра set [ID Преподаватель_кафедра]='" + textBox1.Text + "' , [Название кафедры]='" + comboBox4.Text + "' , [ID Преподавателя]=(SELECT [ID Преподавателя] FROM Преподаватель where [ФИО Преподавателя]='"+comboBox5.Text+"') where [ID Преподаватель_кафедра]=" + comboBox3.Text + " and [Название кафедры]='" + comboBox1.Text + "' and [ID Преподавателя]=(SELECT [ID Преподавателя] FROM Преподаватель where [ФИО Преподавателя]='"+comboBox2.Text+"');";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
                query = "update Аттестация set Преподаватель='" + textBox1.Text + "' where Преподаватель='" + comboBox3.Text + "';";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
                query = "update Расписание set [ID Преподаватель_кафедра]='" + textBox1.Text + "' where [ID Преподаватель_кафедра]='" + comboBox3.Text + "';";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void change_prepodkaf_form_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "select [Название кафедры] from Кафедра";
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
            query = "select [ФИО Преподавателя] from Преподаватель";
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
            query = "select [ID Преподаватель_кафедра] from Преподаватель_кафедра";
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
            query = "select [Название кафедры] from Кафедра";
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
            query = "select [ФИО Преподавателя] from Преподаватель";
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
            
            query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
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
