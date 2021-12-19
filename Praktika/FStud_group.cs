using System;
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
    public partial class FStud_group : Form
    {
        static string conStr = "Data Source = Iris-NKB23;Initial Catalog=Praktika;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public FStud_group()
        {
            InitializeComponent();
            Table<Stud_group> zapros = context.GetTable<Stud_group>();
            dataGridView1.DataSource = zapros.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FStud_group_Load(object sender, EventArgs e)
        {
            this.groupTableAdapter.Fill(this.praktikaDataSet.Group);
            this.studentTableAdapter.Fill(this.praktikaDataSet.Student);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue !=null && comboBox2.SelectedValue != null)
            {
                try
                {
                    Stud_group newStud_group = new Stud_group
                    {
                        id_student = Convert.ToInt32(comboBox1.SelectedValue),
                        id_group = Convert.ToInt32(comboBox2.SelectedValue)
                    };
                    context.GetTable<Stud_group>().InsertOnSubmit(newStud_group);
                    context.SubmitChanges();
                    MessageBox.Show("Данные добавлены", "Успешно");
                    Table<Stud_group> zapros = context.GetTable<Stud_group>();
                    dataGridView1.DataSource = zapros.ToList();
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
