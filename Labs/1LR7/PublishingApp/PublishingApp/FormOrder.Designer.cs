namespace PublishingApp
{
    partial class FormOrder
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox gbBook;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.GroupBox gbOffice;
        private System.Windows.Forms.GroupBox gbDetails;

        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblAuthor;

        private System.Windows.Forms.Label lblFio;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;

        private System.Windows.Forms.ComboBox cmbOffice;

        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbBook = new System.Windows.Forms.GroupBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.lblFio = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.gbOffice = new System.Windows.Forms.GroupBox();
            this.cmbOffice = new System.Windows.Forms.ComboBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFio = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.gbBook.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.gbOffice.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBook
            // 
            this.gbBook.Controls.Add(this.lblBook);
            this.gbBook.Controls.Add(this.lblAuthor);
            this.gbBook.Location = new System.Drawing.Point(12, 12);
            this.gbBook.Name = "gbBook";
            this.gbBook.Size = new System.Drawing.Size(400, 70);
            this.gbBook.TabIndex = 0;
            this.gbBook.TabStop = false;
            this.gbBook.Text = "Выбранная книга";
            // 
            // lblBook
            // 
            this.lblBook.Location = new System.Drawing.Point(10, 25);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(360, 20);
            this.lblBook.TabIndex = 0;
            this.lblBook.Text = "Название:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(10, 45);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(360, 20);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Автор:";
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.txtPhone);
            this.gbCustomer.Controls.Add(this.txtAddress);
            this.gbCustomer.Controls.Add(this.txtFio);
            this.gbCustomer.Controls.Add(this.lblFio);
            this.gbCustomer.Controls.Add(this.lblAddress);
            this.gbCustomer.Controls.Add(this.lblPhone);
            this.gbCustomer.Location = new System.Drawing.Point(12, 90);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(400, 130);
            this.gbCustomer.TabIndex = 1;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Данные клиента";
            // 
            // lblFio
            // 
            this.lblFio.Location = new System.Drawing.Point(10, 25);
            this.lblFio.Name = "lblFio";
            this.lblFio.Size = new System.Drawing.Size(100, 23);
            this.lblFio.TabIndex = 0;
            this.lblFio.Text = "ФИО:";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(10, 60);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Адрес:";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(10, 95);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Телефон:";
            // 
            // gbOffice
            // 
            this.gbOffice.Controls.Add(this.cmbOffice);
            this.gbOffice.Location = new System.Drawing.Point(12, 230);
            this.gbOffice.Name = "gbOffice";
            this.gbOffice.Size = new System.Drawing.Size(400, 60);
            this.gbOffice.TabIndex = 2;
            this.gbOffice.TabStop = false;
            this.gbOffice.Text = "Выбор офиса получения";
            // 
            // cmbOffice
            // 
            this.cmbOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffice.Location = new System.Drawing.Point(10, 25);
            this.cmbOffice.Name = "cmbOffice";
            this.cmbOffice.Size = new System.Drawing.Size(370, 21);
            this.cmbOffice.TabIndex = 0;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.numCount);
            this.gbDetails.Controls.Add(this.lblTotal);
            this.gbDetails.Location = new System.Drawing.Point(12, 300);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(400, 70);
            this.gbDetails.TabIndex = 3;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Детали заказа";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(10, 30);
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(120, 20);
            this.numCount.TabIndex = 0;
            this.numCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.ValueChanged += new System.EventHandler(this.numCount_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(140, 32);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(188, 23);
            this.lblTotal.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(40, 380);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Подтвердить заказ";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFio
            // 
            this.txtFio.Location = new System.Drawing.Point(100, 19);
            this.txtFio.Name = "txtFio";
            this.txtFio.Size = new System.Drawing.Size(280, 20);
            this.txtFio.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(100, 57);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(280, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(100, 92);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(280, 20);
            this.txtPhone.TabIndex = 10;
            // 
            // FormOrder
            // 
            this.ClientSize = new System.Drawing.Size(424, 430);
            this.Controls.Add(this.gbBook);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.gbOffice);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormOrder";
            this.Text = "Оформление предзаказа";
            this.gbBook.ResumeLayout(false);
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.gbOffice.ResumeLayout(false);
            this.gbDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFio;
    }
}
