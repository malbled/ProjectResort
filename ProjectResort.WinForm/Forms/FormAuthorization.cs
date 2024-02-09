using System;
using System.Linq;
using System.Windows.Forms;
using ProjectResort.Context1;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
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

        private void btnEntry_Click(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                var user = db.Staffs.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPass.Text);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPass.Clear();
                }
                else
                {
                    var form = new FormMain();
                    form.Show();
                    this.Hide();
                }
            }
        }
    }
}
