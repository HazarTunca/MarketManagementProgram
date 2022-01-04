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

    public partial class UpdateProductPopupForm : Form
    {
        private ProductsForm _productsFrom;
        private int _checkedBarcode;

        public UpdateProductPopupForm(ProductsForm productsForm)
        {
            InitializeComponent();
            CenterToScreen();

            _productsFrom = productsForm;
        }
        public UpdateProductPopupForm(ProductsForm productsForm, int barcode, string name, double salePrice, double buyPrice, bool isWeight)
        {
            InitializeComponent();
            CenterToScreen();

            _productsFrom = productsForm;

            tb_Barcode.Text = barcode.ToString();
            tb_Name.Text = name;
            tb_SalePrice.Text = salePrice.ToString();
            tb_BuyPrice.Text = buyPrice.ToString();
            cb_IsWeight.Checked = isWeight;
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

            DBHelper.UpdateData(barcode, tb_Name.Text, buyPrice, salePrice, cb_IsWeight.Checked);
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

        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_Barcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Barcode.Text))
            {
                tb_Name.Clear();
                tb_SalePrice.Clear();
                tb_BuyPrice.Clear();
                cb_IsWeight.Checked = false;
                return;
            }

            _checkedBarcode = Convert.ToInt32(tb_Barcode.Text);
            if (!DBHelper.CheckDataValid(_checkedBarcode))
            {
                tb_Name.Clear();
                tb_SalePrice.Clear();
                tb_BuyPrice.Clear();
                cb_IsWeight.Checked = false;
                return;
            }

            string productName = DBHelper.GetProductName(_checkedBarcode);
            double salePrice = DBHelper.GetProductPrice(_checkedBarcode);
            double buyPrice = DBHelper.GetProductBuyPrice(_checkedBarcode);
            bool isWeight = DBHelper.GetProductIsWeight(_checkedBarcode);

            tb_Name.Text = productName;
            tb_SalePrice.Text = salePrice.ToString();
            tb_BuyPrice.Text = buyPrice.ToString();
            cb_IsWeight.Checked = isWeight;
        }
    }
}
