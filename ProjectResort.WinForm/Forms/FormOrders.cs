using ProjectResort.Context1;
using ProjectResort.Context1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

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
                //decimal sum;
                //using (var db = new ResortContext())
                //{
                //    var order = db.Orders.Include(x => x.Services).FirstOrDefault(x => x.Id == (int)e.Value); 
                //    sum = order.Services.Sum(x => x.Price);
                //}
                //e.Value = sum.ToString();
                if((decimal)e.Value == default(decimal)) {
                    e.Value = "Заказ не закрыт";
                }
            }
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        //{
            
                
        //        var item =(Order) dataGridView1.SelectedRows[0].DataBoundItem;
        //    if(item != null )
        //    {
        //        using (var db = new ResortContext()) { 

        //        }
        //    }
            
        //    item.TotalPrice = 
        }
    }
}
