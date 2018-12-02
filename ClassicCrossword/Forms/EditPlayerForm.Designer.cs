namespace ClassicCrossword
{
    partial class EditPlayerForm
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
            this.labelChangeAccount = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labeNewlPassword = new System.Windows.Forms.Label();
            this.labelNewLogin = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelChangeAccount
            // 
            this.labelChangeAccount.AutoSize = true;
            this.labelChangeAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChangeAccount.Location = new System.Drawing.Point(22, 9);
            this.labelChangeAccount.Name = "labelChangeAccount";
            this.labelChangeAccount.Size = new System.Drawing.Size(396, 29);
            this.labelChangeAccount.TabIndex = 39;
            this.labelChangeAccount.Text = "РЕДАКТИРОВАТЬ УЧ. ЗАПИСЬ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(243, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 33;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(125, 215);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // labeNewlPassword
            // 
            this.labeNewlPassword.AutoSize = true;
            this.labeNewlPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeNewlPassword.Location = new System.Drawing.Point(39, 131);
            this.labeNewlPassword.Name = "labeNewlPassword";
            this.labeNewlPassword.Size = new System.Drawing.Size(201, 31);
            this.labeNewlPassword.TabIndex = 35;
            this.labeNewlPassword.Text = "Новый пароль:";
            this.labeNewlPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNewLogin
            // 
            this.labelNewLogin.AutoSize = true;
            this.labelNewLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNewLogin.Location = new System.Drawing.Point(58, 86);
            this.labelNewLogin.Name = "labelNewLogin";
            this.labelNewLogin.Size = new System.Drawing.Size(182, 31);
            this.labelNewLogin.TabIndex = 36;
            this.labelNewLogin.Text = "Новый логин:";
            this.labelNewLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(246, 142);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(146, 20);
            this.textBoxNewPassword.TabIndex = 38;
            // 
            // textBoxNewLogin
            // 
            this.textBoxNewLogin.Location = new System.Drawing.Point(246, 97);
            this.textBoxNewLogin.Name = "textBoxNewLogin";
            this.textBoxNewLogin.Size = new System.Drawing.Size(146, 20);
            this.textBoxNewLogin.TabIndex = 37;
            // 
            // EditPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.labelChangeAccount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labeNewlPassword);
            this.Controls.Add(this.labelNewLogin);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxNewLogin);
            this.Name = "EditPlayerForm";
            this.Text = "EFM - РЕДАКТИРОВАТЬ УЧ. ЗАПИСЬ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChangeAccount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labeNewlPassword;
        private System.Windows.Forms.Label labelNewLogin;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxNewLogin;
    }
}