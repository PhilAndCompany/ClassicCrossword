namespace ClassicCrossword
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
            this.GridPanel = new System.Windows.Forms.Panel();
            this.wordsListView = new System.Windows.Forms.ListView();
            this.questionsListView = new System.Windows.Forms.ListView();
            this.wordsTextBox = new System.Windows.Forms.TextBox();
            this.questionsTextBox = new System.Windows.Forms.TextBox();
            this.addwordButton = new System.Windows.Forms.Button();
            this.deletewordButton = new System.Windows.Forms.Button();
            this.addquestionButton = new System.Windows.Forms.Button();
            this.deletequestionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.Location = new System.Drawing.Point(22, 31);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(467, 438);
            this.GridPanel.TabIndex = 0;
            // 
            // wordsListView
            // 
            this.wordsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.wordsListView.Location = new System.Drawing.Point(495, 31);
            this.wordsListView.Name = "wordsListView";
            this.wordsListView.Size = new System.Drawing.Size(110, 352);
            this.wordsListView.TabIndex = 1;
            this.wordsListView.UseCompatibleStateImageBehavior = false;
            this.wordsListView.View = System.Windows.Forms.View.Tile;
            // 
            // questionsListView
            // 
            this.questionsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.questionsListView.Location = new System.Drawing.Point(649, 31);
            this.questionsListView.Name = "questionsListView";
            this.questionsListView.Size = new System.Drawing.Size(336, 351);
            this.questionsListView.TabIndex = 2;
            this.questionsListView.UseCompatibleStateImageBehavior = false;
            this.questionsListView.View = System.Windows.Forms.View.Tile;
            // 
            // wordsTextBox
            // 
            this.wordsTextBox.Location = new System.Drawing.Point(495, 389);
            this.wordsTextBox.Name = "wordsTextBox";
            this.wordsTextBox.Size = new System.Drawing.Size(126, 20);
            this.wordsTextBox.TabIndex = 3;
            // 
            // questionsTextBox
            // 
            this.questionsTextBox.Location = new System.Drawing.Point(650, 388);
            this.questionsTextBox.Name = "questionsTextBox";
            this.questionsTextBox.Size = new System.Drawing.Size(335, 20);
            this.questionsTextBox.TabIndex = 4;
            // 
            // addwordButton
            // 
            this.addwordButton.Location = new System.Drawing.Point(494, 415);
            this.addwordButton.Name = "addwordButton";
            this.addwordButton.Size = new System.Drawing.Size(127, 23);
            this.addwordButton.TabIndex = 5;
            this.addwordButton.Text = "Добавить слово";
            this.addwordButton.UseVisualStyleBackColor = true;
            this.addwordButton.Click += new System.EventHandler(this.addwordButton_Click);
            // 
            // deletewordButton
            // 
            this.deletewordButton.Location = new System.Drawing.Point(495, 445);
            this.deletewordButton.Name = "deletewordButton";
            this.deletewordButton.Size = new System.Drawing.Size(126, 23);
            this.deletewordButton.TabIndex = 6;
            this.deletewordButton.Text = "Удалить слово";
            this.deletewordButton.UseVisualStyleBackColor = true;
            this.deletewordButton.Click += new System.EventHandler(this.deletewordButton_Click);
            // 
            // addquestionButton
            // 
            this.addquestionButton.Location = new System.Drawing.Point(649, 414);
            this.addquestionButton.Name = "addquestionButton";
            this.addquestionButton.Size = new System.Drawing.Size(145, 23);
            this.addquestionButton.TabIndex = 7;
            this.addquestionButton.Text = "Добавить вопрос";
            this.addquestionButton.UseVisualStyleBackColor = true;
            this.addquestionButton.Click += new System.EventHandler(this.addquestionButton_Click);
            // 
            // deletequestionButton
            // 
            this.deletequestionButton.Location = new System.Drawing.Point(649, 445);
            this.deletequestionButton.Name = "deletequestionButton";
            this.deletequestionButton.Size = new System.Drawing.Size(145, 23);
            this.deletequestionButton.TabIndex = 8;
            this.deletequestionButton.Text = "Удалить вопрос";
            this.deletequestionButton.UseVisualStyleBackColor = true;
            this.deletequestionButton.Click += new System.EventHandler(this.deletequestionButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 502);
            this.Controls.Add(this.deletequestionButton);
            this.Controls.Add(this.addquestionButton);
            this.Controls.Add(this.deletewordButton);
            this.Controls.Add(this.addwordButton);
            this.Controls.Add(this.questionsTextBox);
            this.Controls.Add(this.wordsTextBox);
            this.Controls.Add(this.questionsListView);
            this.Controls.Add(this.wordsListView);
            this.Controls.Add(this.GridPanel);
            this.Name = "MainForm";
            this.Text = "ClassicCrossword";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.ListView wordsListView;
        private System.Windows.Forms.ListView questionsListView;
        private System.Windows.Forms.TextBox wordsTextBox;
        private System.Windows.Forms.TextBox questionsTextBox;
        private System.Windows.Forms.Button addwordButton;
        private System.Windows.Forms.Button deletewordButton;
        private System.Windows.Forms.Button addquestionButton;
        private System.Windows.Forms.Button deletequestionButton;
    }
}

