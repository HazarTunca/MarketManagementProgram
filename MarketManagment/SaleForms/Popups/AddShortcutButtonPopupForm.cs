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
    public partial class AddShortcutButtonPopupForm : Form
    {
        private SaleForm _saleForm;

        public AddShortcutButtonPopupForm(SaleForm saleForm)
        {
            InitializeComponent();
            CenterToScreen();
            _saleForm = saleForm;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Confirm();

            this.Close();
        }

        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Confirm()
        {
            // barcode cannot be empty
            if (string.IsNullOrEmpty(tb_Barcode.Text))
            {

                return;
            }

            int barcode = int.Parse(tb_Barcode.Text);

            _saleForm.AddShortcutButton(barcode);
        }
    }
}
