namespace PublishingApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.GroupBox groupBoxInfo;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;

        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.Size = new System.Drawing.Size(760, 250);
            this.dataGridViewBooks.TabIndex = 0;
            this.dataGridViewBooks.SelectionChanged += new System.EventHandler(this.dataGridViewBooks_SelectionChanged);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.txtYear);
            this.groupBoxInfo.Controls.Add(this.txtAuthor);
            this.groupBoxInfo.Controls.Add(this.txtTitle);
            this.groupBoxInfo.Controls.Add(this.lblTitle);
            this.groupBoxInfo.Controls.Add(this.lblAuthor);
            this.groupBoxInfo.Controls.Add(this.lblYear);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 270);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(760, 108);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Информация о книге";
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(10, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(78, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(427, 35);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(50, 23);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Автор:";
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(10, 74);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(78, 23);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Год издания:";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(12, 384);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(160, 30);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Сделать предзаказ";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(672, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(86, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(304, 20);
            this.txtTitle.TabIndex = 6;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(471, 32);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(258, 20);
            this.txtAuthor.TabIndex = 7;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(86, 71);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(91, 20);
            this.txtYear.TabIndex = 8;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 422);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.Text = "Издательство – Предзаказ книг";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
    }
}
