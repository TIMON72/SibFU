using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.classes; // подключаем пакет classes с пользовательскими классами

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static List<Company> companies = new List<Company>();
        static List<Realtor> realtors = new List<Realtor>();
        static List<RealEstate> realEstates = new List<RealEstate>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Push on "Добавить" (фирма)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != string.Empty)
            {
                Company new_company = new Company();
                new_company.name = maskedTextBox1.Text;
                ListViewItem new_item = new ListViewItem(maskedTextBox1.Text);
                companies.Add(new_company);
                listView1.Items.Add(new_item);
            }
            else
            {
                MessageBox.Show("Введите название фирмы");
            }
        }
        /// <summary>
        /// Push on "Добавить" (риелтор)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (maskedTextBox2.Text == string.Empty)
            {
                MessageBox.Show("Вы не заполнили поле реелтора");
                return;
            }
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Выберите фирму для связывания риелтора с фирмой");
                return;
            }
            index = listView1.SelectedIndices[0]; // Получаем индекс выделенного эл-та
            Realtor new_realtor = new Realtor();
            new_realtor.name = maskedTextBox2.Text;
            Company company = companies[index];
            company.realtors.Add(new_realtor);
        }
        /// <summary>
        /// Push on "Добавить" (недвижимость)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (maskedTextBox3.Text == string.Empty)
            {
                MessageBox.Show("Вы не заполнили поле недвижимости");
                return;
            }
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Выберите фирму для связывания адреса недвижимости с фирмой");
                return;
            }
            index = listView1.SelectedIndices[0]; // Получаем индекс выделенного эл-та
            RealEstate new_realEstate = new RealEstate();
            new_realEstate.address = maskedTextBox3.Text;
            Company company = companies[index];
            company.realEstates.Add(new_realEstate);
        }
        /// <summary>
        /// Event highlight an item in the listView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = -1;
            if (listView1.SelectedIndices.Count > 0)
            {
                index = listView1.SelectedIndices[0];
                listView2.BeginUpdate();
                listView2.Items.Clear();
                listView3.BeginUpdate();
                listView3.Items.Clear();
                realtors = companies[index].realtors;
                realEstates = companies[index].realEstates;
                for (int i = 0; i < realtors.Count; i++)
                {

                    ListViewItem item = new ListViewItem(realtors[i].name);
                    listView2.Items.Add(item);
                }
                for (int i = 0; i < realEstates.Count; i++)
                {
                    ListViewItem item = new ListViewItem(realEstates[i].address);
                    listView3.Items.Add(item);
                }
                listView2.EndUpdate();
                listView3.EndUpdate();
            }
            else
            {
                return;
            }
        }
    }
}
