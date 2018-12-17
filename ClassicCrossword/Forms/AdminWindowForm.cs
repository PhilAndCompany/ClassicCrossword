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
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace ClassicCrossword
{
    public partial class AdminWindowForm : Form
    {

        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

        private List<string> listNot;
        private List<string> listDef;

        List<string> notUsedList;
        List<string> tmpList;

        private int dir;
        private int colInd;
        private int rowInd;

        private string mask = "";

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
            if (MessageBox.Show("Вы действительно хотите удалить выбранного игрока?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                try
                {
                    new UserController().DeleteById(id);
                    playerTableAdapter.Fill(crosswordDataSet.Player);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Невозможно удалить выбранного игрока! Такой игрок уже есть.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
            dgvCrossword.Font = font;

            int k;
            for (int i = 0; i < m+2; i++)
            {
                k = dgvCrossword.Columns.Add(i.ToString(), i.ToString());
                dgvCrossword.Columns[k].Width = 25;
            }

            for (int i = 0; i < n + 2; i++) {
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

            parseDict(@"..\..\Dict\Glavny.dict");
            list.AddRange(dict);

            listNot = dict.Keys.ToList();
            listDef = dict.Values.ToList();

            foreach (var item in list)
            {
                dataGridViewVocabularyOfC.Rows.Add(item.Key);
                dataGridViewVocabularyOfV.Rows.Add(item.Key, item.Value);
            }
        }

        private void parseDict(string filename)
        {
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("windows-1251")).Take(500).ToArray();
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word = words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string question = words[i].Substring(words[i].IndexOf(' ') + 1); //TODO убрать костыль
                try
                {
                    dict.Add(word, question);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("В словаре имеются одинаковые понятия");
                    return;
                }
            }
            int cntWords = words.Length - 1;
            textBoxVocabularyWordsCountOnV.Text = cntWords.ToString();
        }

        private void выбратьсловарьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            openFileDialog1.InitialDirectory = @"..\..\Dict\";
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dict.Clear();
                list.Clear();
                listNot.Clear();
                listDef.Clear();
                dataGridViewVocabularyOfC.Rows.Clear();

                parseDict(openFileDialog1.FileName);
                list.AddRange(dict);

                listNot = dict.Keys.ToList();
                listDef = dict.Values.ToList();

                foreach (var item in list)
                    dataGridViewVocabularyOfC.Rows.Add(item.Key);
            }
        }

        static int Comparer(string a, string b)
        {
            var temp = a.Length.CompareTo(b.Length);
            return temp == 0 ? a.CompareTo(b) : temp;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            listNot.Sort(Comparer);
            listNot.Reverse();
            _board.Temp = listNot;
            GenerateCrossword();
        }

        void GenerateCrossword()
        {
            _board.Reset();

            clearDGV(dgvCrossword);

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
                        dgvCrossword.Rows[i + 1].Cells[j + 1].Value = letter.ToString();
                        dgvCrossword.Rows[i + 1].Cells[j + 1].Style.BackColor = Color.White;
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
            for (var i = 1; i < _board.N + 1; i++)
            {
                for (var j = 1; j < _board.M + 1; j++)
                {
                    if (dgvCrossword.Rows[i-1].Cells[j].Value.ToString().Equals(" ") && !dgvCrossword.Rows[i].Cells[j].Value.ToString().Equals(" ") && !dgvCrossword.Rows[i+1].Cells[j].Value.ToString().Equals(" "))
                    {
                        dgvCrossword.Rows[i-1].Cells[j].Value = point.ToString();
                        dgvCrossword.Rows[i - 1].Cells[j].Style.ForeColor = Color.White;
                        point++;
                    }
                    if (dgvCrossword.Rows[i].Cells[j-1].Value.ToString().Equals(" ") && !dgvCrossword.Rows[i].Cells[j].Value.ToString().Equals(" ") && !dgvCrossword.Rows[i].Cells[j+1].Value.ToString().Equals(" "))
                    {
                        dgvCrossword.Rows[i].Cells[j-1].Value = point.ToString();
                        dgvCrossword.Rows[i].Cells[j - 1].Style.ForeColor = Color.White;
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

        private void сохранитьСловарьtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".dict";
            saveFileDialog1.InitialDirectory = @"..\..\Dict\";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "Vocabulary";
            saveFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    dict.Clear();
                    try
                    {
                        for (int i = 0; i < dataGridViewVocabularyOfV.RowCount - 1; i++)
                        {
                            dict.Add(dataGridViewVocabularyOfV.Rows[i].Cells[0].Value.ToString(), dataGridViewVocabularyOfV.Rows[i].Cells[1].Value.ToString());
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Вы не ввели понятие или определение");
                        return;
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Добавление в словарь одинаковых понятий невозможно");
                        return;
                    }
                    list.Clear();
                    list.AddRange(dict);

                    string s = "";
                    foreach (var item in list)
                    {
                        string def = FirstUpper(item.Value);
                        s += item.Key.ToUpper() + " " + def + "\n";
                    }

                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(s);
                    }
                    MessageBox.Show("Словарь успешно создан");
                }
            }
            catch (Exception) { MessageBox.Show("Выйдите из режима редактирования"); }
        }

        static string FirstUpper(string str)
        {
            string[] s = str.Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                else s[i] = s[i].ToUpper();
            }
            return string.Join(" ", s);
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            openFileDialog1.InitialDirectory = @"..\..\Dict\";
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dict.Clear();
                list.Clear();
                listNot.Clear();
                listDef.Clear();

                dataGridViewVocabularyOfV.Rows.Clear();

                parseDict(openFileDialog1.FileName);
                list.AddRange(dict);

                listNot = dict.Keys.ToList();
                listDef = dict.Values.ToList();

                foreach (var item in list)
                    dataGridViewVocabularyOfV.Rows.Add(item.Key, item.Value);
            }
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            while (dataGridViewVocabularyOfV.Rows.Count > 1)
                for (int i = 0; i < dataGridViewVocabularyOfV.Rows.Count - 1; i++)
                    dataGridViewVocabularyOfV.Rows.Remove(dataGridViewVocabularyOfV.Rows[i]);

            dict.Clear();
            list.Clear();
            listNot.Clear();
            listDef.Clear();

            textBoxVocabularyWordsCountOnV.Clear();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(@"..\..\Crosswords\def.crs", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, _board);
                    MessageBox.Show("Кроссворд сохранен");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCrossword.SelectedCells.Count == 2)
            {
                mask = "";
                if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex + 1)
                {//вправо
                    dir = 3;
                    rowInd = dgvCrossword.SelectedCells[1].RowIndex;

                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" ")) 
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w" + dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + "\\w" + '$';
                    else mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + dgvCrossword.SelectedCells[0].Value.ToString() + '$';

                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!Char.IsLetter(dgvCrossword.Rows[i].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0])) {
                        MessageBox.Show("Неверная область"); }
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex - 1)
                {//влево
                    dir = 1;
                    rowInd = dgvCrossword.SelectedCells[1].RowIndex;
                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        mask = "^\\w" + dgvCrossword.SelectedCells[1].Value.ToString() + '$';
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + "\\w" + '$';
                    else mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + dgvCrossword.SelectedCells[1].Value.ToString() + '$';

                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!dgvCrossword.Rows[i].Cells[j - 1].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex + 1 &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex)
                {//вниз
                    dir = 0;
                    colInd = dgvCrossword.SelectedCells[1].ColumnIndex;
                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w" + dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + "\\w" + '$';
                    else mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + dgvCrossword.SelectedCells[0].Value.ToString() + '$';

                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!dgvCrossword.Rows[i + 1].Cells[j].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j+1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j-1].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j-1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j+1].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex - 1 &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex)
                {//вверх
                    dir = 2;
                    colInd = dgvCrossword.SelectedCells[1].ColumnIndex;
                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        mask = "^\\w" + dgvCrossword.SelectedCells[1].Value.ToString() + '$';
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + "\\w" + '$';
                    else mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + dgvCrossword.SelectedCells[1].Value.ToString() + '$';

                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!dgvCrossword.Rows[i - 1].Cells[j].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                }
                else
                    MessageBox.Show("Неверная область");
            }
            if (dgvCrossword.SelectedCells.Count > 2)
            {
                if (dir == 3)
                {
                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!(dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex + 1) ||
                        rowInd != dgvCrossword.SelectedCells[0].RowIndex ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                    else
                    {
                        if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        {
                            mask = mask.Remove(mask.Length - 1);
                            mask += "\\w$";
                        }
                        else
                        {
                            mask = mask.Remove(mask.Length - 1);
                            mask += dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                        }
                        updateDGV(dataGridViewVocabularyOfC, mask);
                    }

                }
                else if (dir == 1)
                {
                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!(dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex - 1) ||
                        rowInd != dgvCrossword.SelectedCells[0].RowIndex ||
                        !dgvCrossword.Rows[i].Cells[j - 1].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                    else
                    {
                        if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        {
                            mask = mask.Remove(0, 1);
                            mask = mask.Insert(0, "^\\w");
                        }
                        else
                        {
                            mask = mask.Remove(0, 1);
                            mask = mask.Insert(0, '^' + dgvCrossword.SelectedCells[0].Value.ToString());
                        }
                        updateDGV(dataGridViewVocabularyOfC, mask);
                    }
                }
                else if (dir == 0)
                {
                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!(dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex + 1) ||
                        colInd != dgvCrossword.SelectedCells[0].ColumnIndex ||
                        !dgvCrossword.Rows[i + 1].Cells[j].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                    else
                    {
                        if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        {
                            mask = mask.Remove(mask.Length - 1);
                            mask += "\\w$";
                        }
                        else
                        {
                            mask = mask.Remove(mask.Length - 1);
                            mask += dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                        }
                        updateDGV(dataGridViewVocabularyOfC, mask);
                    }
                }
                else
                {
                    int i = dgvCrossword.SelectedCells[0].RowIndex;
                    int j = dgvCrossword.SelectedCells[0].ColumnIndex;
                    if (!(dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex - 1) ||
                        colInd != dgvCrossword.SelectedCells[0].ColumnIndex ||
                        !dgvCrossword.Rows[i - 1].Cells[j].Value.ToString().Equals(" ") ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]))
                        MessageBox.Show("Неверная область");
                    else {
                        if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                        {
                            mask = mask.Remove(0, 1);
                            mask = mask.Insert(0, "^\\w");
                        }
                        else {
                            mask = mask.Remove(0, 1);
                            mask = mask.Insert(0, '^' + dgvCrossword.SelectedCells[0].Value.ToString());
                        }
                        updateDGV(dataGridViewVocabularyOfC, mask);
                    }
                }
            }
        }

        void updateDGV(DataGridView dgv, string pat) {

            listNot = dict.Keys.ToList();
            dataGridViewVocabularyOfC.Rows.Clear();
            foreach (var item in listNot)
            {
                if (Regex.IsMatch(item, pat, RegexOptions.IgnoreCase))
                {
                    dgv.Rows.Add(item);
                }
            }

        }

        private void buttonClearMask_Click(object sender, EventArgs e)
        {
            dataGridViewVocabularyOfC.Rows.Clear();
            foreach (var item in list)
                dataGridViewVocabularyOfC.Rows.Add(item.Key);
        }

        private void dataGridViewVocabularyOfC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCrossword.SelectedCells.Count > 2)
            {

                clearDGV(dgvCrossword);

                string s = dataGridViewVocabularyOfC.SelectedCells[0].Value.ToString();

                if (dir == 3) {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex - 1;
                    _board.AddWord(s, xPos, yPos, 0);
                }
                else if (dir == 1)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex - 1;
                    _board.AddWord(s, xPos, yPos, 0);
                }
                else if (dir == 0)
                {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex - 1;
                    _board.AddWord(s, xPos, yPos, 1);
                }
                else if (dir == 2)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex - 1;
                    _board.AddWord(s, xPos, yPos, 1);
                }

                Actualize();
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _board.Reset();

            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }

            clearDGV(dgvCrossword);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVocabularyOfV.Rows.Clear();
        }
    }
}
