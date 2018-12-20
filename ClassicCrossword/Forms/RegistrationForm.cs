using ClassicCrossword.Controller;
using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword.Forms
{
    public partial class RegistrationForm : Form
    {
        UserController usrController;
        Player player;
        public RegistrationForm()
        {
            InitializeComponent();
            this.ActiveControl = tbLogin;
            usrController = new UserController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text.Trim().Equals("") || tbPassword1.Text.Trim().Equals("") || tbPassword2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Заполните пустые поля!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!tbPassword1.Text.Trim().Equals(tbPassword2.Text.Trim()))
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    player = new Player(tbLogin.Text.Trim(), tbPassword1.Text.Trim());
                    usrController.Insert(player);
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно зарегистрировать нового игрока!\nИгрок с таким логином уже существует.", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка работы с базой данных!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
