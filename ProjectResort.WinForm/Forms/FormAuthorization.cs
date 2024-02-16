using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormAuthorization : Form
    {
        public EntryLog EntryLog { get; set; }
        public FormAuthorization()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
            EntryLog = new EntryLog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            btnEntry.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text)
                && !string.IsNullOrWhiteSpace(txtPass.Text);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else if (checkBox1.Checked == false)
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                var user = db.Staffs.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPass.Text);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPass.Clear();

                    EntryLog.DateLog = DateTime.Now;
                    EntryLog.StaffKod = txtLogin.Text.ToString();
                    EntryLog.TypeEntry = Context1.Enum.TypeEntry.UnSuccess;  
                }
                else
                {
                    EntryLog.DateLog = DateTime.Now;
                    EntryLog.StaffKod = user.Login;
                    EntryLog.TypeEntry = Context1.Enum.TypeEntry.Success;
                    WorkToUser.Staff = user;

                    var form = new FormOrders();
                    form.Show();
                    var form1 = new FormShowInfoStaff();
                    form1.Show();
                    this.Hide();
                }
                db.EntryLogs.Add(EntryLog);
                db.SaveChanges();
            }
        }     
    }
}
