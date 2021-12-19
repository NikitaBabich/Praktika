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
                    Table<Stud_group> Stud_groups = context.GetTable<Stud_group>();
                    dataGridView1.DataSource = Stud_groups.ToList();
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
            Stud_group currentStud_group = context.GetTable<Stud_group>().FirstOrDefault(x => x.id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            comboBox1.SelectedValue = currentStud_group.id_student;
            comboBox2.SelectedValue = currentStud_group.id_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Stud_group currentStud_group = context.GetTable<Stud_group>().FirstOrDefault(x => x.id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                currentStud_group.id_student = Convert.ToInt32(comboBox1.SelectedValue);
                currentStud_group.id_group = Convert.ToInt32(comboBox2.SelectedValue);
                context.SubmitChanges();
                MessageBox.Show("Данные изменены", "Успешно");
                Table<Stud_group> Stud_groups = context.GetTable<Stud_group>();
                dataGridView1.DataSource = Stud_groups.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте данные", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Удалить выбранную запись?", "Удаление", MessageBoxButtons.OKCancel);
            int id = 0;
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (d == DialogResult.OK && id != 0)
            {
                try
                {
                    Stud_group dc = context.GetTable<Stud_group>().FirstOrDefault(x => x.id == id);
                    context.GetTable<Stud_group>().DeleteOnSubmit(dc);
                    context.SubmitChanges();
                    Table<Stud_group> Students = context.GetTable<Stud_group>();
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
