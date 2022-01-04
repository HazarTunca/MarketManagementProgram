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

    public partial class DeleteProductPopupForm : Form
    {
        private ProductsForm _productsForm;

        public DeleteProductPopupForm(ProductsForm productsForm)
        {
            InitializeComponent();
            CenterToParent();

            _productsForm = productsForm;
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
            if (string.IsNullOrEmpty(tb_Barcode.Text))
            {
                // give user to warn you can't leave empty
                return;
            }

            int barcode = int.Parse(tb_Barcode.Text);

            if (DBHelper.CheckDataValid(barcode))
            {
                DBHelper.DeleteData(barcode);
                _productsForm.RefreshGridView();
                this.Close();
            }
            else
            {
                // give warn to user there is no product
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
