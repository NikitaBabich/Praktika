using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika
{
    public partial class FStudent : Form
    {
        static string conStr = "Data Source = Iris-NKB23;Initial Catalog=Praktika;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public FStudent()
        {
            InitializeComponent();
            Table<Student> students = context.GetTable<Student>();
            dataGridView1.DataSource = students.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte[] image;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                image = File.ReadAllBytes(nameFile);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Student newStudent = new Student
                    {
                        surname = textBox1.Text,
                        photo_s = image
                    };
                    context.GetTable<Student>().InsertOnSubmit(newStudent);
                    context.SubmitChanges();
                    MessageBox.Show("Данные добавлены", "Успешно");
                    textBox1.Text = "";
                    Table<Student> students = context.GetTable<Student>();
                    dataGridView1.DataSource = students.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте данные", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные", "Ошибка");
            }

        }
    }
}
