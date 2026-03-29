namespace AlarmClock
{
    partial class AlarmEditDialog
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
            this.checkBoxActivity = new System.Windows.Forms.CheckBox();
            this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.labelTimePreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxActivity
            // 
            this.checkBoxActivity.AutoSize = true;
            this.checkBoxActivity.Location = new System.Drawing.Point(12, 51);
            this.checkBoxActivity.Name = "checkBoxActivity";
            this.checkBoxActivity.Size = new System.Drawing.Size(124, 17);
            this.checkBoxActivity.TabIndex = 1;
            this.checkBoxActivity.Text = "Будильник активен";
            this.checkBoxActivity.UseVisualStyleBackColor = true;
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.AutoSize = true;
            this.checkBoxRepeat.Location = new System.Drawing.Point(12, 84);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(139, 17);
            this.checkBoxRepeat.TabIndex = 2;
            this.checkBoxRepeat.Text = "Повторять ежедневно";
            this.checkBoxRepeat.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 119);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(195, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(98, 145);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(47, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(151, 145);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(56, 23);
            this.buttonUndo.TabIndex = 5;
            this.buttonUndo.Text = "Отмена";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(12, 12);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            86399,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(195, 20);
            this.numericUpDownTime.TabIndex = 6;
            this.numericUpDownTime.ValueChanged += new System.EventHandler(this.NumericUpDownTime_ValueChanged);
            // 
            // labelTimePreview
            // 
            this.labelTimePreview.AutoSize = true;
            this.labelTimePreview.Location = new System.Drawing.Point(12, 14);
            this.labelTimePreview.Name = "labelTimePreview";
            this.labelTimePreview.Size = new System.Drawing.Size(0, 13);
            this.labelTimePreview.TabIndex = 7;
            // 
            // AlarmEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 183);
            this.Controls.Add(this.labelTimePreview);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.checkBoxRepeat);
            this.Controls.Add(this.checkBoxActivity);
            this.Name = "AlarmEditDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxActivity;
        private System.Windows.Forms.CheckBox checkBoxRepeat;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.Label labelTimePreview;
    }
}