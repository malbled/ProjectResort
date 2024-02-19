using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormHistory : Form
    {
        public EntryLog EntryLog { get; set; }
        public FormHistory()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            using (var db = new ResortContext())
            {
                dataGridView1.DataSource = db.EntryLogs.OrderByDescending(x => x.DateLog).ToList();
            }
        }

        private void окноЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormOrders();
            form.Show();
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2")
            {
                if (e.Value != null)
                {
                    DateTimeOffset myDate = (DateTimeOffset)e.Value;
                    e.Value = myDate.UtcDateTime;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                switch (e.Value.ToString())
                {
                    case "Success":
                        e.Value = "Успешно";
                        break;
                    case "UnSuccess":
                        e.Value = "Не успешно";
                        break;
                }
            }
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                var logins = db.EntryLogs.Select(m => m.StaffKod).Distinct();
                var types = logins.ToArray();
                var defaultType = "Все пользователи";

                comboBox1.Items.AddRange(types);
                comboBox1.Items.Insert(0, defaultType);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            using (var db = new ResortContext())
            {
                if (comboBox1.SelectedItem.ToString() == "Все пользователи" && radioButton1.Checked)
                    dataGridView1.DataSource = db.EntryLogs.OrderBy(x => x.DateLog).ToList();
                if (comboBox1.SelectedItem.ToString() == "Все пользователи" && radioButton2.Checked)
                    dataGridView1.DataSource = db.EntryLogs.OrderByDescending(x => x.DateLog).ToList();
                if (comboBox1.SelectedItem.ToString() != "Все пользователи" && radioButton1.Checked)
                    dataGridView1.DataSource = db.EntryLogs.Where(p => p.StaffKod == comboBox1.SelectedItem.ToString()).OrderBy(x => x.DateLog).ToList();
                if (comboBox1.SelectedItem.ToString() != "Все пользователи" && radioButton2.Checked)
                    dataGridView1.DataSource = db.EntryLogs.Where(p => p.StaffKod == comboBox1.SelectedItem.ToString()).OrderByDescending(x => x.DateLog).ToList();
            }
        }

        private void FormHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

