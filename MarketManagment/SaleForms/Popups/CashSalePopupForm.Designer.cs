
namespace MarketManagment.SaleForms.Popups
{
    partial class CashSalePopupForm
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
            this.lbl_Price = new System.Windows.Forms.Label();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.tb_TakenMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Change = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Location = new System.Drawing.Point(142, 9);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(32, 13);
            this.lbl_Price.TabIndex = 0;
            this.lbl_Price.Text = "Tutar";
            // 
            // tb_Price
            // 
            this.tb_Price.Location = new System.Drawing.Point(77, 28);
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(156, 20);
            this.tb_Price.TabIndex = 1;
            this.tb_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Price_KeyPress);
            this.tb_Price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_Price_KeyUp);
            // 
            // tb_TakenMoney
            // 
            this.tb_TakenMoney.Location = new System.Drawing.Point(77, 86);
            this.tb_TakenMoney.Name = "tb_TakenMoney";
            this.tb_TakenMoney.Size = new System.Drawing.Size(156, 20);
            this.tb_TakenMoney.TabIndex = 3;
            this.tb_TakenMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_TakenMoney_KeyPress);
            this.tb_TakenMoney.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_TakenMoney_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Verilen Para";
            // 
            // lbl_Change
            // 
            this.lbl_Change.AutoSize = true;
            this.lbl_Change.Location = new System.Drawing.Point(74, 132);
            this.lbl_Change.Name = "lbl_Change";
            this.lbl_Change.Size = new System.Drawing.Size(64, 13);
            this.lbl_Change.TabIndex = 4;
            this.lbl_Change.Text = "Para üstü: 0";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(77, 167);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 5;
            this.btn_Confirm.Text = "ONAYLA";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(158, 167);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "İPTAL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // CashSalePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 202);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.lbl_Change);
            this.Controls.Add(this.tb_TakenMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Price);
            this.Controls.Add(this.lbl_Price);
            this.Name = "CashSalePopupForm";
            this.Text = "CashSalePopupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.TextBox tb_Price;
        private System.Windows.Forms.TextBox tb_TakenMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Change;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
    }
}