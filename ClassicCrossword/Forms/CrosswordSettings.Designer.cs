namespace ClassicCrossword.Forms
{
    partial class CrosswordSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridSizeVertical = new System.Windows.Forms.NumericUpDown();
            this.gridSizeHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openDefDictionary = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.automaticalRadioButton = new System.Windows.Forms.RadioButton();
            this.manualRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeHorizontal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridSizeVertical);
            this.groupBox1.Controls.Add(this.gridSizeHorizontal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(44, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размеры сетки";
            // 
            // gridSizeVertical
            // 
            this.gridSizeVertical.Location = new System.Drawing.Point(219, 63);
            this.gridSizeVertical.Name = "gridSizeVertical";
            this.gridSizeVertical.Size = new System.Drawing.Size(120, 23);
            this.gridSizeVertical.TabIndex = 7;
            this.gridSizeVertical.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // gridSizeHorizontal
            // 
            this.gridSizeHorizontal.Location = new System.Drawing.Point(219, 36);
            this.gridSizeHorizontal.Name = "gridSizeHorizontal";
            this.gridSizeHorizontal.Size = new System.Drawing.Size(120, 23);
            this.gridSizeHorizontal.TabIndex = 6;
            this.gridSizeHorizontal.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(61, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "По вертикали";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(58, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "По горизонтали";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.openDefDictionary);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox2.Location = new System.Drawing.Point(44, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Словарь";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 23);
            this.textBox1.TabIndex = 1;
            // 
            // openDefDictionary
            // 
            this.openDefDictionary.Location = new System.Drawing.Point(312, 44);
            this.openDefDictionary.Name = "openDefDictionary";
            this.openDefDictionary.Size = new System.Drawing.Size(81, 23);
            this.openDefDictionary.TabIndex = 0;
            this.openDefDictionary.Text = "Обзор...";
            this.openDefDictionary.UseVisualStyleBackColor = true;
            this.openDefDictionary.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.automaticalRadioButton);
            this.groupBox3.Controls.Add(this.manualRadioButton);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox3.Location = new System.Drawing.Point(44, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Режим создания кроссворда";
            // 
            // automaticalRadioButton
            // 
            this.automaticalRadioButton.AutoSize = true;
            this.automaticalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.automaticalRadioButton.Location = new System.Drawing.Point(236, 46);
            this.automaticalRadioButton.Name = "automaticalRadioButton";
            this.automaticalRadioButton.Size = new System.Drawing.Size(135, 21);
            this.automaticalRadioButton.TabIndex = 1;
            this.automaticalRadioButton.TabStop = true;
            this.automaticalRadioButton.Text = "Автоматический";
            this.automaticalRadioButton.UseVisualStyleBackColor = true;
            // 
            // manualRadioButton
            // 
            this.manualRadioButton.AutoSize = true;
            this.manualRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.manualRadioButton.Location = new System.Drawing.Point(86, 46);
            this.manualRadioButton.Name = "manualRadioButton";
            this.manualRadioButton.Size = new System.Drawing.Size(74, 21);
            this.manualRadioButton.TabIndex = 0;
            this.manualRadioButton.TabStop = true;
            this.manualRadioButton.Text = "Ручной";
            this.manualRadioButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(201, 357);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(108, 33);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // CrosswordSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 402);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "CrosswordSettings";
            this.Text = "Параметры кроссворда";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeHorizontal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton automaticalRadioButton;
        private System.Windows.Forms.RadioButton manualRadioButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button openDefDictionary;
        private System.Windows.Forms.NumericUpDown gridSizeVertical;
        private System.Windows.Forms.NumericUpDown gridSizeHorizontal;
    }
}