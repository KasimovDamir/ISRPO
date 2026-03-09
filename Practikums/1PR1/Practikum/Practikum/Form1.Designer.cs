namespace Practikum
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.labelFromSign = new System.Windows.Forms.Label();
            this.labelToSign = new System.Windows.Forms.Label();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.labelAmount = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.labelResultText = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.groupBoxRates = new System.Windows.Forms.GroupBox();
            this.labelRates = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxRates.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(15, 16);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(184, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Конвертер валют";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(16, 57);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(24, 13);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "Из:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(16, 89);
            this.labelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(17, 13);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "В:";
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(52, 54);
            this.comboBoxFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(151, 21);
            this.comboBoxFrom.TabIndex = 3;
            this.comboBoxFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrom_SelectedIndexChanged);
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(52, 87);
            this.comboBoxTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(151, 21);
            this.comboBoxTo.TabIndex = 4;
            this.comboBoxTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTo_SelectedIndexChanged);
            // 
            // labelFromSign
            // 
            this.labelFromSign.AutoSize = true;
            this.labelFromSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelFromSign.Location = new System.Drawing.Point(210, 57);
            this.labelFromSign.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFromSign.Name = "labelFromSign";
            this.labelFromSign.Size = new System.Drawing.Size(17, 17);
            this.labelFromSign.TabIndex = 5;
            this.labelFromSign.Text = "₽";
            // 
            // labelToSign
            // 
            this.labelToSign.AutoSize = true;
            this.labelToSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelToSign.Location = new System.Drawing.Point(210, 89);
            this.labelToSign.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelToSign.Name = "labelToSign";
            this.labelToSign.Size = new System.Drawing.Size(17, 17);
            this.labelToSign.TabIndex = 6;
            this.labelToSign.Text = "$";
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(236, 69);
            this.buttonEqual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(30, 24);
            this.buttonEqual.TabIndex = 7;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(16, 126);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(44, 13);
            this.labelAmount.TabIndex = 8;
            this.labelAmount.Text = "Сумма:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(75, 124);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(128, 20);
            this.textBoxAmount.TabIndex = 9;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            // 
            // labelResultText
            // 
            this.labelResultText.AutoSize = true;
            this.labelResultText.Location = new System.Drawing.Point(16, 154);
            this.labelResultText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelResultText.Name = "labelResultText";
            this.labelResultText.Size = new System.Drawing.Size(62, 13);
            this.labelResultText.TabIndex = 10;
            this.labelResultText.Text = "Результат:";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(75, 152);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(128, 20);
            this.textBoxResult.TabIndex = 11;
            // 
            // groupBoxRates
            // 
            this.groupBoxRates.Controls.Add(this.labelRates);
            this.groupBoxRates.Location = new System.Drawing.Point(19, 183);
            this.groupBoxRates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRates.Name = "groupBoxRates";
            this.groupBoxRates.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxRates.Size = new System.Drawing.Size(248, 98);
            this.groupBoxRates.TabIndex = 12;
            this.groupBoxRates.TabStop = false;
            this.groupBoxRates.Text = "Курсы валют к RUB";
            // 
            // labelRates
            // 
            this.labelRates.AutoSize = true;
            this.labelRates.Location = new System.Drawing.Point(8, 20);
            this.labelRates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRates.Name = "labelRates";
            this.labelRates.Size = new System.Drawing.Size(86, 52);
            this.labelRates.TabIndex = 0;
            this.labelRates.Text = "1 USD = -- RUB\r\n1 EUR = -- RUB\r\n1 CNY = -- RUB\r\n1 KRW = -- RUB";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(165, 288);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(101, 24);
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "Обновить курсы";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 329);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.groupBoxRates);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.labelResultText);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.labelToSign);
            this.Controls.Add(this.labelFromSign);
            this.Controls.Add(this.comboBoxTo);
            this.Controls.Add(this.comboBoxFrom);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Конвертер валют";
            this.groupBoxRates.ResumeLayout(false);
            this.groupBoxRates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.Label labelFromSign;
        private System.Windows.Forms.Label labelToSign;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label labelResultText;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.GroupBox groupBoxRates;
        private System.Windows.Forms.Label labelRates;
        private System.Windows.Forms.Button buttonUpdate;
    }
}

