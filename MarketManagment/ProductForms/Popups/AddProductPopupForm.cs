using MarketManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagement.ProductForms.Popups
{
    using Main;

    public partial class AddProductPopupForm : Form
    {
        private ProductsForm _productsForm;
        private bool _canConfirm;

        public AddProductPopupForm(ProductsForm productsForm)
        {
            InitializeComponent();
            CenterToScreen();

            _productsForm = productsForm;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            _canConfirm = true;

            // if specified areas are empty than give warn to user
            if (string.IsNullOrEmpty(tb_Barcode.Text) ||
                string.IsNullOrEmpty(tb_Name.Text) ||
                string.IsNullOrEmpty(tb_SalePrice.Text))
            {
                // lbl_BarcodeWarn.Text = "Barkod alanı boş bırakılamaz";
                _canConfirm = false;
            }

            if (!_canConfirm) return;

            // fix the dot and comma problem
            if (tb_BuyPrice.Text.Contains(".")) tb_BuyPrice.Text = tb_BuyPrice.Text.Replace(".", ",");
            if (tb_SalePrice.Text.Contains(".")) tb_SalePrice.Text = tb_SalePrice.Text.Replace(".", ",");

            if (string.IsNullOrEmpty(tb_BuyPrice.Text)) tb_BuyPrice.Text = "0";

            int barcode = int.Parse(tb_Barcode.Text);
            
            double buyPrice = double.Parse(tb_BuyPrice.Text);
            double salePrice = double.Parse(tb_SalePrice.Text);

            // insert the datas
            DBHelper.InsertData(barcode, tb_Name.Text, buyPrice, salePrice, cb_IsWeight.Checked);

            _productsForm.RefreshGridView();
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Only numbers can allow in text boxes
        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_BuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
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

            // only allow 2 decimal
            int cursorPosLeft = tb_BuyPrice.SelectionStart;
            int cursorPosRight = tb_BuyPrice.SelectionStart + tb_BuyPrice.SelectionLength;
            string result = tb_BuyPrice.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb_BuyPrice.Text.Substring(cursorPosRight);

            if (result.Contains("."))
            {
                string[] parts = result.Split('.');
                if (parts.Length > 1 && e.KeyChar != (char)Keys.Back)
                {
                    if (parts[1].Length > 2 || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (result.Contains(","))
            {
                string[] parts = result.Split(',');
                if (parts.Length > 1 && e.KeyChar != (char)Keys.Back)
                {
                    if (parts[1].Length > 2 || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void tb_SalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
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

            // only allow 2 decimal
            int cursorPosLeft = tb_SalePrice.SelectionStart;
            int cursorPosRight = tb_SalePrice.SelectionStart + tb_SalePrice.SelectionLength;
            string result = tb_SalePrice.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb_SalePrice.Text.Substring(cursorPosRight);

            if (result.Contains("."))
            {
                string[] parts = result.Split('.');
                if (parts.Length > 1 && e.KeyChar != (char)Keys.Back)
                {
                    if (parts[1].Length > 2 || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (result.Contains(","))
            {
                string[] parts = result.Split(',');
                if (parts.Length > 1 && e.KeyChar != (char)Keys.Back)
                {
                    if (parts[1].Length > 2 || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
