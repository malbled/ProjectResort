using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormShowClients : Form
    {
        public FormShowClients()
        {
            InitializeComponent();
            Init();
            buttonEnter.Enabled = button1.Enabled = dataGridView1.Rows.Count != 0;
        }
        public void Init()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (var db = new ResortContext())
            {
                dataGridView1.DataSource = db.Clients.ToList();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                if (!(string.IsNullOrEmpty(textBox1.Text)))
                {
                    dataGridView1.DataSource = db.Clients.Where(p => p.FIO.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                }
                else
                {
                   Init();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAddClient();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var db = new ResortContext())
                {
                    db.Clients.Add(form.Client);
                    db.SaveChanges();
                }
                Init();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var item = (Client)dataGridView1.SelectedRows[0].DataBoundItem;

            if (item != null)
            {
                WorkToClient.Client = item;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column4")
            {
                if (e.Value != null)
                {
                    DateTimeOffset myDate = (DateTimeOffset)e.Value;
                    e.Value = myDate.DateTime.ToShortDateString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = (Client)dataGridView1.SelectedRows[0].DataBoundItem;
            if (item == null) return;
            using (var db = new ResortContext())
            {
                var item1 = db.Clients.FirstOrDefault(x => x.Id == item.Id);
                var form = new FormAddClient(item1);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.SaveChanges();
                    Init();
                }
            }
        }
    }
}
