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
        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        Crossword _board = new Crossword(n, m);

        public UserWindowForm()
        {
            InitializeComponent();
        }

        private void новыйКроссвордToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".crs";
            openFileDialog1.InitialDirectory = @"..\..\Crosswords\";
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл кроссворда (*.crs)|*.crs";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                clearDGV(dgvCrossword);

                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    _board = (Crossword)formatter.Deserialize(fs);
                }

                for (var i = 0; i < _board.N + 2; i++)
                {
                    for (var j = 0; j < _board.M + 2; j++)
                    {
                        dgvCrossword.Rows[i].Cells[j].Value = " ";
                        dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                        dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }

                Actualize();
            }
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

        void clearDGV(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = " ";
                }
            }
        }

        private void UserWindowForm_Load(object sender, EventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
            dgvCrossword.Font = font;

            int k;
            for (int i = 0; i < m + 2; i++)
            {
                k = dgvCrossword.Columns.Add(i.ToString(), i.ToString());
                dgvCrossword.Columns[k].Width = 25;
            }

            for (int i = 0; i < n + 2; i++)
            {
                k = dgvCrossword.Rows.Add();
                dgvCrossword.Rows[k].Height = 25;
            }

            for (var i = 0; i < n + 2; i++)
            {
                for (var j = 0; j < m + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Value = " ";
                    dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }

        private void решатьКроссвордToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
