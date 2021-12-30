using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagment.ProductForms.Popups
{
    using Main;

    public partial class UpdateProductPopupForm : Form
    {
        private ProductsForm _productsFrom;

        public UpdateProductPopupForm(ProductsForm productsForm)
        {
            InitializeComponent();
            CenterToScreen();

            _productsFrom = productsForm;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Barcode.Text))
            {
                // barcode is empty
                return;
            }

            int barcode = int.Parse(tb_Barcode.Text);

            if (!DBHelper.CheckDataValid(barcode))
            {
                // there is no product with this barcode
                return;
            }

            // fix the dot and comma problem
            if (tb_BuyPrice.Text.Contains(".")) tb_BuyPrice.Text = tb_BuyPrice.Text.Replace(".", ",");
            if (tb_SalePrice.Text.Contains(".")) tb_SalePrice.Text = tb_SalePrice.Text.Replace(".", ",");

            if (string.IsNullOrEmpty(tb_BuyPrice.Text)) tb_BuyPrice.Text = "0";
            
            double buyPrice = double.Parse(tb_BuyPrice.Text);
            double salePrice = double.Parse(tb_SalePrice.Text);

            DBHelper.UpdateData(barcode, tb_Name.Text, salePrice, buyPrice, cb_IsWeight.Checked);
            _productsFrom.RefreshGridView();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // textbox keypresses
        private void tb_BuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty(tb_BuyPrice.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_SalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty(tb_SalePrice.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
