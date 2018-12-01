using ClassicCrossword.Controller;
using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword.Forms
{
    public partial class AuthForm : Form
    {
        private UserController usrController;
        public User Usr { get; private set; }

        public AuthForm()
        {
            InitializeComponent();
            this.ActiveControl = tbLogin;
            usrController = new UserController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isEmpty = false;
            if (tbLogin.Text.Equals("Логин") || tbLogin.Text.Trim().Equals(""))
            {
                isEmpty = true;
                tbPassword.Text = "Пароль";
            }
            if (tbPassword.Text.Equals("Пароль") || tbPassword.Text.Trim().Equals(""))
            {
                isEmpty = true;
            }
            if (isEmpty)
            {
                MessageBox.Show("Заполните пустые поля!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isEmpty = false;
                tbPassword.Text = "Пароль";
                tbPassword.ForeColor = Color.Gray;
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                if (tbLogin.Text.Trim().Equals("_"))
                {
                    MessageBox.Show("Неверный логин!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPassword.Text = "Пароль";
                    tbPassword.ForeColor = Color.Gray;
                    tbPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    try
                    {
                        Usr = usrController.GetUserByAuthorization(tbLogin.Text.Trim(), tbPassword.Text.Trim());
                        if (Usr == null)
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbPassword.Text = "Пароль";
                            tbPassword.ForeColor = Color.Gray;
                            tbPassword.UseSystemPasswordChar = false;
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            this.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка работы с базой данных!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.ShowDialog();
        }
    }
}
