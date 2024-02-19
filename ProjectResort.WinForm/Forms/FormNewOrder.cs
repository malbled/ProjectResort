using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using ProjectResort.WinForm.UserControl1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormNewOrder : Form
    {
        bool check;
        private Dictionary<Service, int> Services = new Dictionary<Service, int>();
        public Order Order { get; set; }
        public FormNewOrder()
        {
            InitializeComponent();
        }
        private void VisibleList(Service service)
        {
            if (Services.TryGetValue(service, out var count))
            {
                Services[service] = ++count;
            }
            else
            {
                Services.Add(service, 1);
            }
            PrintOrder();
        }

        private void FormNewOrder_Load(object sender, EventArgs e)
        {
            Print();
        }
        public void Print()
        {
            using (var db = new ResortContext())
            {
                var services = db.Services.ToList();

                foreach (var service in services)
                {
                    var viewService = new ViewService(service);
                    viewService.AddToOrder += VisibleList;
                    viewService.Parent = flowLayoutPanel1;
                }
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            var form = new FormShowClients();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                labelFIO.Text = "ФИО Клиента: " + WorkToClient.Client.FIO;
            }
            EnableButton();
        }

        private void btnOpenOrder_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var order = new Order
            {
                Status = Context1.Enum.Status.New,
                DateAdd = DateTimeOffset.Now,
                ClientKod = WorkToClient.Client.KOD.ToString(),
                KOD = WorkToClient.Client.KOD + "/" + DateTime.Now.ToShortDateString()
        };

            using (var db = new ResortContext())
            {
                var Ids = Services.Keys.Select(x => x.Id).ToList();
                var tours = db.Services.Where(x => Ids.Contains(x.Id)).ToList();
                order.Services = tours;
                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show($"Заказ открыт!\nНомер заказа:  {order.KOD}", "ИГОРА", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormOrders main = this.Owner as FormOrders;
                main.Init();
                this.Close();
            }
        }

        private void PrintOrder()
        {
            listBox1.Items.Clear();
            foreach (var item in Services.Keys)
            {
                listBox1.Items.Add($"{item.Name} x{Services[item]}");
            }
            EnableButton();
        }
        private void EnableButton()
        {
            if (listBox1.Items.Count != 0 && WorkToClient.Client.Id != -1)
            {
                btnOpenOrder.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var form1 = new FormService();

            if (form1.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new ResortContext())
                {
                    db.Services.Add(form1.Service);
                    db.SaveChanges();
                }
            }
            var view = new ViewService(form1.Service);
            view.Parent = flowLayoutPanel1;
        }
    }
}
