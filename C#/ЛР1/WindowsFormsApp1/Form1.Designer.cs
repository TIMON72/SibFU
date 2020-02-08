namespace WindowsFormsApp1
{
    partial class Form1
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
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.maskedTextBoxXStart = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxXEnd = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxAccuracy = new System.Windows.Forms.MaskedTextBox();
            this.labelXStart = new System.Windows.Forms.Label();
            this.labelDX = new System.Windows.Forms.Label();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(450, 399);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 489);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Вычислить";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // maskedTextBoxXStart
            // 
            this.maskedTextBoxXStart.Location = new System.Drawing.Point(131, 6);
            this.maskedTextBoxXStart.Mask = "###.##";
            this.maskedTextBoxXStart.Name = "maskedTextBoxXStart";
            this.maskedTextBoxXStart.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxXStart.TabIndex = 2;
            // 
            // maskedTextBoxXEnd
            // 
            this.maskedTextBoxXEnd.Location = new System.Drawing.Point(253, 6);
            this.maskedTextBoxXEnd.Mask = "###.##";
            this.maskedTextBoxXEnd.Name = "maskedTextBoxXEnd";
            this.maskedTextBoxXEnd.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxXEnd.TabIndex = 3;
            // 
            // maskedTextBoxDX
            // 
            this.maskedTextBoxDX.Location = new System.Drawing.Point(131, 32);
            this.maskedTextBoxDX.Mask = "##.##";
            this.maskedTextBoxDX.Name = "maskedTextBoxDX";
            this.maskedTextBoxDX.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDX.TabIndex = 4;
            // 
            // maskedTextBoxAccuracy
            // 
            this.maskedTextBoxAccuracy.Location = new System.Drawing.Point(131, 58);
            this.maskedTextBoxAccuracy.Mask = "\\0.00000000";
            this.maskedTextBoxAccuracy.Name = "maskedTextBoxAccuracy";
            this.maskedTextBoxAccuracy.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxAccuracy.TabIndex = 5;
            // 
            // labelXStart
            // 
            this.labelXStart.AutoSize = true;
            this.labelXStart.Location = new System.Drawing.Point(12, 9);
            this.labelXStart.Name = "labelXStart";
            this.labelXStart.Size = new System.Drawing.Size(113, 13);
            this.labelXStart.TabIndex = 6;
            this.labelXStart.Text = "Введите диапазон X:";
            // 
            // labelDX
            // 
            this.labelDX.AutoSize = true;
            this.labelDX.Location = new System.Drawing.Point(35, 35);
            this.labelDX.Name = "labelDX";
            this.labelDX.Size = new System.Drawing.Size(90, 13);
            this.labelDX.TabIndex = 8;
            this.labelDX.Text = "Введите шаг dX:";
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Location = new System.Drawing.Point(25, 61);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(100, 13);
            this.labelAccuracy.TabIndex = 9;
            this.labelAccuracy.Text = "Введите точность:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 524);
            this.Controls.Add(this.labelAccuracy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDX);
            this.Controls.Add(this.labelXStart);
            this.Controls.Add(this.maskedTextBoxAccuracy);
            this.Controls.Add(this.maskedTextBoxDX);
            this.Controls.Add(this.maskedTextBoxXEnd);
            this.Controls.Add(this.maskedTextBoxXStart);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.dataGridViewResults);
            this.Name = "Form1";
            this.Text = "ЛР1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxXStart;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxXEnd;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAccuracy;
        private System.Windows.Forms.Label labelXStart;
        private System.Windows.Forms.Label labelDX;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.Label label1;
    }
}

