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
    public partial class change_uchplan_form : Form
    {
        string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        public change_uchplan_form(Form1 main_form)
        {
            InitializeComponent();
            connect = main_form.connect;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == ""| comboBox5.Text == "" | comboBox6.Text == "" | comboBox7.Text == "" | comboBox8.Text == "" | comboBox9.Text == "" | comboBox10.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [ID УП] from [Учебный план]";
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
                        MessageBox.Show("Такой учебный план уже существует");
                        return;
                    }
                    i++;
                }
                query = "update [Учебный план] set [ID УП]='" + textBox1.Text + "' , Предмет='" + comboBox6.Text + "' , Группа='" + comboBox7.Text + "', [Вид аттестации]='"+comboBox8.Text+"', Семестр='"+comboBox9.Text+"', Часы='"+textBox2.Text+"' where [ID УП]=" + comboBox5.Text + " and Предмет='" + comboBox1.Text + "' and Группа='" + comboBox2.Text + "'and [Вид аттестации]='"+comboBox3.Text+"'and Семестр='"+comboBox4.Text+"'and Часы='"+comboBox10.Text+"';";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "select * from [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void change_uchplan_form_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "select [Название предмета] from Предмет";
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
            query = "select [№ группы] from Группа";
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
            query = "select [Вид аттестации] from [Вид аттестации]";
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
            query = "select Семестр from Семестр";
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
            query = "select [ID УП] from [Учебный план]";
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
            query = "select [Название предмета] from Предмет";
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
            query = "select [№ группы] from Группа";
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
            query = "select [Вид аттестации] from [Вид аттестации]";
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
            query = "select Семестр from Семестр";
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
            dt = new DataTable();
            ds = new DataSet();
            query = "select Часы from [Учебный план]";
            adapterSql = new SqlDataAdapter(query, connect);
            adapterSql.Fill(ds);
            dt = ds.Tables[0];
            i = 0;
            comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
            while (i < dt.Rows.Count)
            {
                string st = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]);
                comboBox10.Items.Add(st);
                i++;
            }
            query = "select * from [Учебный план]";
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
