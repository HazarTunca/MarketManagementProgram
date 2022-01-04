
namespace MarketManagement.ProductForms.Popups
{
    partial class AddProductPopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Barcode = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_buyPrice = new System.Windows.Forms.Label();
            this.lbl_SalePrice = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tb_Barcode = new System.Windows.Forms.TextBox();
            this.tb_BuyPrice = new System.Windows.Forms.TextBox();
            this.tb_SalePrice = new System.Windows.Forms.TextBox();
            this.cb_IsWeight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_Barcode
            // 
            this.lbl_Barcode.AutoSize = true;
            this.lbl_Barcode.Location = new System.Drawing.Point(137, 21);
            this.lbl_Barcode.Name = "lbl_Barcode";
            this.lbl_Barcode.Size = new System.Drawing.Size(51, 13);
            this.lbl_Barcode.TabIndex = 0;
            this.lbl_Barcode.Text = "Barcode*";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(84, 104);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(158, 20);
            this.tb_Name.TabIndex = 2;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(137, 80);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(55, 13);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "Ürün İsim*";
            // 
            // lbl_buyPrice
            // 
            this.lbl_buyPrice.AutoSize = true;
            this.lbl_buyPrice.Location = new System.Drawing.Point(137, 197);
            this.lbl_buyPrice.Name = "lbl_buyPrice";
            this.lbl_buyPrice.Size = new System.Drawing.Size(50, 13);
            this.lbl_buyPrice.TabIndex = 4;
            this.lbl_buyPrice.Text = "Alış Fiyatı";
            // 
            // lbl_SalePrice
            // 
            this.lbl_SalePrice.AutoSize = true;
            this.lbl_SalePrice.Location = new System.Drawing.Point(137, 139);
            this.lbl_SalePrice.Name = "lbl_SalePrice";
            this.lbl_SalePrice.Size = new System.Drawing.Size(61, 13);
            this.lbl_SalePrice.TabIndex = 6;
            this.lbl_SalePrice.Text = "Satış Fiyatı*";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(84, 319);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 8;
            this.btn_Confirm.Text = "ONAYLA";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(167, 319);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "İPTAL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tb_Barcode
            // 
            this.tb_Barcode.Location = new System.Drawing.Point(84, 46);
            this.tb_Barcode.Name = "tb_Barcode";
            this.tb_Barcode.Size = new System.Drawing.Size(158, 20);
            this.tb_Barcode.TabIndex = 1;
            this.tb_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Barcode_KeyPress);
            // 
            // tb_BuyPrice
            // 
            this.tb_BuyPrice.Location = new System.Drawing.Point(84, 222);
            this.tb_BuyPrice.Name = "tb_BuyPrice";
            this.tb_BuyPrice.Size = new System.Drawing.Size(158, 20);
            this.tb_BuyPrice.TabIndex = 4;
            this.tb_BuyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_BuyPrice_KeyPress);
            // 
            // tb_SalePrice
            // 
            this.tb_SalePrice.Location = new System.Drawing.Point(84, 164);
            this.tb_SalePrice.Name = "tb_SalePrice";
            this.tb_SalePrice.Size = new System.Drawing.Size(158, 20);
            this.tb_SalePrice.TabIndex = 3;
            this.tb_SalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_SalePrice_KeyPress);
            // 
            // cb_IsWeight
            // 
            this.cb_IsWeight.AutoSize = true;
            this.cb_IsWeight.Location = new System.Drawing.Point(84, 267);
            this.cb_IsWeight.Name = "cb_IsWeight";
            this.cb_IsWeight.Size = new System.Drawing.Size(134, 17);
            this.cb_IsWeight.TabIndex = 10;
            this.cb_IsWeight.Text = "Kilo Cinsinden Hesapla";
            this.cb_IsWeight.UseVisualStyleBackColor = true;
            // 
            // AddProductPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 388);
            this.Controls.Add(this.cb_IsWeight);
            this.Controls.Add(this.tb_SalePrice);
            this.Controls.Add(this.tb_BuyPrice);
            this.Controls.Add(this.tb_Barcode);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.lbl_SalePrice);
            this.Controls.Add(this.lbl_buyPrice);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Barcode);
            this.Name = "AddProductPopupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Barcode;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_buyPrice;
        private System.Windows.Forms.Label lbl_SalePrice;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_Barcode;
        private System.Windows.Forms.TextBox tb_BuyPrice;
        private System.Windows.Forms.TextBox tb_SalePrice;
        private System.Windows.Forms.CheckBox cb_IsWeight;
    }
}