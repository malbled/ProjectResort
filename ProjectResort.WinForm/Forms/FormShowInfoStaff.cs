using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormShowInfoStaff : Form
    {
        public Staff staff { get; set; }
        public FormShowInfoStaff()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            string post = "";
            switch (WorkToUser.Staff.Post.ToString())
            {
                case "Administrator":
                    post = "Администратор";
                    break;
                case "Seller":
                    post = "Продавец";
                    break;
                case "ShiftSupervisor":
                    post = "Старший смены";
                    break;
            }
            label2.Text = "ФИО: " + WorkToUser.Staff.FIO.ToString();
            label3.Text = "Должность: " + post;
            if (WorkToUser.Staff.Image != null)
            {
                var image = Image.FromStream(new MemoryStream(WorkToUser.Staff.Image));
                pictureBox1.Image = image;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var image = File.ReadAllBytes(openFileDialog1.FileName);
                using (var db = new ResortContext())
                {
                    WorkToUser.Staff.Image = image;
                    db.Entry(WorkToUser.Staff).State = EntityState.Modified;
                    db.SaveChanges();
                }
                pictureBox1.Image = Image.FromStream(new MemoryStream(WorkToUser.Staff.Image));
            }
        }
    }
}
