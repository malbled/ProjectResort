using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ProjectResort.WinForm.Forms
{
    public partial class FormOrders : Form
    {
        public Order Order { get; set; }
        public FormOrders()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            using (var db = new ResortContext())
            {
                dataGridView1.DataSource = db.Orders.ToList();
            }
            btnCloseOrder.Enabled  = !WorkToUser.CompareRole(Context1.Enum.Post.Seller);
            menuItemHistory.Enabled = WorkToUser.CompareRole(Context1.Enum.Post.Administrator);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2" || dataGridView1.Columns[e.ColumnIndex].Name == "Column5")
            {
                if(e.Value != null){
                    DateTimeOffset myDate = (DateTimeOffset)e.Value;
                    e.Value = myDate.UtcDateTime;
                }
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Column6")
            {
                decimal myDec = (decimal)e.Value;
                int myInt = (int)myDec;
                e.Value = myInt;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                using (var db = new ResortContext())
                {
                    int myInt = Convert.ToInt32( e.Value);
                    var user = db.Clients.FirstOrDefault(x => x.KOD == myInt);
                    e.Value = user.FIO;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column7")
            {
                if((decimal)e.Value == default(decimal)) {
                    e.Value = "Заказ не закрыт";
                }
            }
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            var item = (Order)dataGridView1.SelectedRows[0].DataBoundItem;

            if (item != null)
            {
                using (var db = new ResortContext())
                {
                    var order = db.Orders.Include(x => x.Services).FirstOrDefault(x => x.Id == item.Id);
                    order.TotalPrice = order.Services.Sum(x => x.Price * (item.TimeRental / 60m));
                    order.Status = Context1.Enum.Status.Closed;
                    db.SaveChanges();
                    dataGridView1.DataSource = db.Orders.ToList();
                }
            }
        }

        private void menuItemReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void menuItemHistory_Click(object sender, EventArgs e)
        {
            var form = new FormHistory();
            form.Show();
            this.Close();
        }
    }
}
