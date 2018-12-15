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

            Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
            dataGridView2.Font = font;

            int k;
            for (int i = 0; i < _board.M + 2; i++)
            {
                k = dataGridView2.Columns.Add(i.ToString(), i.ToString());
                dataGridView2.Columns[k].Width = 25;
            }

            for (int i = 0; i < _board.N + 2; i++)
            {
                k = dataGridView2.Rows.Add();
                dataGridView2.Rows[k].Height = 25;
            }

            for (var i = 0; i < _board.N + 2; i++)
                for (var j = 0; j < _board.M + 2; j++)
                    dataGridView2.Rows[i].Cells[j].Value = " ";

            Actualize();
        }

        //заполнение сетки на форме символами для кроссворда
        void Actualize()
        {
            var count = _board.N * _board.M;
            var board = _board.GetBoard;

            string[,] tmpBoard = new string[_board.N+2, _board.M+2];
            for (int i = 0; i < _board.N+2; i++)
                for (int j = 0; j < _board.M+2; j++)
                    tmpBoard[i, j] = " ";

            var p = 0;
            for (var i = 0; i < _board.N; i++)
            {
                for (var j = 0; j < _board.M; j++)
                {
                    var letter = board[i, j] == '*' ? ' ' : board[i, j];
                    if (letter != ' ') count--;
                    if (letter != ' ')
                    {
                        dataGridView2.Rows[i + 1].Cells[j + 1].Value = "_";
                        tmpBoard[i + 1, j + 1] = letter.ToString();
                    }
                    else
                    {
                        tmpBoard[i + 1, j + 1] = " ";
                    }
                    p++;
                }
            }
            Numeration(tmpBoard);
        }

        //расстановка нумерации кроссворда и вопросов    
        void Numeration(string[,] tmp)
        {
            int point = 1;
            var board = _board.GetBoard;
            for (var i = 1; i < _board.N + 1; i++)
            {
                for (var j = 1; j < _board.M + 1; j++)
                {
                    if (tmp[i - 1, j].Equals(" ") && !tmp[i, j].Equals(" ") && !tmp[i + 1, j].Equals(" "))
                    {
                        dataGridView2.Rows[i - 1].Cells[j].Value = point.ToString();
                        point++;
                    }
                    if (tmp[i, j - 1].Equals(" ") && !tmp[i, j].Equals(" ") && !tmp[i, j + 1].Equals(" "))
                    {
                        dataGridView2.Rows[i].Cells[j - 1].Value = point.ToString();
                        point++;
                    }
                }
            }
        }

        private void UserWindowForm_Load(object sender, EventArgs e)
        {

        }
    }
}
