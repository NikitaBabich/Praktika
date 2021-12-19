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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student currentStudent = context.GetTable<Student>().FirstOrDefault(x => x.id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            textBox1.Text = currentStudent.surname;
            image = currentStudent.photo_s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Student currentStudent = context.GetTable<Student>().FirstOrDefault(x => x.id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    currentStudent.surname = textBox1.Text;
                    currentStudent.photo_s = image;
                    context.SubmitChanges();
                    MessageBox.Show("Данные изменены", "Успешно");
                    Table<Student> Students = context.GetTable<Student>();
                    dataGridView1.DataSource = Students.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте данные", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите фамилию", "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Удалить выбранную запись?", "Удаление", MessageBoxButtons.OKCancel);
            int id = 0;
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (d == DialogResult.OK && id != 0)
            {
                try
                {
                    Student dc = context.GetTable<Student>().FirstOrDefault(x => x.id == id);
                    context.GetTable<Student>().DeleteOnSubmit(dc);
                    context.SubmitChanges();
                    Table<Student> Students = context.GetTable<Student>();
                    dataGridView1.DataSource = Students.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Данные нельзя удалить, так как могут быть нарушены связи в БД.");
                }
            }
        }
    }
}
