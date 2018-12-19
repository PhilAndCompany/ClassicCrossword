﻿namespace ClassicCrossword.Forms
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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.подсказатьСловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подсказатьБуквуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(22, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Подсказок по словам осталось: X";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(682, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "ПРОВЕРИТЬ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(22, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Подсказок по буквам осталось: X";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(545, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 225);
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
            this.dataGridView2.Size = new System.Drawing.Size(312, 201);
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
            this.groupBox2.Size = new System.Drawing.Size(325, 210);
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
            this.dataGridView1.Size = new System.Drawing.Size(312, 201);
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
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
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
            // 
            // сохранитьРешениеToolStripMenuItem
            // 
            this.сохранитьРешениеToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.file_inbox;
            this.сохранитьРешениеToolStripMenuItem.Name = "сохранитьРешениеToolStripMenuItem";
            this.сохранитьРешениеToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.сохранитьРешениеToolStripMenuItem.Text = "Сохранить прогресс";
            // 
            // взятьПодсказкуToolStripMenuItem
            // 
            this.взятьПодсказкуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подсказатьСловToolStripMenuItem,
            this.подсказатьБуквуToolStripMenuItem});
            this.взятьПодсказкуToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.pair_of_glases;
            this.взятьПодсказкуToolStripMenuItem.Name = "взятьПодсказкуToolStripMenuItem";
            this.взятьПодсказкуToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.взятьПодсказкуToolStripMenuItem.Text = "Взять подсказку";
            // 
            // подсказатьСловToolStripMenuItem
            // 
            this.подсказатьСловToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.text_box_tool;
            this.подсказатьСловToolStripMenuItem.Name = "подсказатьСловToolStripMenuItem";
            this.подсказатьСловToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.подсказатьСловToolStripMenuItem.Text = "Подсказать слово";
            // 
            // подсказатьБуквуToolStripMenuItem
            // 
            this.подсказатьБуквуToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.text_alphabet_a;
            this.подсказатьБуквуToolStripMenuItem.Name = "подсказатьБуквуToolStripMenuItem";
            this.подсказатьБуквуToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.подсказатьБуквуToolStripMenuItem.Text = "Подсказать букву";
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
            // 
            // печатьРешенияToolStripMenuItem
            // 
            this.печатьРешенияToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.watch_dark_eye;
            this.печатьРешенияToolStripMenuItem.Name = "печатьРешенияToolStripMenuItem";
            this.печатьРешенияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьРешенияToolStripMenuItem.Text = "Печать ответов";
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
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.information_button;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // обАвторахToolStripMenuItem
            // 
            this.обАвторахToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.personal_avatar;
            this.обАвторахToolStripMenuItem.Name = "обАвторахToolStripMenuItem";
            this.обАвторахToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.обАвторахToolStripMenuItem.Text = "Об авторах";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.button_on_off;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.выходToolStripMenuItem.Text = "Выход";
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
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PlayerWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 601);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьРешенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьКроссвордаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подсказатьБуквуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подсказатьСловToolStripMenuItem;
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
    }
}