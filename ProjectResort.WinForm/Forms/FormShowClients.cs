using ProjectResort.Context1;
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
            dataGridView1.AutoGenerateColumns = false;
            using (var db = new ResortContext())
            {
                dataGridView1.DataSource = db.Clients.ToList();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                for(int j = 0;  j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        break;
                    }
                }
            }

            if(textBox1.Text == string.Empty)
            {
                dataGridView1.ClearSelection();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAddClient();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var db = new ResortContext())
                {
                    //db.Clients.Add(form.Tour);
                    db.SaveChanges();
                }
            }
        }

    }
}
