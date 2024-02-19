using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormAddClient : Form
    {
        public Client Client { get; set; }
        int inty;
        public FormAddClient()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Now;
            var context = new ResortContext();
            var dop = context.Clients.OrderByDescending(x => x.KOD).FirstOrDefault();
            if (dop != null)
            {
                inty = dop.KOD+1;
            }
            else
            {
                inty = 4000;
            }
            if(txtKOD.Text == string.Empty)
            {
                txtKOD.Text = inty.ToString();
            }
            Client = new Client();
        }
        public FormAddClient(Client client) : this()
        {
            labelInfo.Text = "Редактирование клиента";
            Client = client;
            txtKOD.Text = client.KOD.ToString();
            txtFIO.Text = client.FIO;
            txtPassport.Text = client.Passport;
            dateTimePicker1.Value = client.DateBirth.DateTime;
            txtAddress.Text = client.Address;
            txtEmail.Text = client.Email;
            txtPassword.Text = client.Password;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFIO_TextChanged(object sender, EventArgs e)
        {
            btnEntry.Enabled = !string.IsNullOrWhiteSpace(txtKOD.Text)
                && !string.IsNullOrWhiteSpace(txtFIO.Text) 
                && !string.IsNullOrWhiteSpace(txtPassport.Text) 
                && !string.IsNullOrWhiteSpace(txtAddress.Text) 
                && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            Client.KOD = Convert.ToInt32( txtKOD.Text);
            Client.FIO = txtFIO.Text;
            Client.Passport = txtPassport.Text;
            Client.DateBirth = (DateTimeOffset) dateTimePicker1.Value;
            Client.Address = txtAddress.Text;
            Client.Email = txtEmail.Text;
            Client.Password = txtPassword.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
