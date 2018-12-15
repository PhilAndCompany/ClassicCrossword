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
            dgvCrossword.Font = font;

            int k;
            for (int i = 0; i < _board.M + 2; i++)
            {
                k = dgvCrossword.Columns.Add(i.ToString(), i.ToString());
                dgvCrossword.Columns[k].Width = 25;
            }

            for (int i = 0; i < _board.N + 2; i++)
            {
                k = dgvCrossword.Rows.Add();
                dgvCrossword.Rows[k].Height = 25;
            }

            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Value = " ";
                    dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                }
            }

            Actualize();
        }

        //заполнение сетки на форме символами для кроссворда
        void Actualize()
        {
            var count = _board.N * _board.M;
            var board = _board.GetBoard;

            string[,] tmpBoard = new string[_board.N+2, _board.M+2];
            for (int i = 0; i < _board.N + 2; i++)
                for (int j = 0; j < _board.M + 2; j++)
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
                        dgvCrossword.Rows[i + 1].Cells[j + 1].Value = "";
                        dgvCrossword.Rows[i + 1].Cells[j + 1].ReadOnly = false;
                        dgvCrossword.Rows[i + 1].Cells[j + 1].Style.BackColor = Color.White;
                        tmpBoard[i + 1, j + 1] = letter.ToString();
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
                        dgvCrossword.Rows[i - 1].Cells[j].Value = point.ToString();
                        dgvCrossword.Rows[i-1].Cells[j].Style.ForeColor = Color.White;
                        point++;
                    }
                    if (tmp[i, j - 1].Equals(" ") && !tmp[i, j].Equals(" ") && !tmp[i, j + 1].Equals(" "))
                    {
                        dgvCrossword.Rows[i].Cells[j - 1].Value = point.ToString();
                        dgvCrossword.Rows[i].Cells[j-1].Style.ForeColor = Color.White;
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
