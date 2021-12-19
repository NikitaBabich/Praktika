﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika
{
    public partial class Main : Form
    {
        static string conStr = "Data Source = Iris-NKB23;Initial Catalog=Praktika;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Table<Student> students = context.GetTable<Student>();
                dataGridView1.DataSource = students.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Table<Gruop> gruops = context.GetTable<Gruop>();
                dataGridView1.DataSource = gruops.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Table<Teacher> teachers = context.GetTable<Teacher>();
                dataGridView1.DataSource = teachers.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                Table<Stud_group> zapros = context.GetTable<Stud_group>();
                dataGridView1.DataSource = zapros.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                FStudent f = new FStudent();
                f.Show();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                FGroup f = new FGroup();
                f.Show();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                FTeacher f = new FTeacher();
                f.Show();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                FStud_group f = new FStud_group();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Table<Student> students = context.GetTable<Student>();
                dataGridView1.DataSource = students.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Table<Gruop> gruops = context.GetTable<Gruop>();
                dataGridView1.DataSource = gruops.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Table<Teacher> teachers = context.GetTable<Teacher>();
                dataGridView1.DataSource = teachers.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                Table<Stud_group> zapros = context.GetTable<Stud_group>();
                dataGridView1.DataSource = zapros.ToList();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                //фильтрация
            }
            if (comboBox1.SelectedIndex == 1)
            {
                //фильтрация
            }
            if (comboBox1.SelectedIndex == 2)
            {
                //фильтрация
            }
            if (comboBox1.SelectedIndex == 3)
            {
                //фильтрация
            }
        }
    }
}
