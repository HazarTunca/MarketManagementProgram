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
    public partial class RemoveShortcutButtonPopupForm : Form
    {
        SaleForm _saleForm;

        public RemoveShortcutButtonPopupForm(SaleForm saleForm)
        {
            InitializeComponent();
            CenterToScreen();
            _saleForm = saleForm;
        }

        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Confirm();

            this.Close();
        }

        private void Confirm()
        {
            // barcode cannot be empty
            if (String.IsNullOrEmpty(tb_Barcode.Text))
            {

                return;
            }

            int barcode = int.Parse(tb_Barcode.Text);

            _saleForm.RemoveShortcutButton(barcode);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
