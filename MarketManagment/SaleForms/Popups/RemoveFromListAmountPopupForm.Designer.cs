
namespace MarketManagment.SaleForms.Popups
{
    partial class RemoveFromListAmountPopupForm
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
            this.btn_RemoveAll = new System.Windows.Forms.Button();
            this.tb_Unit = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_ProductName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_RemoveAll
            // 
            this.btn_RemoveAll.Location = new System.Drawing.Point(100, 139);
            this.btn_RemoveAll.Name = "btn_RemoveAll";
            this.btn_RemoveAll.Size = new System.Drawing.Size(116, 42);
            this.btn_RemoveAll.TabIndex = 20;
            this.btn_RemoveAll.Text = "HEPSİNİ ÇIKAR";
            this.btn_RemoveAll.UseVisualStyleBackColor = true;
            this.btn_RemoveAll.Click += new System.EventHandler(this.btn_RemoveAll_Click);
            // 
            // tb_Unit
            // 
            this.tb_Unit.Location = new System.Drawing.Point(79, 99);
            this.tb_Unit.Name = "tb_Unit";
            this.tb_Unit.Size = new System.Drawing.Size(161, 20);
            this.tb_Unit.TabIndex = 19;
            this.tb_Unit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Unit_KeyPress);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(165, 196);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 35);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "İPTAL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(79, 196);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 35);
            this.btn_Confirm.TabIndex = 16;
            this.btn_Confirm.Text = "ONAYLA";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kaç Adet Çıkarılacak";
            // 
            // lbl_ProductName
            // 
            this.lbl_ProductName.AutoSize = true;
            this.lbl_ProductName.Location = new System.Drawing.Point(110, 31);
            this.lbl_ProductName.Name = "lbl_ProductName";
            this.lbl_ProductName.Size = new System.Drawing.Size(50, 13);
            this.lbl_ProductName.TabIndex = 21;
            this.lbl_ProductName.Text = "Ürün ismi";
            // 
            // RemoveFromListAmountPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 281);
            this.Controls.Add(this.lbl_ProductName);
            this.Controls.Add(this.btn_RemoveAll);
            this.Controls.Add(this.tb_Unit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Name = "RemoveFromListAmountPopupForm";
            this.Text = "RemoveFromListAmountPopupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RemoveAll;
        private System.Windows.Forms.TextBox tb_Unit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_ProductName;
    }
}