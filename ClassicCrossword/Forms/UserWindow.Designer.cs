namespace ClassicCrossword.Forms
{
    partial class UserWindow
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.menuStrip1.SuspendLayout();
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
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(487, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 210);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "По вертикали:";
            // 
            // groupBox2
            // 
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(487, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 210);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "По горизонтали:";
            // 
            // groupBox1
            // 
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(22, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 443);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "КРОССВОРД %CROSSWORDNAME%";
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
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
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
            this.новыйКроссвордToolStripMenuItem.Text = "Новый кроссворд";
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
            // UserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 601);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserWindow";
            this.Text = "EFM - %USERNAME%";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}