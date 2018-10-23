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
            int x = 0; //начальные координаты
            int y = 0;  //начальные координаты
            int deltaX = 20; //шаг по x
            int deltaY = 20; //шаг по y

            GridArray = new TextBox[gridRow, gridColumn];
            for (int i = 0; i < gridRow; i++)
            {
                x = 0;
                for (int j = 0; j < gridColumn; j++)
                {
                    GridArray[i, j] = new TextBox(); //инициализируем сетку
                    panel.Controls.Add(GridArray[i, j]); // добавляем сетку на панель
                    GridArray[i, j].SetBounds(x, y, deltaX, deltaY); //задание границ
                    GridArray[i, j].Enabled = false; //нельзя редактировать сетку
                    x += deltaX; //увеличиваем шаг по х
                }
                y += deltaY; //увеличиваем шаг по y
            }
        }
    }
}
