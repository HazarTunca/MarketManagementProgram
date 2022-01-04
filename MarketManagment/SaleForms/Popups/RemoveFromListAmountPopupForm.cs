using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagement.SaleForms.Popups
{
    using ProductForms;

    public partial class RemoveFromListAmountPopupForm : Form
    {
        private SaleForm _saleForm;
        private int _barcode;
        private string _productName;
        private int _itemAmount;


        public RemoveFromListAmountPopupForm(SaleForm saleForm, int barcode, string productName, int itemAmount)
        {
            InitializeComponent();
            CenterToScreen();

            _saleForm = saleForm;
            _barcode = barcode;
            _productName = productName;
            _itemAmount = itemAmount;

            lbl_ProductName.Text = $"ürün ismi: {_productName}";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            int removingAmount = int.Parse(tb_Unit.Text);
            _saleForm.RemoveProductFromList(_barcode, removingAmount);
            this.Close();
        }

        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            _saleForm.RemoveProductFromList(_barcode, _itemAmount);
            this.Close();
        }

        private void tb_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
