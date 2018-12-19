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
    public partial class PlayerWindowForm : Form
    {
        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        Crossword _board = new Crossword(n, m);

        public PlayerWindowForm()
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
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                foreach (var item in _board.defHorDict)
                    dataGridView1.Rows.Add(item.Value.ToString());

                foreach (var item in _board.defVerDict)
                    dataGridView2.Rows.Add(item.Value.ToString());

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
                        //dgvCrossword.Rows[i + 1].Cells[j + 1].ReadOnly = false;
                        dgvCrossword.Rows[i + 1].Cells[j + 1].Style.BackColor = Color.White;
                        tmpBoard[i + 1, j + 1] = letter.ToString();
                    }
                    p++;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                    if (dgvCrossword.Rows[i].Cells[j].Style.BackColor == Color.Orange)
                        dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            string def = dataGridView1.SelectedCells[0].Value.ToString();
            string not = GetKeyByValueFromHor(def);
            string notInStringFromMatrix = "";
            int x = 0;
            int y = 0;
            var board = _board.GetBoard;
            
            for (int i = 0; i < _board.N; i++)
            {
                for (int j = 0; j < _board.M; j++)
                {
                    notInStringFromMatrix += board[i, j];
                }
                x = i;
                y = notInStringFromMatrix.IndexOf(not);
                if (y != -1)
                    break;
                else notInStringFromMatrix = "";
            }
            for (int j = y; j < y + not.Length; j++)
            {
                dgvCrossword.Rows[x+1].Cells[j+1].ReadOnly = false;
                dgvCrossword.Rows[x+1].Cells[j+1].Style.BackColor = Color.Orange;
            }
            

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                    if (dgvCrossword.Rows[i].Cells[j].Style.BackColor == Color.Orange)
                        dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            string def = dataGridView2.SelectedCells[0].Value.ToString();
            string not = GetKeyByValueFromVer(def);
            string notInStringFromMatrix = "";
            int x = 0;
            int y = 0;
            var board = _board.GetBoard;

            for (int j = 0; j < _board.M; j++)
            {
                for (int i = 0; i < _board.N; i++)
                {
                    notInStringFromMatrix += board[i, j];
                }
                y = j;
                x = notInStringFromMatrix.IndexOf(not);
                if (x != -1)
                    break;
                else notInStringFromMatrix = "";
            }
            for (int i = x; i < x + not.Length; i++)
            {
                dgvCrossword.Rows[i + 1].Cells[y + 1].ReadOnly = false;
                dgvCrossword.Rows[i + 1].Cells[y + 1].Style.BackColor = Color.Orange;
            }
        }

        string GetKeyByValueFromHor(string value)
        {
            foreach (var recordOfDictionary in _board.defHorDict)
            {
                if (recordOfDictionary.Value.Equals(value))
                    return recordOfDictionary.Key;
            }
            return null;
        }
        string GetKeyByValueFromVer(string value)
        {
            foreach (var recordOfDictionary in _board.defVerDict)
            {
                if (recordOfDictionary.Value.Equals(value))
                    return recordOfDictionary.Key;
            }
            return null;
        }

        private void dgvCrossword_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.MaxLength = 1;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) || !Char.IsControl(e.KeyChar))
                e.Handled = false;
        }

        private void dgvCrossword_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvCrossword.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCrossword.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
        }
    }
}
