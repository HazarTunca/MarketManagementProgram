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
    public partial class AskWeightPopupForm : Form
    {
        private SaleForm _saleForm;
        private int _barcode;

        public AskWeightPopupForm(SaleForm saleForm, int barcode)
        {
            InitializeComponent();
            CenterToScreen();

            _saleForm = saleForm;
            _barcode = barcode;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Weight.Text))
            {
                // cannot be empty
                return;
            }

            double weight = double.Parse(tb_Weight.Text);
            _saleForm.AddProductToList(_barcode, weight);
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
