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
    public partial class FGroup : Form
    {
        static string conStr = "Data Source = Iris-NKB23;Initial Catalog=Praktika;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public FGroup()
        {
            InitializeComponent();
            Table<Gruop> gruops = context.GetTable<Gruop>();
            dataGridView1.DataSource = gruops.ToList();
        }
        private void FGroup_Load(object sender, EventArgs e)
        {
            this.teacherTableAdapter.Fill(this.praktikaDataSet.Teacher);
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
            if (textBox1.Text!="" && textBox2.Text!="")
            {
                try
                {
                    Gruop newGruop = new Gruop
                    {
                        name = textBox1.Text,
                        year_of_graduation = Convert.ToInt32(textBox2.Text),
                        photo_g = image,
                        id_teacher = Convert.ToInt32(comboBox1.SelectedValue)
                    };
                    context.GetTable<Gruop>().InsertOnSubmit(newGruop);
                    context.SubmitChanges();
                    MessageBox.Show("Данные добавлены", "Успешно");
                    Table<Gruop> gruops = context.GetTable<Gruop>();
                    dataGridView1.DataSource = gruops.ToList();
                    textBox1.Text = "";
                    textBox2.Text = "";
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
