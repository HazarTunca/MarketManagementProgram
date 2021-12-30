using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarketManagment.SaleForms
{
    using Main;
    using Popups;
    using ProductForms;

    public partial class SaleForm : Form
    {
        private double _totalPrice = 0.0f;
        private List<Product> productList = new List<Product>();

        private List<Button> shortcutButtons = new List<Button>();

        public SaleForm()
        {
            InitializeComponent();

            // set the screen title
            this.Text = "Market Manager by Hzr Ticaret";

            // add shortcut buttons
            List<string> buttonNames = ShortcutButtonXmlHelper.GetButtonNames();
            foreach (string buttonName in buttonNames)
            {
                int barcode = ShortcutButtonXmlHelper.GetBarcode(buttonName);
                AddShortcutButton(barcode);
            }
        }

        // back to main form
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

        public void AddProductToList(int barcode, int amount)
        {
            bool isExists = false;
            int ix = -1;
            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductBarcode.Equals(barcode))
                {
                    isExists = true;
                    ix = i;
                    break;
                }
            }

            Product product = null;
            if (isExists) product = productList[ix];
            else product = new Product(barcode);
            productList.Add(product);

            // setup product amount and price
            product.ProductAmount += amount;
            double productPrice = amount * product.ProductPrice;
            double totalProductPrice = product.ProductAmount * product.ProductPrice;
            totalProductPrice = Math.Round(totalProductPrice, 2);

            // find the item in list
            ListViewItem item = null;
            for (int i = 0; i < lv_ProductsList.Items.Count; i++)
            {
                if (lv_ProductsList.Items[i].Text == barcode.ToString())
                {
                    item = lv_ProductsList.Items[i];
                    break;
                }
            }

            // if cannot find create new one
            if (item == null)
            {
                item = new ListViewItem(barcode.ToString());
                // sub item order -> name, price, amount
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{totalProductPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"x{product.ProductAmount} adet");
                lv_ProductsList.Items.Add(item);
            }
            // if find than set the existing one
            else
            {
                item.SubItems.Clear();
                item.Text = barcode.ToString();
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{totalProductPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"x{product.ProductAmount} adet");
            }

            // set the total price
            _totalPrice += productPrice;
            _totalPrice = Math.Round(_totalPrice, 2);
            lbl_TotalPrice.Text = $"{_totalPrice} ₺";

            // set the tb_Barcode
            tb_Barcode.Clear();
        }
        public void AddProductToList(int barcode, double weight)
        {
            // check product is exists
            bool isExists = false;
            int ix = -1;
            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductBarcode.Equals(barcode))
                {
                    isExists = true;
                    ix = i;

                    System.Diagnostics.Debug.WriteLine(barcode);
                    System.Diagnostics.Debug.WriteLine(ix);

                    break;
                }
            }

            Product product = null;
            if (isExists) product = productList[ix];
            else product = new Product(barcode);
            productList.Add(product);

            // setup product weight and price
            product.ProductWeight += weight;
            double addingPrice = (weight * product.ProductPrice) / 1000;
            double totalPrice = (product.ProductWeight * product.ProductPrice) / 1000;
            totalPrice = Math.Round(totalPrice, 2);

            // find the item in list
            ListViewItem item = null;
            for (int i = 0; i < lv_ProductsList.Items.Count; i++)
            {
                if (lv_ProductsList.Items[i].Text == barcode.ToString())
                {
                    item = lv_ProductsList.Items[i];
                    break;
                }
            }

            // if cannot find create new one
            if (item == null)
            {
                item = new ListViewItem(barcode.ToString());
                // sub item order -> name, price, amount
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{totalPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"{product.ProductWeight} gram");
                lv_ProductsList.Items.Add(item);
            }
            // if find than set the existing one
            else
            {
                item.SubItems.Clear();
                item.Text = barcode.ToString();
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{totalPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"{product.ProductWeight} gram");
            }

            // set the total price
            _totalPrice += addingPrice;
            _totalPrice = Math.Round(_totalPrice, 2);
            lbl_TotalPrice.Text = $"{_totalPrice} ₺";

            // set the tb_Barcode
            tb_Barcode.Clear();
        }

        public void RemoveProductFromList(int barcode, int amount)
        {
            ListViewItem item = null;
            for (int i = 0; i < lv_ProductsList.Items.Count; i++)
            {
                if (lv_ProductsList.Items[i].Text == barcode.ToString())
                {
                    item = lv_ProductsList.Items[i];
                    break;
                }
            }

            Product product = null;
            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductBarcode == barcode)
                {
                    product = productList[i];
                    break;
                }
            }

            // item can not find
            if (item == null || product == null)
            {
                return;
            }

            double removingPrice = 0;
            double restPrice = 0;

            bool removeAll = false;
            if (amount >= product.ProductAmount) removeAll = true;

            if (removeAll)
            {
                removingPrice = product.ProductAmount * product.ProductPrice;

                productList.Remove(product);
                lv_ProductsList.Items.Remove(item);
            }
            else
            {
                removingPrice = amount * product.ProductPrice;

                product.ProductAmount -= amount;

                restPrice = product.ProductAmount * product.ProductPrice;

                item.SubItems.Clear();
                item.Text = barcode.ToString();
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{restPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"x{product.ProductAmount}");
            }

            _totalPrice -= removingPrice;
            lbl_TotalPrice.Text = _totalPrice.ToString();
        }
        public void RemoveProductFromList(int barcode, double weight)
        {
            ListViewItem item = null;
            for (int i = 0; i < lv_ProductsList.Items.Count; i++)
            {
                if (lv_ProductsList.Items[i].Text == barcode.ToString())
                {
                    item = lv_ProductsList.Items[i];
                    break;
                }
            }

            Product product = null;
            for (int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductBarcode == barcode)
                {
                    product = productList[i];
                    break;
                }
            }

            // item can not find
            if (item == null || product == null)
            {
                return;
            }

            double removingPrice = 0;
            double restPrice = 0;

            bool removeAll = false;
            if (weight.Equals(product.ProductWeight)) removeAll = true;

            if (removeAll)
            {
                removingPrice = (product.ProductWeight * product.ProductPrice) / 1000;

                productList.Remove(product);
                lv_ProductsList.Items.Remove(item);
            }
            else
            {
                removingPrice = (weight * product.ProductPrice) / 1000;

                product.ProductWeight -= weight;
                restPrice = (product.ProductWeight * product.ProductPrice) / 1000;

                item.SubItems.Clear();
                item.Text = barcode.ToString();
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add($"{restPrice} ₺ ({product.ProductPrice} ₺)");
                item.SubItems.Add($"{product.ProductWeight} gram");
            }

            _totalPrice -= removingPrice;
            lbl_TotalPrice.Text = _totalPrice.ToString();
        }

        // if press enter automaticly add item to list
        private void tb_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // if didn't press enter or barcode tb is empty
            if (e.KeyChar != (char)Keys.Enter || String.IsNullOrEmpty(tb_Barcode.Text))
            {
                return;
            }

            // if there is no product with this barcode
            int barcode = int.Parse(tb_Barcode.Text);
            if (!DBHelper.CheckDataValid(barcode))
            {
                return;
            }

            if (DBHelper.ProductIsWeight(barcode))
            {
                // create new popup for asking weight
                AskWeightPopupForm popupForm = new AskWeightPopupForm(this, barcode);
                popupForm.ShowDialog(this);
            }
            else AddProductToList(barcode, 1);
            tb_Barcode.Focus();
        }

        #region Confirm Payment
        public void ConfirmPayment(double price)
        {
            SaleConfirmXmlHelper.UpdateXmlDailySale(price);

            lv_ProductsList.Items.Clear();
            productList.Clear();
            _totalPrice = 0;
            lbl_TotalPrice.Text = _totalPrice.ToString();
        }

        private void btn_Cash_Click(object sender, EventArgs e)
        {
            CashSalePopupForm newPopup = new CashSalePopupForm(this, _totalPrice);
            newPopup.ShowDialog();

            // Focus the barcode tb again
            tb_Barcode.Focus();
        }

        private void btn_DebitCard_Click(object sender, EventArgs e)
        {
            if (IsProductListEmpty()) return;

            ConfirmPayment(_totalPrice);

            // Focus the barcode tb again
            tb_Barcode.Focus();
        }

        private void btn_FastConfirm_Click(object sender, EventArgs e)
        {
            if (IsProductListEmpty()) return;

            ConfirmPayment(_totalPrice);

            // Focus the barcode tb again
            tb_Barcode.Focus();
        }

        private bool IsProductListEmpty()
        {
            int itemCount = lv_ProductsList.Items.Count;

            if (itemCount == 0) return true;
            else return false;
        }
        #endregion

        #region Shortcut Buttons
        public void AddShortcutButton(int barcode)
        {
            // barcode is not exists!
            if (!DBHelper.CheckDataValid(barcode))
            {

                return;
            }
            string buttonName = DBHelper.GetProductName(barcode);

            // create button and label
            Button button = new Button();

            // button appearance
            button.Text = $"{buttonName}";
            button.Width = 100;
            button.Height = 80;

            // button click event
            button.Click += new EventHandler(this.ShortcutButtonClick);

            // check is button already in flow panel
            foreach (Button item in shortcutButtons)
            {
                if (buttonName == item.Text)
                {

                    return;
                }
            }

            // if not add the button to list
            shortcutButtons.Add(button);

            // add button to list xml if its not exists
            if (!ShortcutButtonXmlHelper.IsButtonExists(buttonName))
            {
                ShortcutButtonXmlHelper.AddNewButton(barcode, buttonName);
            }

            // add button to flow panel
            flp_ShortcutPanel.Controls.Add(button);

            // focus the tb_barcode
            tb_Barcode.Focus();
        }

        public void RemoveShortcutButton(int barcode)
        {
            // barcode is not exists!
            if (!DBHelper.CheckDataValid(barcode))
            {

                return;
            }
            string buttonName = DBHelper.GetProductName(barcode);

            // there is no shortcut button
            if (!ShortcutButtonXmlHelper.IsButtonExists(buttonName))
            {

                return;
            }

            Button removingBtn = null;
            foreach (Button button in shortcutButtons)
            {
                if (button.Text == buttonName)
                {
                    removingBtn = button;
                    break;
                }
            }

            // possible bug fix
            if (removingBtn == null) return;

            flp_ShortcutPanel.Controls.Remove(removingBtn);
            shortcutButtons.Remove(removingBtn);
            ShortcutButtonXmlHelper.RemoveButton(buttonName);
        }

        private void btn_AddShortcut_Click(object sender, EventArgs e)
        {
            AddShortcutButtonPopupForm newPopup = new AddShortcutButtonPopupForm(this);
            newPopup.ShowDialog();
            tb_Barcode.Focus();
        }

        private void ShortcutButtonClick(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            int barcode = ShortcutButtonXmlHelper.GetBarcode(buttonName);

            // cannot find the barcode
            if (barcode == -1)
            {
                return;
            }

            // if can get the barcode than add product to the list
            if (DBHelper.ProductIsWeight(barcode))
            {
                // create new popup for asking weight
                AskWeightPopupForm popupForm = new AskWeightPopupForm(this, barcode);
                popupForm.ShowDialog(this);
            }
            else
            {
                // create new popup for asking amount
                AskAmountPopupForm popupForm = new AskAmountPopupForm(this, barcode);
                popupForm.ShowDialog(this);
            }
            tb_Barcode.Focus();
        }

        private void btn_RemoveShortcut_Click(object sender, EventArgs e)
        {
            RemoveShortcutButtonPopupForm popupForm = new RemoveShortcutButtonPopupForm(this);
            popupForm.ShowDialog();
            tb_Barcode.Focus();
        }
        #endregion

        private void btn_RemoveFromList_Click(object sender, EventArgs e)
        {
            // there is no item selected
            if (lv_ProductsList.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selectedItem = lv_ProductsList.SelectedItems[0];

            int itemBarcode = int.Parse(selectedItem.Text);
            Product product = FindProductInList(itemBarcode);

            // for possible bug fix
            if (product == null)
            {
                return;
            }

            if (product.IsWeight)
            {
                // create weight popup
                RemoveFromListWeightPopupForm newPopup = new RemoveFromListWeightPopupForm(this, itemBarcode, product.ProductName, product.ProductWeight);
                newPopup.ShowDialog(this);
            }
            else
            {
                // create amount popup
                RemoveFromListAmountPopupForm newPopup = new RemoveFromListAmountPopupForm(this, itemBarcode, product.ProductName, product.ProductAmount);
                newPopup.ShowDialog(this);
            }
        }

        private Product FindProductInList(int barcode)
        {
            foreach (Product product in productList)
            {
                if (product.ProductBarcode.Equals(barcode))
                {
                    return product;
                }
            }

            return null;
        }
    }
}
