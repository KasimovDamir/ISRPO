namespace SkladApp
{
    partial class Sklad
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelSelected = new System.Windows.Forms.Button();
            this.buttonAddInDGV = new System.Windows.Forms.Button();
            this.buttonSaveLike = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonAddNName = new System.Windows.Forms.Button();
            this.numericUpDownQn = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCl = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStl = new System.Windows.Forms.NumericUpDown();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.textBoxNName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxNSr = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCoordSr = new System.Windows.Forms.Button();
            this.numericUpDownSrCl = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSrSl = new System.Windows.Forms.NumericUpDown();
            this.buttonOpen2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStl)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSrCl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSrSl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 518);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товар";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 489);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpen2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonDelSelected);
            this.groupBox2.Controls.Add(this.buttonAddInDGV);
            this.groupBox2.Controls.Add(this.buttonSaveLike);
            this.groupBox2.Controls.Add(this.buttonOpen);
            this.groupBox2.Controls.Add(this.buttonAddNName);
            this.groupBox2.Controls.Add(this.numericUpDownQn);
            this.groupBox2.Controls.Add(this.numericUpDownCl);
            this.groupBox2.Controls.Add(this.numericUpDownStl);
            this.groupBox2.Controls.Add(this.comboBoxName);
            this.groupBox2.Controls.Add(this.textBoxNName);
            this.groupBox2.Location = new System.Drawing.Point(616, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 203);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавить";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Номер ячейки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Номер стелажа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Новое название";
            // 
            // buttonDelSelected
            // 
            this.buttonDelSelected.Location = new System.Drawing.Point(6, 164);
            this.buttonDelSelected.Name = "buttonDelSelected";
            this.buttonDelSelected.Size = new System.Drawing.Size(127, 23);
            this.buttonDelSelected.TabIndex = 9;
            this.buttonDelSelected.Text = "Удалить выбранное";
            this.buttonDelSelected.UseVisualStyleBackColor = true;
            this.buttonDelSelected.Click += new System.EventHandler(this.buttonDelSelected_Click);
            // 
            // buttonAddInDGV
            // 
            this.buttonAddInDGV.Location = new System.Drawing.Point(143, 164);
            this.buttonAddInDGV.Name = "buttonAddInDGV";
            this.buttonAddInDGV.Size = new System.Drawing.Size(120, 23);
            this.buttonAddInDGV.TabIndex = 8;
            this.buttonAddInDGV.Text = "Добавить";
            this.buttonAddInDGV.UseVisualStyleBackColor = true;
            this.buttonAddInDGV.Click += new System.EventHandler(this.buttonAddInDGV_Click);
            // 
            // buttonSaveLike
            // 
            this.buttonSaveLike.Location = new System.Drawing.Point(287, 164);
            this.buttonSaveLike.Name = "buttonSaveLike";
            this.buttonSaveLike.Size = new System.Drawing.Size(99, 23);
            this.buttonSaveLike.TabIndex = 7;
            this.buttonSaveLike.Text = "Сохранить как";
            this.buttonSaveLike.UseVisualStyleBackColor = true;
            this.buttonSaveLike.Click += new System.EventHandler(this.buttonSaveLike_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(287, 106);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(99, 23);
            this.buttonOpen.TabIndex = 6;
            this.buttonOpen.Text = "Обновить";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonAddNName
            // 
            this.buttonAddNName.Location = new System.Drawing.Point(287, 32);
            this.buttonAddNName.Name = "buttonAddNName";
            this.buttonAddNName.Size = new System.Drawing.Size(99, 23);
            this.buttonAddNName.TabIndex = 5;
            this.buttonAddNName.Text = "Добавить";
            this.buttonAddNName.UseVisualStyleBackColor = true;
            this.buttonAddNName.Click += new System.EventHandler(this.buttonAddNName_Click);
            // 
            // numericUpDownQn
            // 
            this.numericUpDownQn.Location = new System.Drawing.Point(143, 138);
            this.numericUpDownQn.Name = "numericUpDownQn";
            this.numericUpDownQn.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQn.TabIndex = 4;
            // 
            // numericUpDownCl
            // 
            this.numericUpDownCl.Location = new System.Drawing.Point(143, 112);
            this.numericUpDownCl.Name = "numericUpDownCl";
            this.numericUpDownCl.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCl.TabIndex = 3;
            // 
            // numericUpDownStl
            // 
            this.numericUpDownStl.Location = new System.Drawing.Point(143, 85);
            this.numericUpDownStl.Name = "numericUpDownStl";
            this.numericUpDownStl.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStl.TabIndex = 2;
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(142, 58);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxName.TabIndex = 1;
            // 
            // textBoxNName
            // 
            this.textBoxNName.Location = new System.Drawing.Point(142, 32);
            this.textBoxNName.Name = "textBoxNName";
            this.textBoxNName.Size = new System.Drawing.Size(121, 20);
            this.textBoxNName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonSearch);
            this.groupBox3.Controls.Add(this.textBoxNSr);
            this.groupBox3.Location = new System.Drawing.Point(616, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск по названию";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Имя товара для поиска";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(321, 34);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxNSr
            // 
            this.textBoxNSr.Location = new System.Drawing.Point(170, 34);
            this.textBoxNSr.Name = "textBoxNSr";
            this.textBoxNSr.Size = new System.Drawing.Size(120, 20);
            this.textBoxNSr.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.buttonCoordSr);
            this.groupBox4.Controls.Add(this.numericUpDownSrCl);
            this.groupBox4.Controls.Add(this.numericUpDownSrSl);
            this.groupBox4.Location = new System.Drawing.Point(616, 366);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 165);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поиск по координатам";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ячейка";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Стелаж";
            // 
            // buttonCoordSr
            // 
            this.buttonCoordSr.Location = new System.Drawing.Point(321, 44);
            this.buttonCoordSr.Name = "buttonCoordSr";
            this.buttonCoordSr.Size = new System.Drawing.Size(75, 23);
            this.buttonCoordSr.TabIndex = 2;
            this.buttonCoordSr.Text = "Поиск";
            this.buttonCoordSr.UseVisualStyleBackColor = true;
            this.buttonCoordSr.Click += new System.EventHandler(this.buttonCoordSr_Click);
            // 
            // numericUpDownSrCl
            // 
            this.numericUpDownSrCl.Location = new System.Drawing.Point(142, 46);
            this.numericUpDownSrCl.Name = "numericUpDownSrCl";
            this.numericUpDownSrCl.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSrCl.TabIndex = 1;
            // 
            // numericUpDownSrSl
            // 
            this.numericUpDownSrSl.Location = new System.Drawing.Point(6, 47);
            this.numericUpDownSrSl.Name = "numericUpDownSrSl";
            this.numericUpDownSrSl.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSrSl.TabIndex = 0;
            // 
            // buttonOpen2
            // 
            this.buttonOpen2.Location = new System.Drawing.Point(287, 135);
            this.buttonOpen2.Name = "buttonOpen2";
            this.buttonOpen2.Size = new System.Drawing.Size(99, 23);
            this.buttonOpen2.TabIndex = 15;
            this.buttonOpen2.Text = "Открыть";
            this.buttonOpen2.UseVisualStyleBackColor = true;
            this.buttonOpen2.Click += new System.EventHandler(this.buttonOpen2_Click);
            // 
            // Sklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 534);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sklad";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Sklad_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStl)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSrCl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSrSl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonAddNName;
        private System.Windows.Forms.NumericUpDown numericUpDownQn;
        private System.Windows.Forms.NumericUpDown numericUpDownCl;
        private System.Windows.Forms.NumericUpDown numericUpDownStl;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.TextBox textBoxNName;
        private System.Windows.Forms.TextBox textBoxNSr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelSelected;
        private System.Windows.Forms.Button buttonAddInDGV;
        private System.Windows.Forms.Button buttonSaveLike;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonCoordSr;
        private System.Windows.Forms.NumericUpDown numericUpDownSrCl;
        private System.Windows.Forms.NumericUpDown numericUpDownSrSl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOpen2;
    }
}

