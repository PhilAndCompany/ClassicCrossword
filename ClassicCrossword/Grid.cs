using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword
{
    class Grid
    {
        //Инициализация двумерного массива textBox'ов
        public static TextBox[,] GridArray;
        //Создание поля кроссворда на основе массива textBox'ов отрисовываемых на выбранной панели
        public static void Create(Panel panel, int gridRow, int gridColumn)
        {
            int minW = 0; //локальные переменные для мин. ширины
            int minH = 0;  //локальные переменные для мин. высоты
            int maxW = 20; //локальные переменные для макс. ширины
            int maxH = 20; //локальные переменные для макс. высоты

            GridArray = new TextBox[gridRow, gridColumn];
            for (int i = 0; i < gridRow; i++)
            {
                minW = 0;
                for (int j = 0; j < gridColumn; j++)
                {
                    GridArray[i, j] = new TextBox(); //инициализируем сетку
                    panel.Controls.Add(GridArray[i, j]); // добавляем сетку на панель
                    GridArray[i, j].SetBounds(minW, minH, maxW, maxH); //задание границ
                    GridArray[i, j].Enabled = false; //нельзя редактировать сетку
                    minW += maxW; //увеличение в ширину
                }
                minH += maxH; //увеличение в высоту
            }
        }
    }
}
