namespace PublishingApp
{
    partial class FormReceipt
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReceipt = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReceipt
            // 
            this.lblReceipt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReceipt.Location = new System.Drawing.Point(7, 9);
            this.lblReceipt.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(420, 479);
            this.lblReceipt.TabIndex = 0;
            this.lblReceipt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(82, 491);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Печать";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(222, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormReceipt
            // 
            this.ClientSize = new System.Drawing.Size(484, 533);
            this.Controls.Add(this.lblReceipt);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Name = "FormReceipt";
            this.Text = "Чек заказа";
            this.ResumeLayout(false);

        }
    }
}
