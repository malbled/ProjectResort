using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            label1.Text = "ФИО: " + WorkToUser.Staff.FIO.ToString();
            label2.Text = "Должность: " + WorkToUser.Staff.Post.ToString();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void клиентыToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var form = new FormShowClients();
            form.Show();
        }
    }
}
