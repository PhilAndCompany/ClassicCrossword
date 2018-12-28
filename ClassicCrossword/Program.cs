using ClassicCrossword.Forms;
using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword
{
    static class Program
    {
        public static AdminWindowForm adminForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var authForm = new AuthForm();
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    if (authForm.Usr.GetType() == typeof(Admin))
                        Application.Run(adminForm = new AdminWindowForm());
                    else
                        Application.Run(new PlayerWindowForm((Player)authForm.Usr));

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка в работе системы!", "Ошибка в работе", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
