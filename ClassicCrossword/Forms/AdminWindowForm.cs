using ClassicCrossword.Controller;
using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword
{
    public partial class AdminWindowForm : Form
    {

        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        //private Dictionary<string, string> dict = new Dictionary<string, string>();
        //private List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

        private List<string> listNot = new List<string>();
        private List<string> listDef = new List<string>();

        List<string> notUsedList;
        List<string> tmpList;

        Crossword _board = new Crossword(n, m);


        public AdminWindowForm()
        {
            InitializeComponent();
        }

        private void редактироватьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string login = (string)dataGridView1.CurrentRow.Cells[1].Value;
            string pass = (string)dataGridView1.CurrentRow.Cells[2].Value;
            var editPlayerForm = new AddNewPlayerForm(id, login, pass);
            editPlayerForm.Closing += AddNewPlayerForm_Closing;
            editPlayerForm.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранный вид устройств?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                try
                {
                    new UserController().DeleteById(id);
                    playerTableAdapter.Fill(crosswordDataSet.Player);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Невозможно удалить выбранный вид устройств! Имеются устройства данного вида.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка работы с базой данных!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void просмотретьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addTypeOfDevicesForm = new AddNewPlayerForm();
            addTypeOfDevicesForm.Closing += AddNewPlayerForm_Closing;
            addTypeOfDevicesForm.ShowDialog();
        }

        private void AddNewPlayerForm_Closing(object sender, CancelEventArgs e)
        {
            playerTableAdapter.Fill(crosswordDataSet.Player);
        }

        private void AdminWindowForm_Load(object sender, EventArgs e)
        {
            playerTableAdapter.Fill(crosswordDataSet.Player);
            idDataGridViewTextBoxColumn.Visible = false;

            Grid.Create(mainPanel, n+2, m+2); // создание сетки заданной размерности

            parseDict("Glavny.dict");
            //list.AddRange(dict);

            int i = 0;
            foreach (var item in listNot)
            {
                dataGridViewVocabularyOfC.Rows.Add(item);
                dataGridViewVocabularyOfV.Rows.Add();
                dataGridViewVocabularyOfV.Rows[i].Cells["dgvtbcNot2"].Value = item;
                i++;
            }
            i = 0;
            foreach (var item in listDef)
            {
                dataGridViewVocabularyOfV.Rows[i].Cells["dgvtbcDef"].Value = item;
                i++;
            }
        }

        static int Comparer(string a, string b)
        {
            var temp = a.Length.CompareTo(b.Length);
            return temp == 0 ? a.CompareTo(b) : temp;
        }

        private void parseDict(string filename)
        {
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("windows-1251")).Take(10).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Split(' ')[0];
                string question = words[i].Substring(words[i].IndexOf(' '));
                listNot.Add(word);
                listDef.Add(question);
                //dict.Add(word, question);
            }
        }

        private void выбратьсловарьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            listNot.Sort(Comparer);
            listNot.Reverse();
            _board.Temp = listNot;
            GenerateCrossword();
        }

        void GenerateCrossword()
        {
            _board.Reset();
            Grid.ClearBoard(mainPanel, n+2, m+2);

            notUsedList = new List<string>();
            tmpList = new List<string>();
            GenCrossword(listNot, listNot.Count);
            Actualize();
        }

        void GenCrossword(List<string> list, int cnt)
        {
            tmpList.Clear();
            foreach (var word in list)
            {
                switch (_board.AddWord(word))
                {
                    case 0:
                        if (notUsedList.Contains(word))
                            tmpList.Add(word);
                        break;
                    case 1:
                        if (notUsedList.Contains(word))
                            tmpList.Add(word);
                        break;
                    default:
                        if (!notUsedList.Contains(word))
                            notUsedList.Add(word);
                        break;
                }
            }
            foreach (var word in tmpList)
            {
                notUsedList.Remove(word);
            }
            if (notUsedList.Count == 0 || notUsedList.Count == cnt)
                return;
            else
                GenCrossword(notUsedList, notUsedList.Count);
        }

        //заполнение сетки на форме символами для кроссворда
        void Actualize()
        {
            var count = _board.N * _board.M;
            var board = _board.GetBoard;
            var p = 0;
            for (var i = 0; i < _board.N; i++)
            {
                for (var j = 0; j < _board.M; j++)
                {
                    var letter = board[i, j] == '*' ? ' ' : board[i, j];
                    if (letter != ' ') count--;
                    if (letter != ' ')
                    {
                        Grid.tbArray[i + 1, j + 1].Text = letter.ToString();
                        Grid.tbArray[i + 1, j + 1].Enabled = true;
                    }
                    p++;
                }
            }
            Numeration();
        }

        //расстановка нумерации кроссворда и вопросов    
        void Numeration()
        {
            int point = 1;
            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < m + 1; j++)
                {
                    if (Grid.tbArray[i - 1, j].Text == "" && Grid.tbArray[i, j].Text != "" && Grid.tbArray[i + 1, j].Text != "")
                    {
                        Grid.tbArray[i - 1, j].Text = point.ToString();
                        //QuestionList.Items.Add(point.ToString() + ")");
                        point++;
                    }
                    if (Grid.tbArray[i, j - 1].Text == "" && Grid.tbArray[i, j].Text != "" && Grid.tbArray[i, j + 1].Text != "")
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
