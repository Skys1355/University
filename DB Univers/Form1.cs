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
using System.Data.OleDb;


namespace DB_Univers
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public string connect, query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
        
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

       

        private void addinst_Click(object sender, EventArgs e)
        {
            add_inst_form add_inst_form = new add_inst_form(this);
            add_inst_form.Show();
            
        }

        private void addkaf_Click(object sender, EventArgs e)
        {
            add_kaf_form add_kaf_form = new add_kaf_form(this);
            add_kaf_form.Show();
        }

        private void addgrp_Click(object sender, EventArgs e)
        {
            add_grp_form add_grp_form = new add_grp_form(this);
            add_grp_form.Show();
        }

        private void addstd_Click(object sender, EventArgs e)
        {
            add_std_form add_std_form = new add_std_form(this);
            add_std_form.Show();
        }

        private void addauditor_Click(object sender, EventArgs e)
        {
            add_auditor_form add_auditor_form = new add_auditor_form(this);
            add_auditor_form.Show();
        }

        private void changeinst_Click(object sender, EventArgs e)
        {
            change_inst_form change_inst_form = new change_inst_form(this);
            change_inst_form.Show();
        }

        private void changekaf_Click(object sender, EventArgs e)
        {
            change_kaf_form change_kaf_form = new change_kaf_form(this);
            change_kaf_form.Show();
        }

        private void changegrp_Click(object sender, EventArgs e)
        {
            change_grp_form change_grp_form = new change_grp_form(this);
            change_grp_form.Show();
        }

        private void changestd_Click(object sender, EventArgs e)
        {
            change_std_form change_std_form = new change_std_form(this);
            change_std_form.Show();
        }

        private void changeauditor_Click(object sender, EventArgs e)
        {
            change_auditor_form change_auditor_form = new change_auditor_form(this);
            change_auditor_form.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void changeuchplan_Click(object sender, EventArgs e)
        {
            change_uchplan_form change_uchplan_form = new change_uchplan_form(this);
            change_uchplan_form.Show();
        }

        private void adduchplan_Click(object sender, EventArgs e)
        {
            add_uchplan_form add_uchplan_form = new add_uchplan_form(this);
            add_uchplan_form.Show();
        }

        private void uchplan_Click(object sender, EventArgs e)
        {
           
        }

        private void changeprepod_Click(object sender, EventArgs e)
        {
            change_prepod_form change_prepod_form = new change_prepod_form(this);
            change_prepod_form.Show();
        }

        private void addprepod_Click(object sender, EventArgs e)
        {
            add_prepod_form add_prepod_form = new add_prepod_form(this);
            add_prepod_form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add_prepodkaf_form add_prepodkaf_form = new add_prepodkaf_form(this);
            add_prepodkaf_form.Show();
        }

        private void addrasp_Click(object sender, EventArgs e)
        {
            add_rasp_form add_rasp_form = new add_rasp_form(this);
            add_rasp_form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            change_prepodkaf_form change_prepodkaf_form = new change_prepodkaf_form(this);
            change_prepodkaf_form.Show();
        }

        private void changerasp_Click(object sender, EventArgs e)
        {
            change_rasp_form change_rasp_form = new change_rasp_form(this);
            change_rasp_form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_attest_form add_attest_form = new add_attest_form(this);
            add_attest_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change_attest_form change_attest_form = new change_attest_form(this);
            change_attest_form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            del_kaf_form del_kaf_form = new del_kaf_form(this);
            del_kaf_form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            del_auditor_form del_auditor_form = new del_auditor_form(this);
            del_auditor_form.Show();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlCommandBuilder builder;
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    query = "select * from Расписание ";
                    adapterSql = new SqlDataAdapter(query, connect);
                    builder = new SqlCommandBuilder(adapterSql);
                    ds = new DataSet();
                    adapterSql.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра],Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
                    adapterSql = new SqlDataAdapter(query, connect);
                    ds = new DataSet();
                    adapterSql.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    query = " Select [ID УП] as 'группа-предмет',Группа+' '+Предмет группа_и_предмет from [Учебный план]";
                    adapterSql = new SqlDataAdapter(query, connect);
                    ds = new DataSet();
                    adapterSql.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = true;
                    dataGridView3.Visible = true;
                    break;

                case 1:

                    query = "select Аттестация.[ID Аттестации],Аттестация.Дата, Аттестация.Преподаватель, Аттестация.Предмет,Аттестация.[№ зачетной книжки], Аттестация.Оценка, Студент.ФИО from Аттестация INNER JOIN Студент ON Аттестация.[№ зачетной книжки]=Студент.[№ зачетной книжки]";
                    adapterSql = new SqlDataAdapter(query, connect);
                    builder = new SqlCommandBuilder(adapterSql);
                    ds = new DataSet();
                    adapterSql.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    ds.Dispose();
                    query = "SELECT Преподаватель_кафедра.[ID Преподаватель_кафедра] as 'Преподаватель',Преподаватель_кафедра.[Название кафедры]+' '+Преподаватель.[ФИО Преподавателя] as 'кафедра-ФИОпреподавателя' FROM Преподаватель_кафедра INNER JOIN Преподаватель ON Преподаватель_кафедра.[ID Преподавателя]=Преподаватель.[ID Преподавателя]";
                    adapterSql = new SqlDataAdapter(query, connect);
                    ds = new DataSet();
                    adapterSql.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = true;
                    dataGridView3.Visible = false;
                    break;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            del_group_form del_group_form = new del_group_form(this);
            del_group_form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Для печати необходимо заполнить таблицу");
                return;
            }
            int height = dataGridView1.Height;
            dataGridView1.Height = (dataGridView1.RowCount * dataGridView1.RowTemplate.Height) + 60;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 50, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 10, dataGridView1.Size.Height + 10);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            del_std_form del_std_form = new del_std_form(this);
            del_std_form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            del_prepod_form del_prepod_form = new del_prepod_form(this);
            del_prepod_form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            del_prepodkaf_form del_prepodkaf_form = new del_prepodkaf_form(this);
            del_prepodkaf_form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            del_uchplan_form del_uchplan_form = new del_uchplan_form(this);
            del_uchplan_form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            del_rasp_form del_rasp_form = new del_rasp_form(this);
            del_rasp_form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            del_attest_form del_attest_form = new del_attest_form(this);
            del_attest_form.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {            
            connect = @"Data Source="+textBox1.Text+";Initial Catalog="+textBox2.Text+";Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connect);
            try
            {
                myConnection.Open();
                myConnection.Close();
                MessageBox.Show("Подключено");
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                   
        }
    }
}
