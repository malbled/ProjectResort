﻿using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using ProjectResort.WinForm.Forms;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.UserControl1
{
    public partial class ViewService : UserControl
    {
        public Service service { get; set; }
        public event Action<Service> AddToOrder;
        public ViewService(Service service)
        {
            InitializeComponent();
            this.service = service;
            InitTour(service);
        }
        public Service Service => service;
        private void InitTour(Service service)
        {
            label1.Text = service.Name;
            label2.Text = "Цена:  " + $"{service.Price:C2}";
            label3.Text = "Код услуги: " + service.KOD;

            if (service.Image != null)
            {
                var image = Image.FromStream(new MemoryStream(service.Image));
                pictureBox1.Image = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var image = File.ReadAllBytes(openFileDialog1.FileName);
                using (var db = new ResortContext())
                {
                    Service.Image = image;
                    db.Entry(Service).State = EntityState.Modified;
                    db.SaveChanges();
                }
                pictureBox1.Image = Image.FromStream(new MemoryStream(Service.Image));
            }
        }

        private void добавитьКЗаказуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToOrder?.Invoke(service);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new ResortContext())
            {
                var service1 = db.Services.FirstOrDefault(x => x.Id == service.Id);
                var form = new FormService(service1);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.SaveChanges();
                    InitTour(service1);
                }
            }
        }
    }
}
