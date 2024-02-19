using ProjectResort.Context1.Models;
using System;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormService : Form
    {
        public Service Service { get; set; }
        public FormService()
        {
            InitializeComponent();
            Service = new Service();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public FormService(Service service) : this()
        {
            Service = service;
            txtName.Text = Service.Name;
            numericUpDown1.Value = Service.Price;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                Service.Name = txtName.Text;
                Service.Price = numericUpDown1.Value;
                Service.KOD = random.Next(1000, 450000).ToString();
            }
            else
                MessageBox.Show("Заполните поле 'Наименование'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
