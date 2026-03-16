namespace BackpackApp
{
    partial class MainForm
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
            this.listViewBackpack = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewBackpack
            // 
            this.listViewBackpack.HideSelection = false;
            this.listViewBackpack.Location = new System.Drawing.Point(12, 12);
            this.listViewBackpack.Name = "listViewBackpack";
            this.listViewBackpack.Size = new System.Drawing.Size(338, 272);
            this.listViewBackpack.TabIndex = 0;
            this.listViewBackpack.UseCompatibleStateImageBehavior = false;
            this.listViewBackpack.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(356, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Максимальный вес рюкзака:";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(579, 22);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(80, 20);
            this.textBoxWeight.TabIndex = 2;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolve.Location = new System.Drawing.Point(449, 70);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(89, 27);
            this.buttonSolve.TabIndex = 3;
            this.buttonSolve.Text = "Решить";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReset.Location = new System.Drawing.Point(391, 257);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(238, 27);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Показать исходные данные";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 296);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewBackpack);
            this.Name = "MainForm";
            this.Text = "Задача о рюкзаке";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBackpack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonReset;
    }
}

