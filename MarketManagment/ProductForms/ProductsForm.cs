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

namespace MarketManagement.ProductForms
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
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("select barcode, name, salePrice, buyPrice, profit from Products", con);
            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "Products");

            dSet.Tables[0].Columns[0].ColumnName = "Barkod";
            dSet.Tables[0].Columns[1].ColumnName = "Ürün İsmi";
            dSet.Tables[0].Columns[2].ColumnName = "Satış Fiyatı";
            dSet.Tables[0].Columns[3].ColumnName = "Alış Fiyatı";
            dSet.Tables[0].Columns[4].ColumnName = "Elde Edilen Kâr";

            // create new column for product unity
            dSet.Tables[0].Columns.Add("Ürün Birimi");
            dSet.Tables[0].Columns[5].DataType = typeof(string);

            dgv_Products.DataSource = dSet.Tables[0];
            con.Close();

            // set product's unit
            for (int i = 0; i < dSet.Tables[0].Rows.Count; i++)
            {
                // get barcode
                dgv_Products.Rows[i].Selected = true;
                var selectedBarcode = dgv_Products.SelectedRows[0].Cells[0].Value;
                int barcode = Convert.ToInt32(selectedBarcode);

                // get row
                DataRow row = dSet.Tables[0].Rows[i];

                if (DBHelper.GetProductIsWeight(barcode))
                {
                    row.SetField<string>(5, "Gram");
                    continue;
                }

                row.SetField<string>(5, "Adet");
            }

            dgv_Products.ClearSelection();
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
            if (dgv_Products.SelectedRows.Count == 0)
            {
                DeleteProductPopupForm popupForm = new DeleteProductPopupForm(this);
                popupForm.ShowDialog(this);
            }
            else
            {
                var selectedItemBarcode = dgv_Products.SelectedRows[0].Cells[0].Value;
                int barcode = Convert.ToInt32(selectedItemBarcode);
                DBHelper.DeleteData(barcode);
                RefreshGridView();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgv_Products.SelectedRows.Count == 0)
            {
                UpdateProductPopupForm popupForm = new UpdateProductPopupForm(this);
                popupForm.ShowDialog(this);
            }
            else
            {
                var selectedItemBarcode = dgv_Products.SelectedRows[0].Cells[0].Value;
                int barcode = Convert.ToInt32(selectedItemBarcode);
                string productName = DBHelper.GetProductName(barcode);
                double salePrice = DBHelper.GetProductPrice(barcode);
                double buyPrice = DBHelper.GetProductBuyPrice(barcode);
                bool isWeight = DBHelper.GetProductIsWeight(barcode);

                UpdateProductPopupForm popupForm = new UpdateProductPopupForm(this, barcode, productName, salePrice, buyPrice, isWeight);
                popupForm.ShowDialog(this);
            }
        }

        private void btn_ResetDailySale_Click(object sender, EventArgs e)
        {
            SaleConfirmXmlHelper.ResetXmlDailySaleContent();
            lbl_DailySale.Text = $"Bu günkü cüro: {SaleConfirmXmlHelper.GetDailySale()} ₺";
        }

        // clear selection when click somewhere
        private void ProductsForm_MouseUp(object sender, MouseEventArgs e) => dgv_Products.ClearSelection();

        private void ProductsForm_Load(object sender, EventArgs e) => dgv_Products.ClearSelection();
    }
}
