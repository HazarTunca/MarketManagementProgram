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
    public partial class CashSalePopupForm : Form
    {
        private SaleForm _saleForm;
        private double _price;
        private double _takenMoney;

        public CashSalePopupForm(SaleForm saleForm, double price)
        {
            InitializeComponent();
            CenterToScreen();

            _saleForm = saleForm;

            _price = price;
            tb_Price.Text = _price.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Price.Text)){
                this.Close();
                return;
            }

            _saleForm.ConfirmPayment(_price);
            this.Close();
        }

        private void tb_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty(tb_Price.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // only allow 2 decimal
            int cursorPosLeft = tb_Price.SelectionStart;
            int cursorPosRight = tb_Price.SelectionStart + tb_Price.SelectionLength;
            string result = tb_Price.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb_Price.Text.Substring(cursorPosRight);

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

        private void tb_Price_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Price.Text)) _price = 0;
            else
            {
                string convertingString = tb_Price.Text.Replace('.', ',');
                _price = double.Parse(convertingString);
            }

            if (_price > _takenMoney)
            {
                lbl_Change.Text = $"Yetersiz para! Müşterinin vermesi gereken miktar: {_price - _takenMoney}₺";
            }
            else
            {
                lbl_Change.Text = $"Para üstü: {_takenMoney - _price}₺";
            }
        }

        private void tb_TakenMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (string.IsNullOrEmpty(tb_TakenMoney.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // only allow 2 decimal
            int cursorPosLeft = tb_TakenMoney.SelectionStart;
            int cursorPosRight = tb_TakenMoney.SelectionStart + tb_TakenMoney.SelectionLength;
            string result = tb_TakenMoney.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb_TakenMoney.Text.Substring(cursorPosRight);
            result.Replace(',', '.');
            string[] parts = result.Split('.');
            if (parts.Length > 1 && e.KeyChar != (char)Keys.Back)
            {
                if (parts[1].Length > 2 || parts.Length > 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void tb_TakenMoney_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_TakenMoney.Text)) _takenMoney = 0;
            else
            {
                string convertingString = tb_TakenMoney.Text.Replace('.', ',');
                _takenMoney = double.Parse(convertingString);
            }

            if (_price > _takenMoney)
            {
                lbl_Change.Text = $"Yetersiz para! Müşterinin vermesi gereken miktar: {_price - _takenMoney}₺";
            }
            else
            {
                lbl_Change.Text = $"Para üstü: {_takenMoney - _price}₺";
            }
        }
    }
}
