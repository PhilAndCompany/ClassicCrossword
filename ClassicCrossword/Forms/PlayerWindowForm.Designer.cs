namespace ClassicCrossword.Forms
{
    partial class PlayerWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindowForm));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHints = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvtbcDef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.решатьКроссвордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйКроссвордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСохраненныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРешениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.взятьПодсказкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьКроссвордаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьРешенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвторахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvCrossword = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblCntHint = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrossword)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(525, 538);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 30);
            this.button2.TabIndex = 17;
            this.button2.Text = "ПАУЗА";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(682, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "ПРОВЕРИТЬ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHints
            // 
            this.lblHints.AutoSize = true;
            this.lblHints.Enabled = false;
            this.lblHints.Location = new System.Drawing.Point(22, 548);
            this.lblHints.Name = "lblHints";
            this.lblHints.Size = new System.Drawing.Size(171, 13);
            this.lblHints.TabIndex = 13;
            this.lblHints.Text = "Подсказок по буквам осталось:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(870, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 438);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "По вертикали:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(6, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(312, 414);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Определение";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(545, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 441);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "По горизонтали:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcDef});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(7, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(307, 416);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvtbcDef
            // 
            this.dgvtbcDef.HeaderText = "Определение";
            this.dgvtbcDef.Name = "dgvtbcDef";
            this.dgvtbcDef.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(22, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Время решения: XX:XX:XX";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.решатьКроссвордToolStripMenuItem,
            this.сохранитьРешениеToolStripMenuItem,
            this.взятьПодсказкуToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.печатьToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1195, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // решатьКроссвордToolStripMenuItem
            // 
            this.решатьКроссвордToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйКроссвордToolStripMenuItem,
            this.загрузитьСохраненныйToolStripMenuItem});
            this.решатьКроссвордToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.checkered;
            this.решатьКроссвордToolStripMenuItem.Name = "решатьКроссвордToolStripMenuItem";
            this.решатьКроссвордToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.решатьКроссвордToolStripMenuItem.Text = "Решать кроссворд";
            // 
            // новыйКроссвордToolStripMenuItem
            // 
            this.новыйКроссвордToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.page_with_one_curled_corner;
            this.новыйКроссвордToolStripMenuItem.Name = "новыйКроссвордToolStripMenuItem";
            this.новыйКроссвордToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.новыйКроссвордToolStripMenuItem.Text = "Выбрать кроссворд";
            this.новыйКроссвордToolStripMenuItem.Click += new System.EventHandler(this.новыйКроссвордToolStripMenuItem_Click);
            // 
            // загрузитьСохраненныйToolStripMenuItem
            // 
            this.загрузитьСохраненныйToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.gramophone_record;
            this.загрузитьСохраненныйToolStripMenuItem.Name = "загрузитьСохраненныйToolStripMenuItem";
            this.загрузитьСохраненныйToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загрузитьСохраненныйToolStripMenuItem.Text = "Загрузить сохраненный";
            this.загрузитьСохраненныйToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСохраненныйToolStripMenuItem_Click);
            // 
            // сохранитьРешениеToolStripMenuItem
            // 
            this.сохранитьРешениеToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.file_inbox;
            this.сохранитьРешениеToolStripMenuItem.Name = "сохранитьРешениеToolStripMenuItem";
            this.сохранитьРешениеToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.сохранитьРешениеToolStripMenuItem.Text = "Сохранить прогресс";
            this.сохранитьРешениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьРешениеToolStripMenuItem_Click);
            // 
            // взятьПодсказкуToolStripMenuItem
            // 
            this.взятьПодсказкуToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.text_alphabet_a;
            this.взятьПодсказкуToolStripMenuItem.Name = "взятьПодсказкуToolStripMenuItem";
            this.взятьПодсказкуToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.взятьПодсказкуToolStripMenuItem.Text = "Подсказать букву";
            this.взятьПодсказкуToolStripMenuItem.Click += new System.EventHandler(this.взятьПодсказкуToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.favourite_star;
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьКроссвордаToolStripMenuItem,
            this.печатьРешенияToolStripMenuItem});
            this.печатьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.printer;
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.печатьToolStripMenuItem.Text = "Печать";
            // 
            // печатьКроссвордаToolStripMenuItem
            // 
            this.печатьКроссвордаToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.checkered;
            this.печатьКроссвордаToolStripMenuItem.Name = "печатьКроссвордаToolStripMenuItem";
            this.печатьКроссвордаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьКроссвордаToolStripMenuItem.Text = "Печать кроссворда";
            this.печатьКроссвордаToolStripMenuItem.Click += new System.EventHandler(this.печатьКроссвордаToolStripMenuItem_Click);
            // 
            // печатьРешенияToolStripMenuItem
            // 
            this.печатьРешенияToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.watch_dark_eye;
            this.печатьРешенияToolStripMenuItem.Name = "печатьРешенияToolStripMenuItem";
            this.печатьРешенияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьРешенияToolStripMenuItem.Text = "Печать ответов";
            this.печатьРешенияToolStripMenuItem.Click += new System.EventHandler(this.печатьРешенияToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.обАвторахToolStripMenuItem});
            this.справкаToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.question_button;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.create_list_button;
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            this.руководствоПользователяToolStripMenuItem.Click += new System.EventHandler(this.руководствоПользователяToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.information_button;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // обАвторахToolStripMenuItem
            // 
            this.обАвторахToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.personal_avatar;
            this.обАвторахToolStripMenuItem.Name = "обАвторахToolStripMenuItem";
            this.обАвторахToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.обАвторахToolStripMenuItem.Text = "Об авторах";
            this.обАвторахToolStripMenuItem.Click += new System.EventHandler(this.обАвторахToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.button_on_off;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dgvCrossword);
            this.mainPanel.Location = new System.Drawing.Point(12, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(527, 441);
            this.mainPanel.TabIndex = 37;
            // 
            // dgvCrossword
            // 
            this.dgvCrossword.AllowUserToAddRows = false;
            this.dgvCrossword.AllowUserToDeleteRows = false;
            this.dgvCrossword.AllowUserToResizeColumns = false;
            this.dgvCrossword.AllowUserToResizeRows = false;
            this.dgvCrossword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrossword.ColumnHeadersVisible = false;
            this.dgvCrossword.EnableHeadersVisualStyles = false;
            this.dgvCrossword.Location = new System.Drawing.Point(3, 3);
            this.dgvCrossword.Name = "dgvCrossword";
            this.dgvCrossword.RowHeadersVisible = false;
            this.dgvCrossword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCrossword.Size = new System.Drawing.Size(521, 435);
            this.dgvCrossword.TabIndex = 38;
            this.dgvCrossword.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCrossword_CellEndEdit);
            this.dgvCrossword.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCrossword_EditingControlShowing);
            this.dgvCrossword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCrossword_KeyPress);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblCntHint
            // 
            this.lblCntHint.AutoSize = true;
            this.lblCntHint.Location = new System.Drawing.Point(202, 548);
            this.lblCntHint.Name = "lblCntHint";
            this.lblCntHint.Size = new System.Drawing.Size(0, 13);
            this.lblCntHint.TabIndex = 38;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Document = this.printDocument2;
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            this.printPreviewDialog2.Visible = false;
            // 
            // PlayerWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 601);
            this.Controls.Add(this.lblCntHint);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHints);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PlayerWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EFM - %USERNAME%";
            this.Load += new System.EventHandler(this.UserWindowForm_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrossword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHints;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьРешенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьКроссвордаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem взятьПодсказкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРешениеToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem решатьКроссвордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйКроссвордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСохраненныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обАвторахToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dgvCrossword;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcDef;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblCntHint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
    }
}