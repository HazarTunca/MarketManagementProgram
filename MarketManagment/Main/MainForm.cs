using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagment.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            CenterToScreen();
            this.Text = "Market Manager by Hzr Ticaret";

            
        }

        // Go to sale form
        private void btn_Sale_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaleForms.SaleForm saleForm = new SaleForms.SaleForm();

            saleForm.WindowState = WindowState;
            saleForm.Location = this.Location;
            saleForm.StartPosition = FormStartPosition.Manual;

            saleForm.ShowDialog();
            this.Close();
        }

        // Go to products form
        private void btn_Products_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForms.ProductsForm productsForm = new ProductForms.ProductsForm();

            productsForm.WindowState = WindowState;
            productsForm.Location = this.Location;
            productsForm.StartPosition = FormStartPosition.Manual;

            productsForm.ShowDialog();
            this.Close();
        }
    }
}
