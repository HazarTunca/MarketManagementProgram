using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagment.SaleForms.Popups
{
    public partial class AskAmountPopupForm : Form
    {
        private SaleForm _saleForm;
        private int _barcode;

        public AskAmountPopupForm(SaleForm saleForm, int barcode)
        {
            InitializeComponent();
            CenterToScreen();

            _saleForm = saleForm;
            _barcode = barcode;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_Amount.Text))
            {
                // cannot be empty
                return;
            }

            int amount = int.Parse(tb_Amount.Text);
            _saleForm.AddProductToList(_barcode, amount);
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
