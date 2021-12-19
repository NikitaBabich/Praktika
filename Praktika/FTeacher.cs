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
    public partial class FTeacher : Form
    {
        static string conStr = "Data Source = Iris-NKB23;Initial Catalog=Praktika;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public FTeacher()
        {
            InitializeComponent();
            Table<Teacher> teachers = context.GetTable<Teacher>();
            dataGridView1.DataSource = teachers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte[] image;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                Teacher newTeacher = new Teacher
                {
                surname = textBox1.Text,
                photo_t = image
                };
                context.GetTable<Teacher>().InsertOnSubmit(newTeacher);
                context.SubmitChanges();
                MessageBox.Show("Данные добавлены", "Успешно");
                textBox1.Text = "";
                Table<Teacher> teachers = context.GetTable<Teacher>();
                dataGridView1.DataSource = teachers.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте данные", "Лшибка");
                }
            }
            else
            {
                MessageBox.Show("Введите фамилию", "Ошибка");
            }            
        }

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
    }
}
