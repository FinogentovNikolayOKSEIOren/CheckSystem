using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp17.Models;

namespace WindowsFormsApp17
{
    public partial class Form2 : Form
    {
        CheckEntities Model = new CheckEntities();

        public Form2()
        {
            InitializeComponent();

            UpdateData();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (FormPrikazGrid.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in FormPrikazGrid.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Формы_приказа.Remove(Model.Формы_приказа
                            .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (NamePrikaz.Text != "")
            {

                Model.Формы_приказа.Add(
                 new Формы_приказа { Наименование = NamePrikaz.Text }
                );
                Model.SaveChanges();
                UpdateData();
            }
            else
            {

                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NameDolj.Text != "")
            {

                Model.Должности.Add(
                 new Должности { Наименование = NameDolj.Text }
                );
                Model.SaveChanges();
                UpdateData();
        }
            else
            {

                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}

        private void button6_Click(object sender, EventArgs e)
        {
            if(DoljGrid.SelectedCells.Count!= 0)
            {
                foreach (DataGridViewCell cell in DoljGrid.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Должности.Remove(Model.Должности
                            .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateData()
        {
            DoljGrid.AutoGenerateColumns = false;
            DoljGrid.DataSource = Model.Должности.ToList();
            Doljn.DataSource = Model.Должности.ToList();
            SpecialGrid.AutoGenerateColumns = false;
            SpecialGrid.DataSource = Model.Специалисты.ToList();
            GridMo.AutoGenerateColumns = false;
            GridMo.DataSource = Model.Муниципальные_образования.ToList();
            GridOO.AutoGenerateColumns = false;
            GridOO.DataSource = Model.Образовательные_организации.ToList();
            MunObr.DataSource = Model.Муниципальные_образования.ToList();
            PrikazGrid.AutoGenerateColumns = false;
            PrikazGrid.DataSource = Model.Приказы.ToList();
            FormPrikazGrid.AutoGenerateColumns = false;
            FormPrikazGrid.DataSource = Model.Формы_приказа.ToList();
            PrisutGrid.AutoGenerateColumns = false;
            PrisutGrid.DataSource = Model.Присутствующие_при_проверке.ToList();
            Proverka.DataSource = Model.Проверка.ToList();
            FormaPrikaza.DataSource = Model.Формы_приказа.ToList();


            MunObr.DisplayMember = "Наименование";
            MunObr.ValueMember = "Код_муниципального_образования";
            Doljn.DisplayMember = "Наименование";
            Doljn.ValueMember = "Код_должности";
            FormaPrikaza.DisplayMember = "Наименование";
            FormaPrikaza.ValueMember = "Код_формы_приказа";
            Proverka.DisplayMember = "Код_проверки";
            Proverka.ValueMember = "Код_проверки";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SurNameSpec.Text != "" && NameSpec.Text != "" && Doljn.SelectedIndex!= -1)
            {
                Специалисты newSpec = new Специалисты
                {
                    Фамилия = SurNameSpec.Text,
                    Имя = NameSpec.Text,
                    Отчество = PatronymicSpec.Text,
                    Должности = (Doljn.SelectedItem as Должности)
                };
                Model.Специалисты.Add(newSpec);                   
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SurNameSpec_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (NameMO.Text != "")
            {

                Model.Муниципальные_образования.Add(
                 new Муниципальные_образования { Наименование = NameMO.Text }
                );
                Model.SaveChanges();
                UpdateData();
            }
            else
            {

                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (GridMo.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in GridMo.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Муниципальные_образования.Remove(Model.Муниципальные_образования
                            .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (NameOO.Text != "" && SokrNameOO.Text != "" && Address.Text != "" && MunObr.SelectedIndex!= -1)
            {
                Образовательные_организации newOO = new Образовательные_организации
                {
                    Наименование = NameOO.Text,
                    Сокращенное_наименование = SokrNameOO.Text,
                    Адрес = Address.Text,
                    Муниципальные_образования = (MunObr.SelectedItem as Муниципальные_образования)
                };
                Model.Образовательные_организации.Add(newOO);
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridOO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (NomerPrikaza.Text != "" && DataPrikaza.Text != "" && FormaPrikaza.SelectedIndex != -1)
            {
                 Приказы newPrikaz = new Приказы
                {
                    Номер_приказа = NomerPrikaza.Text,
                    Дата_приказа =  DateTime.Parse(DataPrikaza.Text),
                    Формы_приказа = (FormaPrikaza.SelectedItem as Формы_приказа)
                };
                Model.Приказы.Add(newPrikaz);
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MunObr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SpecialGrid.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in SpecialGrid.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Специалисты.Remove(Model.Специалисты
                            .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (SurNamePrisut.Text != "" && NamePrisut.Text != "" && PatronumicPrisut.Text != "" && DoljnostPrisut.Text != "" && Proverka.SelectedIndex != -1)
                
            {
                 Присутствующие_при_проверке newPrisut = new Присутствующие_при_проверке
                {
                    Фамилия = SurNamePrisut.Text,
                    Имя = NamePrisut.Text,
                    Отчество = PatronumicPrisut.Text,
                    Должность = DoljnostPrisut.Text,
                    Проверка = (Proverka.SelectedItem as Проверка)
                };
                Model.Присутствующие_при_проверке.Add(newPrisut);
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (PrikazGrid.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in PrikazGrid.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Приказы.Remove(Model.Приказы
                        .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (PrisutGrid.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in PrisutGrid.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Присутствующие_при_проверке.Remove(Model.Присутствующие_при_проверке
                       .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (GridOO.SelectedCells.Count != 0)
            {
                foreach (DataGridViewCell cell in GridOO.SelectedCells)
                {
                    if (cell.Selected)
                        Model.Образовательные_организации.Remove(Model.Образовательные_организации
                       .Find(int.Parse(cell.OwningRow.Cells[0].Value.ToString())));
                }
                Model.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Не выбранны ячейки", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrikazGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Model.SaveChanges();
        }
    }
}
