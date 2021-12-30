﻿using System;
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
    public partial class RemoveFromListWeightPopupForm : Form
    {
        private SaleForm _saleForm;
        private int _barcode;
        private string _productName;
        private double _itemWeight;

        public RemoveFromListWeightPopupForm(SaleForm saleForm, int barcode, string productName, double itemWeight)
        {
            InitializeComponent();
            CenterToScreen();

            _saleForm = saleForm;
            _barcode = barcode;
            _productName = productName;
            _itemWeight = itemWeight;

            lbl_ProductName.Text = $"ürün ismi: {_productName}";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            string convertingString = tb_Unit.Text.Replace('.', ',');
            double removingWeight = double.Parse(convertingString);
            _saleForm.RemoveProductFromList(_barcode, removingWeight);

            this.Close();
        }


        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            _saleForm.RemoveProductFromList(_barcode, _itemWeight);
            this.Close();
        }

        private void tb_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (String.IsNullOrEmpty(tb_Unit.Text) && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

            // allow decimal numbers
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
