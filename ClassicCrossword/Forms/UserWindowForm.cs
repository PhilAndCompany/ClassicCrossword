using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassicCrossword.Forms
{
    public partial class UserWindowForm : Form
    {
        Crossword _board;

        public UserWindowForm()
        {
            InitializeComponent();
        }

        private void новыйКроссвордToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream fs = new FileStream(@"..\..\Crosswords\def.crs", FileMode.OpenOrCreate))
            {
                _board = (Crossword)formatter.Deserialize(fs);
            }

            Grid.Create(mainPanel, _board.N + 2, _board.M + 2);

            Actualize();
        }

        //заполнение сетки на форме символами для кроссворда
        void Actualize()
        {
            var count = _board.N * _board.M;
            var board = _board.GetBoard;
            char[,] tmpBoard = new char[_board.N+2, _board.M+2];
            for (int i = 0; i < _board.N; i++)
            {
                for (int j = 0; j < _board.M; j++)
                {
                    var letter = board[i, j] == '*' ? ' ' : board[i, j];
                    tmpBoard[i + 1, j + 1] = letter;
                }
            }
            var p = 0;
            for (var i = 0; i < _board.N; i++)
            {
                for (var j = 0; j < _board.M; j++)
                {
                    var letter = board[i, j] == '*' ? ' ' : board[i, j];
                    if (letter != ' ') count--;
                    if (letter != ' ')
                    {
                        Grid.tbArray[i + 1, j + 1].Text = "";
                        Grid.tbArray[i + 1, j + 1].Enabled = true;
                    }
                    p++;
                }
            }
            Numeration(tmpBoard);
        }

        //расстановка нумерации кроссворда и вопросов    
        void Numeration(char[,] tmp)
        {
            int point = 1;
            var board = _board.GetBoard;
            for (var i = 1; i < _board.N + 1; i++)
            {
                for (var j = 1; j < _board.M + 1; j++)
                {
                    if (tmp[i - 1, j] == ' ' && tmp[i, j] != ' ' && tmp[i + 1, j] != ' ')
                    {
                        Grid.tbArray[i - 1, j].Text = point.ToString();
                        //QuestionList.Items.Add(point.ToString() + ")");
                        point++;
                    }
                    if (tmp[i, j - 1] == ' ' && tmp[i, j] != ' ' && tmp[i, j + 1] != ' ')
                    {
                        Grid.tbArray[i, j - 1].Text = point.ToString();
                        //QuestionList.Items.Add(point.ToString() + ")");
                        point++;
                    }
                }
            }
        }
    }
}
