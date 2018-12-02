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

namespace ClassicCrossword
{
    public partial class AddNewPlayerForm : Form
    {
        UserController usrController;
        Player player;
        public AddNewPlayerForm()
        {
            InitializeComponent();
            this.ActiveControl = tbLogin;
            usrController = new UserController();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text.Trim().Equals("") || tbPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Заполните пустые поля!", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    player = new Player(tbLogin.Text.Trim(), tbPassword.Text.Trim());
                    usrController.Insert(player);
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно добавить нового сотрудника!\nСотрудник с такими данными уже существует.", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка работы с базой данных!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
