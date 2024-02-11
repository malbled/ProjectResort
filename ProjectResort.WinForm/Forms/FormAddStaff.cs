using ProjectResort.Context1;
using ProjectResort.Context1.Enum;
using ProjectResort.Context1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormAddStaff : Form
    {
        public Staff Staff { get; set; }
        public FormAddStaff()
        {
            InitializeComponent();
            Staff = new Staff();
            cmbPost.DataSource = Enum.GetValues(typeof(Post));
            cmbPost.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFIO_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text)
                && !string.IsNullOrWhiteSpace(txtPass.Text) 
                && !string.IsNullOrWhiteSpace(txtFIO.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                Staff.Post = (Post)Enum.Parse(typeof(Post), cmbPost.SelectedItem.ToString());
                Staff.FIO = txtFIO.Text.ToString();
                Staff.Login = txtLogin.Text.ToString();
                Staff.Password = txtPass.Text.ToString();
                db.Staffs.Add(Staff);
                db.SaveChanges();

                var user = db.Staffs.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPass.Text);
                WorkToUser.Staff = user;

                this.Close();
            }
        }
    }
}
