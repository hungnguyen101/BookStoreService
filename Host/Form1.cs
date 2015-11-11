using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using BookStoreService.Implementation;

namespace Host
{
    public partial class Form1 : Form
    {
        ServiceHost product = null;
        ServiceHost category = null;
        ServiceHost account = null;
        ServiceHost group = null;
        ServiceHost promotion = null;
        ServiceHost order = null;
        public Form1()
        {
            InitializeComponent();
            product = new ServiceHost(typeof(ProductService));
            category = new ServiceHost(typeof(CategoryService));
            account = new ServiceHost(typeof(AccountService));
            group = new ServiceHost(typeof(GroupService));
            promotion = new ServiceHost(typeof(PromotionService));
            order = new ServiceHost(typeof(OrderService));
            product.Open();
            category.Open();
            account.Open();
            group.Open();
            promotion.Open();
            order.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblAlert.Text = "Host Started";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            product = new ServiceHost(typeof(ProductService));
            category = new ServiceHost(typeof(CategoryService));
            account = new ServiceHost(typeof(AccountService));
            group = new ServiceHost(typeof(GroupService));
            promotion = new ServiceHost(typeof(PromotionService));
            order = new ServiceHost(typeof(OrderService));
            product.Open();
            category.Open();
            account.Open();
            group.Open();
            promotion.Open();
            order.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblAlert.Text = "Host Started";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            product.Close();
            category.Close();
            account.Close();
            group.Close();
            order.Close();
            promotion.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblAlert.Text = "Host Stopped";
        }
    }
}
