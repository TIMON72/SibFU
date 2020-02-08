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
            this.richTextBoxCiphertext = new System.Windows.Forms.RichTextBox();
            this.buttonTaskCiphertext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFindKeysLength = new System.Windows.Forms.Button();
            this.richTextBoxRepeatingElements = new System.Windows.Forms.RichTextBox();
            this.richTextBoxNODs = new System.Windows.Forms.RichTextBox();
            this.richTextBoxKeyLength = new System.Windows.Forms.RichTextBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeciphering = new System.Windows.Forms.Button();
            this.buttonFindKeys = new System.Windows.Forms.Button();
            this.richTextBoxKeys = new System.Windows.Forms.RichTextBox();
            this.richTextBoxKey = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDeep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxCiphertext
            // 
            this.richTextBoxCiphertext.Location = new System.Drawing.Point(12, 25);
            this.richTextBoxCiphertext.Name = "richTextBoxCiphertext";
            this.richTextBoxCiphertext.Size = new System.Drawing.Size(202, 106);
            this.richTextBoxCiphertext.TabIndex = 0;
            this.richTextBoxCiphertext.Text = "";
            // 
            // buttonTaskCiphertext
            // 
            this.buttonTaskCiphertext.Location = new System.Drawing.Point(136, 4);
            this.buttonTaskCiphertext.Name = "buttonTaskCiphertext";
            this.buttonTaskCiphertext.Size = new System.Drawing.Size(78, 23);
            this.buttonTaskCiphertext.TabIndex = 1;
            this.buttonTaskCiphertext.Text = "Добавить";
            this.buttonTaskCiphertext.UseVisualStyleBackColor = true;
            this.buttonTaskCiphertext.Click += new System.EventHandler(this.buttonTaskCiphertext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Шифротекст:";
            // 
            // buttonFindKeysLength
            // 
            this.buttonFindKeysLength.Location = new System.Drawing.Point(12, 137);
            this.buttonFindKeysLength.Name = "buttonFindKeysLength";
            this.buttonFindKeysLength.Size = new System.Drawing.Size(202, 23);
            this.buttonFindKeysLength.TabIndex = 3;
            this.buttonFindKeysLength.Text = "Поиск длины ключа";
            this.buttonFindKeysLength.UseVisualStyleBackColor = true;
            this.buttonFindKeysLength.Click += new System.EventHandler(this.buttonFindKeysLength_Click);
            // 
            // richTextBoxRepeatingElements
            // 
            this.richTextBoxRepeatingElements.Location = new System.Drawing.Point(12, 166);
            this.richTextBoxRepeatingElements.Name = "richTextBoxRepeatingElements";
            this.richTextBoxRepeatingElements.ReadOnly = true;
            this.richTextBoxRepeatingElements.Size = new System.Drawing.Size(95, 106);
            this.richTextBoxRepeatingElements.TabIndex = 4;
            this.richTextBoxRepeatingElements.Text = "";
            // 
            // richTextBoxNODs
            // 
            this.richTextBoxNODs.Location = new System.Drawing.Point(113, 166);
            this.richTextBoxNODs.Name = "richTextBoxNODs";
            this.richTextBoxNODs.ReadOnly = true;
            this.richTextBoxNODs.Size = new System.Drawing.Size(47, 106);
            this.richTextBoxNODs.TabIndex = 7;
            this.richTextBoxNODs.Text = "";
            // 
            // richTextBoxKeyLength
            // 
            this.richTextBoxKeyLength.Location = new System.Drawing.Point(113, 278);
            this.richTextBoxKeyLength.Name = "richTextBoxKeyLength";
            this.richTextBoxKeyLength.ReadOnly = true;
            this.richTextBoxKeyLength.Size = new System.Drawing.Size(47, 23);
            this.richTextBoxKeyLength.TabIndex = 9;
            this.richTextBoxKeyLength.Text = "";
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Location = new System.Drawing.Point(277, 25);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.ReadOnly = true;
            this.richTextBoxText.Size = new System.Drawing.Size(202, 106);
            this.richTextBoxText.TabIndex = 13;
            this.richTextBoxText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Текст:";
            // 
            // buttonDeciphering
            // 
            this.buttonDeciphering.Location = new System.Drawing.Point(277, 137);
            this.buttonDeciphering.Name = "buttonDeciphering";
            this.buttonDeciphering.Size = new System.Drawing.Size(202, 23);
            this.buttonDeciphering.TabIndex = 15;
            this.buttonDeciphering.Text = "Расшифрование";
            this.buttonDeciphering.UseVisualStyleBackColor = true;
            this.buttonDeciphering.Click += new System.EventHandler(this.buttonDeciphering_Click);
            // 
            // buttonFindKeys
            // 
            this.buttonFindKeys.Location = new System.Drawing.Point(372, 166);
            this.buttonFindKeys.Name = "buttonFindKeys";
            this.buttonFindKeys.Size = new System.Drawing.Size(107, 23);
            this.buttonFindKeys.TabIndex = 16;
            this.buttonFindKeys.Text = "Поиск ключей";
            this.buttonFindKeys.UseVisualStyleBackColor = true;
            this.buttonFindKeys.Click += new System.EventHandler(this.buttonFindKeys_Click);
            // 
            // richTextBoxKeys
            // 
            this.richTextBoxKeys.Location = new System.Drawing.Point(372, 195);
            this.richTextBoxKeys.Name = "richTextBoxKeys";
            this.richTextBoxKeys.Size = new System.Drawing.Size(107, 109);
            this.richTextBoxKeys.TabIndex = 17;
            this.richTextBoxKeys.Text = "";
            // 
            // richTextBoxKey
            // 
            this.richTextBoxKey.Location = new System.Drawing.Point(397, 4);
            this.richTextBoxKey.Name = "richTextBoxKey";
            this.richTextBoxKey.Size = new System.Drawing.Size(82, 23);
            this.richTextBoxKey.TabIndex = 18;
            this.richTextBoxKey.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ключ:";
            // 
            // textBoxDeep
            // 
            this.textBoxDeep.Location = new System.Drawing.Point(343, 166);
            this.textBoxDeep.Name = "textBoxDeep";
            this.textBoxDeep.Size = new System.Drawing.Size(23, 20);
            this.textBoxDeep.TabIndex = 20;
            this.textBoxDeep.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Длина ключа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Глубина поиска:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 329);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDeep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxKey);
            this.Controls.Add(this.richTextBoxKeys);
            this.Controls.Add(this.buttonFindKeys);
            this.Controls.Add(this.buttonDeciphering);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxText);
            this.Controls.Add(this.richTextBoxKeyLength);
            this.Controls.Add(this.richTextBoxNODs);
            this.Controls.Add(this.richTextBoxRepeatingElements);
            this.Controls.Add(this.buttonFindKeysLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTaskCiphertext);
            this.Controls.Add(this.richTextBoxCiphertext);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCiphertext;
        private System.Windows.Forms.Button buttonTaskCiphertext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFindKeysLength;
        private System.Windows.Forms.RichTextBox richTextBoxRepeatingElements;
        private System.Windows.Forms.RichTextBox richTextBoxNODs;
        private System.Windows.Forms.RichTextBox richTextBoxKeyLength;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDeciphering;
        private System.Windows.Forms.Button buttonFindKeys;
        private System.Windows.Forms.RichTextBox richTextBoxKeys;
        private System.Windows.Forms.RichTextBox richTextBoxKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDeep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

