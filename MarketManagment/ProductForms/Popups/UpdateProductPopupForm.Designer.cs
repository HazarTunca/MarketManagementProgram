
namespace MarketManagment.ProductForms.Popups
{
    partial class UpdateProductPopupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Barcode = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_SalePrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_BuyPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cb_IsWeight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod";
            // 
            // tb_Barcode
            // 
            this.tb_Barcode.Location = new System.Drawing.Point(76, 44);
            this.tb_Barcode.Name = "tb_Barcode";
            this.tb_Barcode.Size = new System.Drawing.Size(154, 20);
            this.tb_Barcode.TabIndex = 1;
            this.tb_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Barcode_KeyPress);
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(76, 108);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(154, 20);
            this.tb_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "İsim";
            // 
            // tb_SalePrice
            // 
            this.tb_SalePrice.Location = new System.Drawing.Point(76, 180);
            this.tb_SalePrice.Name = "tb_SalePrice";
            this.tb_SalePrice.Size = new System.Drawing.Size(154, 20);
            this.tb_SalePrice.TabIndex = 5;
            this.tb_SalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_SalePrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Satış Fiyat";
            // 
            // tb_BuyPrice
            // 
            this.tb_BuyPrice.Location = new System.Drawing.Point(76, 251);
            this.tb_BuyPrice.Name = "tb_BuyPrice";
            this.tb_BuyPrice.Size = new System.Drawing.Size(154, 20);
            this.tb_BuyPrice.TabIndex = 7;
            this.tb_BuyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_BuyPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Alış Fiyat";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(54, 349);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(89, 37);
            this.btn_Confirm.TabIndex = 10;
            this.btn_Confirm.Text = "ONAYLA";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(162, 349);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 37);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "İPTAL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cb_IsWeight
            // 
            this.cb_IsWeight.AutoSize = true;
            this.cb_IsWeight.Location = new System.Drawing.Point(76, 299);
            this.cb_IsWeight.Name = "cb_IsWeight";
            this.cb_IsWeight.Size = new System.Drawing.Size(134, 17);
            this.cb_IsWeight.TabIndex = 12;
            this.cb_IsWeight.Text = "Kilo Cinsinden Hesapla";
            this.cb_IsWeight.UseVisualStyleBackColor = true;
            // 
            // UpdateProductPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 424);
            this.Controls.Add(this.cb_IsWeight);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.tb_BuyPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_SalePrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Barcode);
            this.Controls.Add(this.label1);
            this.Name = "UpdateProductPopupForm";
            this.Text = "UpdateProductPopupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Barcode;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_SalePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_BuyPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox cb_IsWeight;
    }
}