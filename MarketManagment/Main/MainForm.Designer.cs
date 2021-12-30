
namespace MarketManagment.Main
{
    partial class MainForm
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
            this.btn_Sale = new System.Windows.Forms.Button();
            this.btn_Products = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Sale
            // 
            this.btn_Sale.Location = new System.Drawing.Point(166, 167);
            this.btn_Sale.Name = "btn_Sale";
            this.btn_Sale.Size = new System.Drawing.Size(176, 109);
            this.btn_Sale.TabIndex = 0;
            this.btn_Sale.Text = "SATIŞ";
            this.btn_Sale.UseVisualStyleBackColor = true;
            this.btn_Sale.Click += new System.EventHandler(this.btn_Sale_Click);
            // 
            // btn_Products
            // 
            this.btn_Products.Location = new System.Drawing.Point(426, 167);
            this.btn_Products.Name = "btn_Products";
            this.btn_Products.Size = new System.Drawing.Size(176, 109);
            this.btn_Products.TabIndex = 1;
            this.btn_Products.Text = "ÜRÜNLER";
            this.btn_Products.UseVisualStyleBackColor = true;
            this.btn_Products.Click += new System.EventHandler(this.btn_Products_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Products);
            this.Controls.Add(this.btn_Sale);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Sale;
        private System.Windows.Forms.Button btn_Products;
    }
}

