using System.Drawing;
using System.Windows.Forms;

namespace ClassicCrossword.Model
{
    class Grid
    {
        //инициализация двумерного массива textBox'ов
        public static TextBox[,] tbArray;
        //Создание поля кроссворда на основе массива textBox'ов отрисовываемых на выбранной панели
        public static void Create(Panel panel, int count1, int count2)
        {
            int x = 0;
            int y = 0;
            int bh = 20;
            int bw = 20;

            tbArray = new TextBox[count1, count2];
            
            for (int i = 0; i < count1; i++)
            {
                x = 0;
                for (int j = 0; j < count2; j++)
                {
                    tbArray[i, j] = new TextBox();
                    tbArray[i, j].Name = "TextBox" + j;
                    panel.Controls.Add(tbArray[i, j]);
                    tbArray[i, j].SetBounds(x, y, bw, bh);
                    tbArray[i, j].Height = 20;
                    tbArray[i, j].Width = 20;
                    tbArray[i, j].MaxLength = 1;
                    //       tbArray[i, j].KeyPress += txt_KeyPress;
                    tbArray[i, j].Enabled = false;
                    tbArray[i, j].TextAlign = HorizontalAlignment.Center;
                    x += bw;
                    //шрифт для поля кроссворда
                    Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
                    tbArray[i, j].Font = font;
                }
                y += 20;
            }

            //ограничение ввода в ячейку только кирилицы и <-- 
            //хотя основа программы подразумевает возможность пользования латиницы
            //void txt_KeyPress(object sender, KeyPressEventArgs e)
            //{
            //    char l = e.KeyChar;
            //    if ((l < 'а' || l > 'я') && l != '\b')
            //        e.Handled = true;
            //}
        }

        //очищение поля кроссворда на форме
        public static void ClearBoard(Panel panel, int count1, int count2)
        {
            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    tbArray[i, j].Text = "";
                    tbArray[i, j].Enabled = false;
                }
            }
        }

        //выключает не задействованные после генерации клетки поля кроссворда
        public static void ClearNotUsed(int count1, int count2)
        {
            for (var i = 0; i < count1; i++)
                for (var j = 0; j < count2; j++) 
                    if (tbArray[i, j].Text == "")
                        tbArray[i, j].Enabled = false;
        }

        public static void KillTB(int count1, int count2)
        {
            for (var i = 0; i < count1; i++)
                for (var j = 0; j < count2; j++) 
                    tbArray[i, j].Dispose();
        }
    }
}
