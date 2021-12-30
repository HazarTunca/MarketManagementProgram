
namespace MarketManagment.ProductForms
{
    partial class ProductsForm
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
            this.btn_Insert = new System.Windows.Forms.Button();
            this.dgv_Products = new System.Windows.Forms.DataGridView();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.lbl_DailySale = new System.Windows.Forms.Label();
            this.btn_ResetDailySale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(12, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(95, 40);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "GERİ";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(128, 12);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(103, 40);
            this.btn_Insert.TabIndex = 2;
            this.btn_Insert.Text = "EKLE";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // dgv_Products
            // 
            this.dgv_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Products.Location = new System.Drawing.Point(12, 58);
            this.dgv_Products.Name = "dgv_Products";
            this.dgv_Products.ReadOnly = true;
            this.dgv_Products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Products.Size = new System.Drawing.Size(776, 380);
            this.dgv_Products.TabIndex = 3;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(376, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(103, 40);
            this.btn_Delete.TabIndex = 4;
            this.btn_Delete.Text = "SİL";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(250, 12);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(103, 40);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "GÜNCELLE";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // lbl_DailySale
            // 
            this.lbl_DailySale.AutoSize = true;
            this.lbl_DailySale.Location = new System.Drawing.Point(558, 26);
            this.lbl_DailySale.Name = "lbl_DailySale";
            this.lbl_DailySale.Size = new System.Drawing.Size(89, 13);
            this.lbl_DailySale.TabIndex = 6;
            this.lbl_DailySale.Text = "Bu günkü cüro: 0";
            // 
            // btn_ResetDailySale
            // 
            this.btn_ResetDailySale.Location = new System.Drawing.Point(680, 21);
            this.btn_ResetDailySale.Name = "btn_ResetDailySale";
            this.btn_ResetDailySale.Size = new System.Drawing.Size(108, 23);
            this.btn_ResetDailySale.TabIndex = 7;
            this.btn_ResetDailySale.Text = "CÜRO SIFIRLA";
            this.btn_ResetDailySale.UseVisualStyleBackColor = true;
            this.btn_ResetDailySale.Click += new System.EventHandler(this.btn_ResetDailySale_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ResetDailySale);
            this.Controls.Add(this.lbl_DailySale);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.dgv_Products);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.btn_Back);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.DataGridView dgv_Products;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_DailySale;
        private System.Windows.Forms.Button btn_ResetDailySale;
    }
}