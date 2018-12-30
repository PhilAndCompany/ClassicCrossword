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
        private int id;
        private string origLog;
        private string origPass;
        UserController usrController;

        public AddNewPlayerForm()
        {
            InitializeComponent();
            this.ActiveControl = tbLogin;
            usrController = new UserController();
        }

        public AddNewPlayerForm(int id, string login, string pass)
        {
            InitializeComponent(login, pass);
            this.id = id;
            tbLogin.Text = login;
            tbPassword.Text = pass;
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
                    if (id == 0)
                    {
                        try
                        {
                            playerTableAdapter.Insert(tbLogin.Text, tbPassword.Text);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно добавить нового игрока!\nИгрок с таким логином уже существует.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            playerTableAdapter.Update(tbLogin.Text, tbPassword.Text, id, origLog, origPass);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно добавить нового игрока!\nИгрок с таким логином уже существует.", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно добавить нового игрока!\nИгрок с таким логином уже существует.", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка работы с базой данных!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddNewPlayerForm_Load(object sender, EventArgs e)
        {
            playerTableAdapter.Fill(crosswordDataSet.Player);
            origLog = tbLogin.Text;
            origPass = tbPassword.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
