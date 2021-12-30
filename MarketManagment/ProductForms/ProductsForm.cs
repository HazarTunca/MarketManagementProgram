using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MarketManagment.ProductForms
{
    using Main;
    using Popups;
    using SaleForms;

    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();

            this.Text = "Market Manager by Hzr Ticaret";

            // data grid view
            RefreshGridView();

            lbl_DailySale.Text = $"Bu günkü cüro: {SaleConfirmXmlHelper.GetDailySale()} ₺";
        }

        public void RefreshGridView()
        {
            SQLiteConnection con = new SQLiteConnection(DBHelper.ConnectionString);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("select barcode, name, salePrice, buyPrice from Products", con);
            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "Products");
            dgv_Products.DataSource = dSet.Tables[0];
            con.Close();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();

            mainForm.WindowState = this.WindowState;
            mainForm.Location = this.Location;
            mainForm.StartPosition = FormStartPosition.Manual;

            mainForm.ShowDialog();
            this.Close();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            AddProductPopupForm popupForm = new AddProductPopupForm(this);
            popupForm.ShowDialog(this);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteProductPopupForm popupForm = new DeleteProductPopupForm(this);
            popupForm.ShowDialog(this);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateProductPopupForm popupForm = new UpdateProductPopupForm(this);
            popupForm.ShowDialog(this);
        }

        private void btn_ResetDailySale_Click(object sender, EventArgs e)
        {
            SaleConfirmXmlHelper.ResetXmlDailySaleContent();
            lbl_DailySale.Text = $"Bu günkü cüro: {SaleConfirmXmlHelper.GetDailySale()} ₺";
        }
    }
}
