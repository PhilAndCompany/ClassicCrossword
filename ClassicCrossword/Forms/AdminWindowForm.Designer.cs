namespace ClassicCrossword
{
    partial class AdminWindowForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWindowForm));
            this.labelSearchByMask = new System.Windows.Forms.Label();
            this.textBoxSearchByMask = new System.Windows.Forms.TextBox();
            this.dataGridViewVocabularyOfC = new System.Windows.Forms.DataGridView();
            this.dgvtbcNot1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxVocabularyOfC = new System.Windows.Forms.GroupBox();
            this.textBoxVocabularyWordsCountOnC = new System.Windows.Forms.TextBox();
            this.labelVocabularyWordsCountOnC = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPageCrossword = new System.Windows.Forms.TabPage();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBoxVocabularyInstruments = new System.Windows.Forms.GroupBox();
            this.buttonClearMask = new System.Windows.Forms.Button();
            this.buttonSortByAlphabet = new System.Windows.Forms.Button();
            this.buttonSortByLength = new System.Windows.Forms.Button();
            this.menuStripCrossword = new System.Windows.Forms.MenuStrip();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьсловарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыКроссвордаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьКроссвордаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьОтветовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвторахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageVocabulary = new System.Windows.Forms.TabPage();
            this.groupBoxVocabularyOfV = new System.Windows.Forms.GroupBox();
            this.textBoxVocabularyWordsCountOnV = new System.Windows.Forms.TextBox();
            this.labelabelVocabularyWordsCountOnV = new System.Windows.Forms.Label();
            this.dataGridViewVocabularyOfV = new System.Windows.Forms.DataGridView();
            this.dgvtbcNot2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcDef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripVocabulary = new System.Windows.Forms.MenuStrip();
            this.создатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСловарьtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвторахToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageAccounts = new System.Windows.Forms.TabPage();
            this.groupBoxAccounts = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crosswordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.crosswordDataSet = new ClassicCrossword.CrosswordDataSet();
            this.menuStripAccount = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотретьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвторахToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.playerTableAdapter = new ClassicCrossword.CrosswordDataSetTableAdapters.PlayerTableAdapter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVocabularyOfC)).BeginInit();
            this.groupBoxVocabularyOfC.SuspendLayout();
            this.tabControlMenu.SuspendLayout();
            this.tabPageCrossword.SuspendLayout();
            this.groupBoxVocabularyInstruments.SuspendLayout();
            this.menuStripCrossword.SuspendLayout();
            this.tabPageVocabulary.SuspendLayout();
            this.groupBoxVocabularyOfV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVocabularyOfV)).BeginInit();
            this.menuStripVocabulary.SuspendLayout();
            this.tabPageAccounts.SuspendLayout();
            this.groupBoxAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosswordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosswordDataSet)).BeginInit();
            this.menuStripAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchByMask
            // 
            this.labelSearchByMask.AutoSize = true;
            this.labelSearchByMask.Location = new System.Drawing.Point(5, 62);
            this.labelSearchByMask.Name = "labelSearchByMask";
            this.labelSearchByMask.Size = new System.Drawing.Size(92, 13);
            this.labelSearchByMask.TabIndex = 29;
            this.labelSearchByMask.Text = "Поиск по маске:";
            this.labelSearchByMask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSearchByMask
            // 
            this.textBoxSearchByMask.Location = new System.Drawing.Point(103, 59);
            this.textBoxSearchByMask.Name = "textBoxSearchByMask";
            this.textBoxSearchByMask.Size = new System.Drawing.Size(108, 20);
            this.textBoxSearchByMask.TabIndex = 28;
            // 
            // dataGridViewVocabularyOfC
            // 
            this.dataGridViewVocabularyOfC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVocabularyOfC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVocabularyOfC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcNot1});
            this.dataGridViewVocabularyOfC.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewVocabularyOfC.Name = "dataGridViewVocabularyOfC";
            this.dataGridViewVocabularyOfC.Size = new System.Drawing.Size(254, 382);
            this.dataGridViewVocabularyOfC.TabIndex = 0;
            // 
            // dgvtbcNot1
            // 
            this.dgvtbcNot1.HeaderText = "Понятие";
            this.dgvtbcNot1.Name = "dgvtbcNot1";
            // 
            // groupBoxVocabularyOfC
            // 
            this.groupBoxVocabularyOfC.Controls.Add(this.textBoxVocabularyWordsCountOnC);
            this.groupBoxVocabularyOfC.Controls.Add(this.dataGridViewVocabularyOfC);
            this.groupBoxVocabularyOfC.Controls.Add(this.labelVocabularyWordsCountOnC);
            this.groupBoxVocabularyOfC.Location = new System.Drawing.Point(540, 30);
            this.groupBoxVocabularyOfC.Name = "groupBoxVocabularyOfC";
            this.groupBoxVocabularyOfC.Size = new System.Drawing.Size(266, 433);
            this.groupBoxVocabularyOfC.TabIndex = 25;
            this.groupBoxVocabularyOfC.TabStop = false;
            this.groupBoxVocabularyOfC.Text = "%VOCABULARYNAME%";
            // 
            // textBoxVocabularyWordsCountOnC
            // 
            this.textBoxVocabularyWordsCountOnC.Location = new System.Drawing.Point(179, 407);
            this.textBoxVocabularyWordsCountOnC.Name = "textBoxVocabularyWordsCountOnC";
            this.textBoxVocabularyWordsCountOnC.ReadOnly = true;
            this.textBoxVocabularyWordsCountOnC.Size = new System.Drawing.Size(59, 20);
            this.textBoxVocabularyWordsCountOnC.TabIndex = 33;
            // 
            // labelVocabularyWordsCountOnC
            // 
            this.labelVocabularyWordsCountOnC.AutoSize = true;
            this.labelVocabularyWordsCountOnC.Location = new System.Drawing.Point(25, 410);
            this.labelVocabularyWordsCountOnC.Name = "labelVocabularyWordsCountOnC";
            this.labelVocabularyWordsCountOnC.Size = new System.Drawing.Size(150, 13);
            this.labelVocabularyWordsCountOnC.TabIndex = 30;
            this.labelVocabularyWordsCountOnC.Text = "Количество слов в словаре:";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Enabled = false;
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheck.Location = new System.Drawing.Point(172, 478);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(200, 30);
            this.buttonCheck.TabIndex = 24;
            this.buttonCheck.Text = "ПРОВЕРИТЬ";
            this.buttonCheck.UseVisualStyleBackColor = true;
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Controls.Add(this.tabPageCrossword);
            this.tabControlMenu.Controls.Add(this.tabPageVocabulary);
            this.tabControlMenu.Controls.Add(this.tabPageAccounts);
            this.tabControlMenu.Location = new System.Drawing.Point(12, 12);
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.Size = new System.Drawing.Size(820, 586);
            this.tabControlMenu.TabIndex = 32;
            // 
            // tabPageCrossword
            // 
            this.tabPageCrossword.Controls.Add(this.mainPanel);
            this.tabPageCrossword.Controls.Add(this.buttonGenerate);
            this.tabPageCrossword.Controls.Add(this.groupBoxVocabularyInstruments);
            this.tabPageCrossword.Controls.Add(this.groupBoxVocabularyOfC);
            this.tabPageCrossword.Controls.Add(this.buttonCheck);
            this.tabPageCrossword.Controls.Add(this.menuStripCrossword);
            this.tabPageCrossword.Location = new System.Drawing.Point(4, 22);
            this.tabPageCrossword.Name = "tabPageCrossword";
            this.tabPageCrossword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCrossword.Size = new System.Drawing.Size(812, 560);
            this.tabPageCrossword.TabIndex = 0;
            this.tabPageCrossword.Text = "Кроссворд";
            this.tabPageCrossword.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(7, 31);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(527, 441);
            this.mainPanel.TabIndex = 36;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGenerate.Location = new System.Drawing.Point(172, 514);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(200, 30);
            this.buttonGenerate.TabIndex = 35;
            this.buttonGenerate.Text = "СГЕНЕРИРОВАТЬ";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBoxVocabularyInstruments
            // 
            this.groupBoxVocabularyInstruments.Controls.Add(this.textBoxSearchByMask);
            this.groupBoxVocabularyInstruments.Controls.Add(this.buttonClearMask);
            this.groupBoxVocabularyInstruments.Controls.Add(this.buttonSortByAlphabet);
            this.groupBoxVocabularyInstruments.Controls.Add(this.buttonSortByLength);
            this.groupBoxVocabularyInstruments.Controls.Add(this.labelSearchByMask);
            this.groupBoxVocabularyInstruments.Enabled = false;
            this.groupBoxVocabularyInstruments.Location = new System.Drawing.Point(540, 469);
            this.groupBoxVocabularyInstruments.Name = "groupBoxVocabularyInstruments";
            this.groupBoxVocabularyInstruments.Size = new System.Drawing.Size(266, 85);
            this.groupBoxVocabularyInstruments.TabIndex = 33;
            this.groupBoxVocabularyInstruments.TabStop = false;
            this.groupBoxVocabularyInstruments.Text = "%VOCABULARYNAME% INSTRUMENTS";
            // 
            // buttonClearMask
            // 
            this.buttonClearMask.BackgroundImage = global::ClassicCrossword.Properties.Resources.big_trash_container_from_side_view;
            this.buttonClearMask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClearMask.Location = new System.Drawing.Point(217, 47);
            this.buttonClearMask.Name = "buttonClearMask";
            this.buttonClearMask.Size = new System.Drawing.Size(32, 32);
            this.buttonClearMask.TabIndex = 32;
            this.buttonClearMask.UseVisualStyleBackColor = true;
            // 
            // buttonSortByAlphabet
            // 
            this.buttonSortByAlphabet.AutoSize = true;
            this.buttonSortByAlphabet.BackgroundImage = global::ClassicCrossword.Properties.Resources.text_alphabet_a;
            this.buttonSortByAlphabet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSortByAlphabet.Location = new System.Drawing.Point(103, 21);
            this.buttonSortByAlphabet.Name = "buttonSortByAlphabet";
            this.buttonSortByAlphabet.Size = new System.Drawing.Size(32, 32);
            this.buttonSortByAlphabet.TabIndex = 26;
            this.buttonSortByAlphabet.UseVisualStyleBackColor = true;
            // 
            // buttonSortByLength
            // 
            this.buttonSortByLength.BackgroundImage = global::ClassicCrossword.Properties.Resources.sorted;
            this.buttonSortByLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSortByLength.Location = new System.Drawing.Point(141, 21);
            this.buttonSortByLength.Name = "buttonSortByLength";
            this.buttonSortByLength.Size = new System.Drawing.Size(32, 32);
            this.buttonSortByLength.TabIndex = 27;
            this.buttonSortByLength.UseVisualStyleBackColor = true;
            // 
            // menuStripCrossword
            // 
            this.menuStripCrossword.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.выбратьсловарьToolStripMenuItem,
            this.параметрыКроссвордаToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.печатьToolStripMenuItem1,
            this.справкаToolStripMenuItem1,
            this.выходToolStripMenuItem1});
            this.menuStripCrossword.Location = new System.Drawing.Point(3, 3);
            this.menuStripCrossword.Name = "menuStripCrossword";
            this.menuStripCrossword.Size = new System.Drawing.Size(806, 24);
            this.menuStripCrossword.TabIndex = 34;
            this.menuStripCrossword.Text = "menuStrip2";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.page_with_one_curled_corner;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // выбратьсловарьToolStripMenuItem
            // 
            this.выбратьсловарьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.gross_pencil;
            this.выбратьсловарьToolStripMenuItem.Name = "выбратьсловарьToolStripMenuItem";
            this.выбратьсловарьToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.выбратьсловарьToolStripMenuItem.Text = "Выбрать словарь";
            this.выбратьсловарьToolStripMenuItem.Click += new System.EventHandler(this.выбратьсловарьToolStripMenuItem_Click);
            // 
            // параметрыКроссвордаToolStripMenuItem
            // 
            this.параметрыКроссвордаToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.monitor_brightness_symbol;
            this.параметрыКроссвордаToolStripMenuItem.Name = "параметрыКроссвордаToolStripMenuItem";
            this.параметрыКроссвордаToolStripMenuItem.Size = new System.Drawing.Size(166, 20);
            this.параметрыКроссвордаToolStripMenuItem.Text = "Параметры кроссворда";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Enabled = false;
            this.сохранитьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.file_inbox;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Enabled = false;
            this.очиститьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.big_trash_container_from_side_view;
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            // 
            // печатьToolStripMenuItem1
            // 
            this.печатьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьКроссвордаToolStripMenuItem,
            this.печатьОтветовToolStripMenuItem});
            this.печатьToolStripMenuItem1.Enabled = false;
            this.печатьToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.printer;
            this.печатьToolStripMenuItem1.Name = "печатьToolStripMenuItem1";
            this.печатьToolStripMenuItem1.Size = new System.Drawing.Size(74, 20);
            this.печатьToolStripMenuItem1.Text = "Печать";
            // 
            // печатьКроссвордаToolStripMenuItem
            // 
            this.печатьКроссвордаToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.checkered;
            this.печатьКроссвордаToolStripMenuItem.Name = "печатьКроссвордаToolStripMenuItem";
            this.печатьКроссвордаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьКроссвордаToolStripMenuItem.Text = "Печать кроссворда";
            // 
            // печатьОтветовToolStripMenuItem
            // 
            this.печатьОтветовToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.watch_dark_eye;
            this.печатьОтветовToolStripMenuItem.Name = "печатьОтветовToolStripMenuItem";
            this.печатьОтветовToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьОтветовToolStripMenuItem.Text = "Печать ответов";
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.обАвторахToolStripMenuItem});
            this.справкаToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.question_button;
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem1.Text = "Справка";
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
            // выходToolStripMenuItem1
            // 
            this.выходToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.button_on_off;
            this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            this.выходToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
            this.выходToolStripMenuItem1.Text = "Выход";
            // 
            // tabPageVocabulary
            // 
            this.tabPageVocabulary.Controls.Add(this.groupBoxVocabularyOfV);
            this.tabPageVocabulary.Controls.Add(this.menuStripVocabulary);
            this.tabPageVocabulary.Location = new System.Drawing.Point(4, 22);
            this.tabPageVocabulary.Name = "tabPageVocabulary";
            this.tabPageVocabulary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVocabulary.Size = new System.Drawing.Size(812, 560);
            this.tabPageVocabulary.TabIndex = 1;
            this.tabPageVocabulary.Text = "Словари";
            this.tabPageVocabulary.UseVisualStyleBackColor = true;
            // 
            // groupBoxVocabularyOfV
            // 
            this.groupBoxVocabularyOfV.Controls.Add(this.textBoxVocabularyWordsCountOnV);
            this.groupBoxVocabularyOfV.Controls.Add(this.labelabelVocabularyWordsCountOnV);
            this.groupBoxVocabularyOfV.Controls.Add(this.dataGridViewVocabularyOfV);
            this.groupBoxVocabularyOfV.Location = new System.Drawing.Point(6, 30);
            this.groupBoxVocabularyOfV.Name = "groupBoxVocabularyOfV";
            this.groupBoxVocabularyOfV.Size = new System.Drawing.Size(800, 524);
            this.groupBoxVocabularyOfV.TabIndex = 3;
            this.groupBoxVocabularyOfV.TabStop = false;
            this.groupBoxVocabularyOfV.Text = "%VOCABULARYNAME%";
            // 
            // textBoxVocabularyWordsCountOnV
            // 
            this.textBoxVocabularyWordsCountOnV.Location = new System.Drawing.Point(461, 496);
            this.textBoxVocabularyWordsCountOnV.Name = "textBoxVocabularyWordsCountOnV";
            this.textBoxVocabularyWordsCountOnV.ReadOnly = true;
            this.textBoxVocabularyWordsCountOnV.Size = new System.Drawing.Size(59, 20);
            this.textBoxVocabularyWordsCountOnV.TabIndex = 35;
            // 
            // labelabelVocabularyWordsCountOnV
            // 
            this.labelabelVocabularyWordsCountOnV.AutoSize = true;
            this.labelabelVocabularyWordsCountOnV.Location = new System.Drawing.Point(307, 499);
            this.labelabelVocabularyWordsCountOnV.Name = "labelabelVocabularyWordsCountOnV";
            this.labelabelVocabularyWordsCountOnV.Size = new System.Drawing.Size(150, 13);
            this.labelabelVocabularyWordsCountOnV.TabIndex = 34;
            this.labelabelVocabularyWordsCountOnV.Text = "Количество слов в словаре:";
            // 
            // dataGridViewVocabularyOfV
            // 
            this.dataGridViewVocabularyOfV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVocabularyOfV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewVocabularyOfV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVocabularyOfV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcNot2,
            this.dgvtbcDef});
            this.dataGridViewVocabularyOfV.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewVocabularyOfV.Name = "dataGridViewVocabularyOfV";
            this.dataGridViewVocabularyOfV.Size = new System.Drawing.Size(788, 463);
            this.dataGridViewVocabularyOfV.TabIndex = 0;
            // 
            // dgvtbcNot2
            // 
            this.dgvtbcNot2.HeaderText = "Понятие";
            this.dgvtbcNot2.Name = "dgvtbcNot2";
            // 
            // dgvtbcDef
            // 
            this.dgvtbcDef.HeaderText = "Определение";
            this.dgvtbcDef.Name = "dgvtbcDef";
            // 
            // menuStripVocabulary
            // 
            this.menuStripVocabulary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem1,
            this.редактироватьToolStripMenuItem1,
            this.сохранитьСловарьtoolStripMenuItem1,
            this.очиститьToolStripMenuItem1,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStripVocabulary.Location = new System.Drawing.Point(3, 3);
            this.menuStripVocabulary.Name = "menuStripVocabulary";
            this.menuStripVocabulary.Size = new System.Drawing.Size(806, 24);
            this.menuStripVocabulary.TabIndex = 4;
            this.menuStripVocabulary.Text = "menuStripVocabulary";
            // 
            // создатьToolStripMenuItem1
            // 
            this.создатьToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.page_with_one_curled_corner;
            this.создатьToolStripMenuItem1.Name = "создатьToolStripMenuItem1";
            this.создатьToolStripMenuItem1.Size = new System.Drawing.Size(78, 20);
            this.создатьToolStripMenuItem1.Text = "Создать";
            this.создатьToolStripMenuItem1.Click += new System.EventHandler(this.создатьToolStripMenuItem1_Click);
            // 
            // редактироватьToolStripMenuItem1
            // 
            this.редактироватьToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.gross_pencil;
            this.редактироватьToolStripMenuItem1.Name = "редактироватьToolStripMenuItem1";
            this.редактироватьToolStripMenuItem1.Size = new System.Drawing.Size(130, 20);
            this.редактироватьToolStripMenuItem1.Text = "Выбрать словарь";
            this.редактироватьToolStripMenuItem1.Click += new System.EventHandler(this.редактироватьToolStripMenuItem1_Click);
            // 
            // сохранитьСловарьtoolStripMenuItem1
            // 
            this.сохранитьСловарьtoolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьСловарьtoolStripMenuItem1.Image")));
            this.сохранитьСловарьtoolStripMenuItem1.Name = "сохранитьСловарьtoolStripMenuItem1";
            this.сохранитьСловарьtoolStripMenuItem1.Size = new System.Drawing.Size(141, 20);
            this.сохранитьСловарьtoolStripMenuItem1.Text = "Сохранить словарь";
            this.сохранитьСловарьtoolStripMenuItem1.Click += new System.EventHandler(this.сохранитьСловарьtoolStripMenuItem1_Click);
            // 
            // очиститьToolStripMenuItem1
            // 
            this.очиститьToolStripMenuItem1.Enabled = false;
            this.очиститьToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.big_trash_container_from_side_view;
            this.очиститьToolStripMenuItem1.Name = "очиститьToolStripMenuItem1";
            this.очиститьToolStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.очиститьToolStripMenuItem1.Text = "Очистить";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem1,
            this.оПрограммеToolStripMenuItem1,
            this.обАвторахToolStripMenuItem1});
            this.справкаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаToolStripMenuItem.Image")));
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // руководствоПользователяToolStripMenuItem1
            // 
            this.руководствоПользователяToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.create_list_button;
            this.руководствоПользователяToolStripMenuItem1.Name = "руководствоПользователяToolStripMenuItem1";
            this.руководствоПользователяToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem1.Text = "Руководство пользователя";
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.information_button;
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.оПрограммеToolStripMenuItem1.Text = "О программе";
            // 
            // обАвторахToolStripMenuItem1
            // 
            this.обАвторахToolStripMenuItem1.Image = global::ClassicCrossword.Properties.Resources.personal_avatar;
            this.обАвторахToolStripMenuItem1.Name = "обАвторахToolStripMenuItem1";
            this.обАвторахToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.обАвторахToolStripMenuItem1.Text = "Об авторах";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // tabPageAccounts
            // 
            this.tabPageAccounts.Controls.Add(this.groupBoxAccounts);
            this.tabPageAccounts.Controls.Add(this.menuStripAccount);
            this.tabPageAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccounts.Name = "tabPageAccounts";
            this.tabPageAccounts.Size = new System.Drawing.Size(812, 560);
            this.tabPageAccounts.TabIndex = 2;
            this.tabPageAccounts.Text = "Учетные записи";
            this.tabPageAccounts.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccounts
            // 
            this.groupBoxAccounts.Controls.Add(this.dataGridView1);
            this.groupBoxAccounts.Location = new System.Drawing.Point(3, 27);
            this.groupBoxAccounts.Name = "groupBoxAccounts";
            this.groupBoxAccounts.Size = new System.Drawing.Size(794, 528);
            this.groupBoxAccounts.TabIndex = 1;
            this.groupBoxAccounts.TabStop = false;
            this.groupBoxAccounts.Text = "Учетные записи";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.passDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.crosswordBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(788, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Логин";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passDataGridViewTextBoxColumn
            // 
            this.passDataGridViewTextBoxColumn.DataPropertyName = "pass";
            this.passDataGridViewTextBoxColumn.HeaderText = "Пароль";
            this.passDataGridViewTextBoxColumn.Name = "passDataGridViewTextBoxColumn";
            this.passDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // crosswordBindingSource
            // 
            this.crosswordBindingSource.DataMember = "Player";
            this.crosswordBindingSource.DataSource = this.crosswordDataSet;
            // 
            // crosswordDataSet
            // 
            this.crosswordDataSet.DataSetName = "CrosswordDataSet";
            this.crosswordDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStripAccount
            // 
            this.menuStripAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem2,
            this.удалитьToolStripMenuItem,
            this.просмотретьДанныеToolStripMenuItem,
            this.справкаToolStripMenuItem2,
            this.выходToolStripMenuItem2});
            this.menuStripAccount.Location = new System.Drawing.Point(0, 0);
            this.menuStripAccount.Name = "menuStripAccount";
            this.menuStripAccount.Size = new System.Drawing.Size(812, 24);
            this.menuStripAccount.TabIndex = 0;
            this.menuStripAccount.Text = "menuStrip2";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.page_with_one_curled_corner;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem2
            // 
            this.редактироватьToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.gross_pencil;
            this.редактироватьToolStripMenuItem2.Name = "редактироватьToolStripMenuItem2";
            this.редактироватьToolStripMenuItem2.Size = new System.Drawing.Size(115, 20);
            this.редактироватьToolStripMenuItem2.Text = "Редактировать";
            this.редактироватьToolStripMenuItem2.Click += new System.EventHandler(this.редактироватьToolStripMenuItem2_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.big_trash_container_from_side_view;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // просмотретьДанныеToolStripMenuItem
            // 
            this.просмотретьДанныеToolStripMenuItem.Enabled = false;
            this.просмотретьДанныеToolStripMenuItem.Image = global::ClassicCrossword.Properties.Resources.watch_dark_eye;
            this.просмотретьДанныеToolStripMenuItem.Name = "просмотретьДанныеToolStripMenuItem";
            this.просмотретьДанныеToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.просмотретьДанныеToolStripMenuItem.Text = "Просмотреть данные";
            this.просмотретьДанныеToolStripMenuItem.Click += new System.EventHandler(this.просмотретьДанныеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem2
            // 
            this.справкаToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem2,
            this.оПрограммеToolStripMenuItem2,
            this.обАвторахToolStripMenuItem2});
            this.справкаToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.question_button;
            this.справкаToolStripMenuItem2.Name = "справкаToolStripMenuItem2";
            this.справкаToolStripMenuItem2.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem2.Text = "Справка";
            // 
            // руководствоПользователяToolStripMenuItem2
            // 
            this.руководствоПользователяToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.create_list_button;
            this.руководствоПользователяToolStripMenuItem2.Name = "руководствоПользователяToolStripMenuItem2";
            this.руководствоПользователяToolStripMenuItem2.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem2.Text = "Руководство пользователя";
            // 
            // оПрограммеToolStripMenuItem2
            // 
            this.оПрограммеToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.information_button;
            this.оПрограммеToolStripMenuItem2.Name = "оПрограммеToolStripMenuItem2";
            this.оПрограммеToolStripMenuItem2.Size = new System.Drawing.Size(221, 22);
            this.оПрограммеToolStripMenuItem2.Text = "О программе";
            // 
            // обАвторахToolStripMenuItem2
            // 
            this.обАвторахToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.personal_avatar;
            this.обАвторахToolStripMenuItem2.Name = "обАвторахToolStripMenuItem2";
            this.обАвторахToolStripMenuItem2.Size = new System.Drawing.Size(221, 22);
            this.обАвторахToolStripMenuItem2.Text = "Об авторах";
            // 
            // выходToolStripMenuItem2
            // 
            this.выходToolStripMenuItem2.Image = global::ClassicCrossword.Properties.Resources.button_on_off;
            this.выходToolStripMenuItem2.Name = "выходToolStripMenuItem2";
            this.выходToolStripMenuItem2.Size = new System.Drawing.Size(69, 20);
            this.выходToolStripMenuItem2.Text = "Выход";
            // 
            // playerTableAdapter
            // 
            this.playerTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdminWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 601);
            this.Controls.Add(this.tabControlMenu);
            this.MaximizeBox = false;
            this.Name = "AdminWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EFM - ADMIN";
            this.Load += new System.EventHandler(this.AdminWindowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVocabularyOfC)).EndInit();
            this.groupBoxVocabularyOfC.ResumeLayout(false);
            this.groupBoxVocabularyOfC.PerformLayout();
            this.tabControlMenu.ResumeLayout(false);
            this.tabPageCrossword.ResumeLayout(false);
            this.tabPageCrossword.PerformLayout();
            this.groupBoxVocabularyInstruments.ResumeLayout(false);
            this.groupBoxVocabularyInstruments.PerformLayout();
            this.menuStripCrossword.ResumeLayout(false);
            this.menuStripCrossword.PerformLayout();
            this.tabPageVocabulary.ResumeLayout(false);
            this.tabPageVocabulary.PerformLayout();
            this.groupBoxVocabularyOfV.ResumeLayout(false);
            this.groupBoxVocabularyOfV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVocabularyOfV)).EndInit();
            this.menuStripVocabulary.ResumeLayout(false);
            this.menuStripVocabulary.PerformLayout();
            this.tabPageAccounts.ResumeLayout(false);
            this.tabPageAccounts.PerformLayout();
            this.groupBoxAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosswordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crosswordDataSet)).EndInit();
            this.menuStripAccount.ResumeLayout(false);
            this.menuStripAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelSearchByMask;
        private System.Windows.Forms.TextBox textBoxSearchByMask;
        private System.Windows.Forms.Button buttonSortByLength;
        private System.Windows.Forms.Button buttonSortByAlphabet;
        private System.Windows.Forms.DataGridView dataGridViewVocabularyOfC;
        private System.Windows.Forms.GroupBox groupBoxVocabularyOfC;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label labelVocabularyWordsCountOnC;
        private System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPageCrossword;
        private System.Windows.Forms.TabPage tabPageVocabulary;
        private System.Windows.Forms.TabPage tabPageAccounts;
        private System.Windows.Forms.Button buttonClearMask;
        private System.Windows.Forms.GroupBox groupBoxVocabularyInstruments;
        private System.Windows.Forms.MenuStrip menuStripCrossword;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьсловарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыКроссвордаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem печатьКроссвордаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьОтветовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обАвторахToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxVocabularyWordsCountOnC;
        private System.Windows.Forms.GroupBox groupBoxVocabularyOfV;
        private System.Windows.Forms.DataGridView dataGridViewVocabularyOfV;
        private System.Windows.Forms.MenuStrip menuStripVocabulary;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСловарьtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обАвторахToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxVocabularyWordsCountOnV;
        private System.Windows.Forms.Label labelabelVocabularyWordsCountOnV;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBoxAccounts;
        private System.Windows.Forms.MenuStrip menuStripAccount;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотретьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem обАвторахToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem2;
        private System.Windows.Forms.BindingSource crosswordBindingSource;
        private CrosswordDataSet crosswordDataSet;
        private CrosswordDataSetTableAdapters.PlayerTableAdapter playerTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcNot1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcNot2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcDef;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}