
namespace MarketManagement.SaleForms
{
    partial class SaleForm
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
            this.btn_Back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_RemoveFromList = new System.Windows.Forms.Button();
            this.btn_FastConfirm = new System.Windows.Forms.Button();
            this.btn_DebitCard = new System.Windows.Forms.Button();
            this.btn_Cash = new System.Windows.Forms.Button();
            this.lbl_TotalPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_ProductsList = new System.Windows.Forms.ListView();
            this.BarcodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_RemoveShortcut = new System.Windows.Forms.Button();
            this.btn_AddShortcut = new System.Windows.Forms.Button();
            this.flp_ShortcutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_Barcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(12, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(95, 40);
            this.btn_Back.TabIndex = 5;
            this.btn_Back.Text = "GERİ";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_RemoveFromList);
            this.panel1.Controls.Add(this.btn_FastConfirm);
            this.panel1.Controls.Add(this.btn_DebitCard);
            this.panel1.Controls.Add(this.btn_Cash);
            this.panel1.Controls.Add(this.lbl_TotalPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lv_ProductsList);
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 392);
            this.panel1.TabIndex = 2;
            // 
            // btn_RemoveFromList
            // 
            this.btn_RemoveFromList.Location = new System.Drawing.Point(380, 357);
            this.btn_RemoveFromList.Name = "btn_RemoveFromList";
            this.btn_RemoveFromList.Size = new System.Drawing.Size(115, 23);
            this.btn_RemoveFromList.TabIndex = 5;
            this.btn_RemoveFromList.Text = "LİSTEDEN ÇIKAR";
            this.btn_RemoveFromList.UseVisualStyleBackColor = true;
            this.btn_RemoveFromList.Click += new System.EventHandler(this.btn_RemoveFromList_Click);
            // 
            // btn_FastConfirm
            // 
            this.btn_FastConfirm.Location = new System.Drawing.Point(174, 357);
            this.btn_FastConfirm.Name = "btn_FastConfirm";
            this.btn_FastConfirm.Size = new System.Drawing.Size(75, 23);
            this.btn_FastConfirm.TabIndex = 4;
            this.btn_FastConfirm.Text = "HIZLI ONAY";
            this.btn_FastConfirm.UseVisualStyleBackColor = true;
            this.btn_FastConfirm.Click += new System.EventHandler(this.btn_FastConfirm_Click);
            // 
            // btn_DebitCard
            // 
            this.btn_DebitCard.Location = new System.Drawing.Point(88, 357);
            this.btn_DebitCard.Name = "btn_DebitCard";
            this.btn_DebitCard.Size = new System.Drawing.Size(75, 23);
            this.btn_DebitCard.TabIndex = 3;
            this.btn_DebitCard.Text = "KART";
            this.btn_DebitCard.UseVisualStyleBackColor = true;
            this.btn_DebitCard.Click += new System.EventHandler(this.btn_DebitCard_Click);
            // 
            // btn_Cash
            // 
            this.btn_Cash.Location = new System.Drawing.Point(12, 357);
            this.btn_Cash.Name = "btn_Cash";
            this.btn_Cash.Size = new System.Drawing.Size(75, 23);
            this.btn_Cash.TabIndex = 2;
            this.btn_Cash.Text = "NAKİT";
            this.btn_Cash.UseVisualStyleBackColor = true;
            this.btn_Cash.Click += new System.EventHandler(this.btn_Cash_Click);
            // 
            // lbl_TotalPrice
            // 
            this.lbl_TotalPrice.AutoSize = true;
            this.lbl_TotalPrice.Location = new System.Drawing.Point(85, 313);
            this.lbl_TotalPrice.Name = "lbl_TotalPrice";
            this.lbl_TotalPrice.Size = new System.Drawing.Size(37, 13);
            this.lbl_TotalPrice.TabIndex = 0;
            this.lbl_TotalPrice.Text = "0.00 ₺";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toplam Tutar: ";
            // 
            // lv_ProductsList
            // 
            this.lv_ProductsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BarcodeColumn,
            this.NameColumn,
            this.PriceColumn,
            this.UnitColumn});
            this.lv_ProductsList.FullRowSelect = true;
            this.lv_ProductsList.HideSelection = false;
            this.lv_ProductsList.LabelWrap = false;
            this.lv_ProductsList.Location = new System.Drawing.Point(0, 0);
            this.lv_ProductsList.MultiSelect = false;
            this.lv_ProductsList.Name = "lv_ProductsList";
            this.lv_ProductsList.Size = new System.Drawing.Size(508, 307);
            this.lv_ProductsList.TabIndex = 0;
            this.lv_ProductsList.UseCompatibleStateImageBehavior = false;
            this.lv_ProductsList.View = System.Windows.Forms.View.Details;
            // 
            // BarcodeColumn
            // 
            this.BarcodeColumn.Text = "Barkod";
            this.BarcodeColumn.Width = 122;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "İsim";
            this.NameColumn.Width = 118;
            // 
            // PriceColumn
            // 
            this.PriceColumn.Text = "Fiyat";
            this.PriceColumn.Width = 123;
            // 
            // UnitColumn
            // 
            this.UnitColumn.Text = "Birim";
            this.UnitColumn.Width = 141;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_RemoveShortcut);
            this.panel2.Controls.Add(this.btn_AddShortcut);
            this.panel2.Controls.Add(this.flp_ShortcutPanel);
            this.panel2.Controls.Add(this.tb_Barcode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(509, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 392);
            this.panel2.TabIndex = 1;
            // 
            // btn_RemoveShortcut
            // 
            this.btn_RemoveShortcut.Location = new System.Drawing.Point(118, 0);
            this.btn_RemoveShortcut.Name = "btn_RemoveShortcut";
            this.btn_RemoveShortcut.Size = new System.Drawing.Size(112, 39);
            this.btn_RemoveShortcut.TabIndex = 4;
            this.btn_RemoveShortcut.Text = "KISAYOL SİL";
            this.btn_RemoveShortcut.UseVisualStyleBackColor = true;
            this.btn_RemoveShortcut.Click += new System.EventHandler(this.btn_RemoveShortcut_Click);
            // 
            // btn_AddShortcut
            // 
            this.btn_AddShortcut.Location = new System.Drawing.Point(0, 0);
            this.btn_AddShortcut.Name = "btn_AddShortcut";
            this.btn_AddShortcut.Size = new System.Drawing.Size(112, 39);
            this.btn_AddShortcut.TabIndex = 3;
            this.btn_AddShortcut.Text = "KISAYOL EKLE";
            this.btn_AddShortcut.UseVisualStyleBackColor = true;
            this.btn_AddShortcut.Click += new System.EventHandler(this.btn_AddShortcut_Click);
            // 
            // flp_ShortcutPanel
            // 
            this.flp_ShortcutPanel.AutoScroll = true;
            this.flp_ShortcutPanel.Location = new System.Drawing.Point(0, 45);
            this.flp_ShortcutPanel.Name = "flp_ShortcutPanel";
            this.flp_ShortcutPanel.Size = new System.Drawing.Size(367, 262);
            this.flp_ShortcutPanel.TabIndex = 2;
            // 
            // tb_Barcode
            // 
            this.tb_Barcode.Location = new System.Drawing.Point(52, 359);
            this.tb_Barcode.Name = "tb_Barcode";
            this.tb_Barcode.Size = new System.Drawing.Size(160, 20);
            this.tb_Barcode.TabIndex = 1;
            this.tb_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Barcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Barkod";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Back);
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_FastConfirm;
        private System.Windows.Forms.Button btn_DebitCard;
        private System.Windows.Forms.Button btn_Cash;
        private System.Windows.Forms.Label lbl_TotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_ProductsList;
        private System.Windows.Forms.ColumnHeader BarcodeColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader PriceColumn;
        private System.Windows.Forms.ColumnHeader UnitColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_Barcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddShortcut;
        private System.Windows.Forms.FlowLayoutPanel flp_ShortcutPanel;
        private System.Windows.Forms.Button btn_RemoveFromList;
        private System.Windows.Forms.Button btn_RemoveShortcut;
    }
}