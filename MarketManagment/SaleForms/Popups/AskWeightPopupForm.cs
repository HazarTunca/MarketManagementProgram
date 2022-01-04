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

            string convertingString = tb_Weight.Text.Replace('.', ',');
            double weight = double.Parse(convertingString);
            _saleForm.AddProductToList(_barcode, weight);
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty(tb_Weight.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // only allow 2 decimal
            int cursorPosLeft = tb_Weight.SelectionStart;
            int cursorPosRight = tb_Weight.SelectionStart + tb_Weight.SelectionLength;
            string result = tb_Weight.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb_Weight.Text.Substring(cursorPosRight);

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
