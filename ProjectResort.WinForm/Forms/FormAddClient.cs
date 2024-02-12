using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormAddClient : Form
    {
        public Client Client { get; set; }
        public FormAddClient()
        {
            InitializeComponent();
            Client = new Client();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormAddClient(Client client) : this()
        {
            Client = client;
            txtFIO.Text = client.FIO;
            txtPassport.Text = client.Passport;
            dateTimePicker1.Value = Convert.ToDateTime(client.DateBirth);
            txtAddress.Text = client.Address;
            txtEmail.Text = client.Email;
            txtPassword.Text = client.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context = new ResortContext();
            var dop = context.Clients.OrderByDescending(x => x.KOD).FirstOrDefault();
            var inty = dop.KOD;
            Client.KOD = inty + 1;
            Client.FIO = txtFIO.Text;
            Client.Passport = txtPassport.Text;
            Client.DateBirth = dateTimePicker1.Value;
            Client.Address = txtAddress.Text;
            Client.Email = txtEmail.Text;
            Client.Password = txtPassword.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
