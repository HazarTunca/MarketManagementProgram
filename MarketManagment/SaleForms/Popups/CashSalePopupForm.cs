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
        }

        private void tb_Price_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Price.Text)) _price = 0;
            else _price = double.Parse(tb_Price.Text);

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
        }

        private void tb_TakenMoney_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_TakenMoney.Text)) _takenMoney = 0;
            else _takenMoney = double.Parse(tb_TakenMoney.Text);

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
