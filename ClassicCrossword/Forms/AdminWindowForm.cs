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

        private SortedDictionary<string, string> notUsedDict;
        private SortedDictionary<string, string> tmpDict;

        private int dir;
        private int colInd;
        private int rowInd;

        private string mask = "";

        Crossword _board = new Crossword(n, m);

        public AdminWindowForm()
        {
            InitializeComponent();
        }

  
        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvAccount.CurrentRow.Cells[0].Value);
            string login = (string)dgvAccount.CurrentRow.Cells[1].Value;
            string pass = (string)dgvAccount.CurrentRow.Cells[2].Value;
            var editPlayerForm = new AddNewPlayerForm(id, login, pass);
            editPlayerForm.Closing += AddNewPlayerForm_Closing;
            editPlayerForm.ShowDialog();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранного игрока?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvAccount.CurrentRow.Cells[0].Value);
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

        private void watchAccountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
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

            try
            {
                parseDict(@"..\..\Dict\Glavny.dict");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("В словаре имеются одинаковые понятия");
                textBoxVocabularyWordsCountOnC.Text = "0";
                textBoxVocabularyWordsCountOnV.Text = "0";
                return;
            }

            groupBoxVocabularyOfC.Text = "Glavny.dict";
            groupBoxVocabularyOfV.Text = "Glavny.dict";

            list.AddRange(dict);

            listNot = dict.Keys.ToList();
            listDef = dict.Values.ToList();

            foreach (var item in list)
            {
                dgvVocabularyOfC.Rows.Add(item.Key);
                dgvVocabularyOfV.Rows.Add(item.Key, item.Value);
            }

            textBoxVocabularyWordsCountOnC.Text = dict.Count.ToString();
            textBoxVocabularyWordsCountOnV.Text = dict.Count.ToString();
        }

        private void parseDict(string filename) 
        {
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("utf-8")).Take(500).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string question = words[i].Substring(words[i].IndexOf(words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1])); //TODO убрать костыль
                dict.Add(word, question);
            }
        }

        private void chooseVocabularyOfCToolStripMenuItem_Click(object sender, EventArgs e)
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
                dgvVocabularyOfC.Rows.Clear();
                dgvVocabularyOfV.Rows.Clear();
                try
                {
                    parseDict(openFileDialog1.FileName);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("В словаре имеются одинаковые понятия");
                    textBoxVocabularyWordsCountOnC.Text = "0";
                    textBoxVocabularyWordsCountOnV.Text = "0";
                    return;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("В словаре отсутствует понятие | определение");
                    textBoxVocabularyWordsCountOnC.Text = "0";
                    textBoxVocabularyWordsCountOnV.Text = "0";
                    return;
                }

                groupBoxVocabularyOfC.Text = openFileDialog1.SafeFileName;
                groupBoxVocabularyOfV.Text = openFileDialog1.SafeFileName;

                list.AddRange(dict);

                listNot = dict.Keys.ToList();
                listDef = dict.Values.ToList();

                foreach (var item in list)
                {
                    dgvVocabularyOfC.Rows.Add(item.Key);
                    dgvVocabularyOfV.Rows.Add(item.Key, item.Value);
                }

                textBoxVocabularyWordsCountOnC.Text = dict.Count.ToString();
                textBoxVocabularyWordsCountOnV.Text = dict.Count.ToString();
            }
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
            _board.Reset();
            clearDGV(dgvCrossword);
            GenerateCrossword();
        }

        class ComparerForDict : IComparer<string>
        {
            public int Compare(string not1, string not2)
            {
                if (not1.Length >= not2.Length)
                    return -1;
                else if (not1.Length < not2.Length)
                    return 1;
                else return 0;
            }
        }

        void GenerateCrossword()
        {
            notUsedDict = new SortedDictionary<string, string>();
            tmpDict = new SortedDictionary<string, string>();
            try
            {
                SortedDictionary<string, string> srcDict = new SortedDictionary<string, string>(dict, new ComparerForDict());
                _board.Temp = srcDict.Keys.ToList();
                GenCrossword(srcDict, srcDict.Count);

                Actualize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void GenCrossword(SortedDictionary<string, string> sd, int cnt)
        {
            tmpDict.Clear();
            foreach (var item in sd)
            {
                switch (_board.AddWord(item.Key, item.Value))
                {
                    case 0:
                        if (notUsedDict.Contains(item))
                            tmpDict.Add(item.Key, item.Value);
                        break;
                    case 1:
                        if (notUsedDict.Contains(item))
                            tmpDict.Add(item.Key, item.Value);
                        break;
                    default:
                        if (!notUsedDict.Contains(item))
                            notUsedDict.Add(item.Key, item.Value);
                        break;
                }
            }
            foreach (var item in tmpDict)
            {
                notUsedDict.Remove(item.Key);
            }
            if (notUsedDict.Count == 0 || notUsedDict.Count == cnt)
                return;
            else
                GenCrossword(notUsedDict, notUsedDict.Count);
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

        private void saveVocabularyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dict.Clear();

            try
            {
                for (int i = 0; i < dgvVocabularyOfV.RowCount - 1; i++)
                {
                    dict.Add(dgvVocabularyOfV.Rows[i].Cells[0].Value.ToString(), dgvVocabularyOfV.Rows[i].Cells[1].Value.ToString());
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Добавление в словарь одинаковых понятий невозможно");
                return;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Вы не ввели понятие | определение или не вышли из режима редактирования");
                return;
            }

            list.Clear();
            list.AddRange(dict);

            string s = "";
            foreach (var item in list)
                s += item.Key + " " + item.Value + "\n";

            saveFileDialog1.DefaultExt = ".dict";
            saveFileDialog1.InitialDirectory = @"..\..\Dict\";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "Vocabulary";
            saveFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(s);
                }
                MessageBox.Show("Словарь успешно создан");
            }
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

        private void createVocabularyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxVocabularyOfC.Text = "";
            groupBoxVocabularyOfV.Text = "";

            dgvVocabularyOfC.Rows.Clear();
            dgvVocabularyOfV.Rows.Clear();

            dict.Clear();
            list.Clear();
            listNot.Clear();
            listDef.Clear();

            textBoxVocabularyWordsCountOnC.Text = "0";
            textBoxVocabularyWordsCountOnV.Text = "0";
        }

        private void saveCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".crs";
            saveFileDialog1.InitialDirectory = @"..\..\Crosswords\";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "Crossword";
            saveFileDialog1.Filter = "Файл кроссворда (*.crs)|*.crs";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, _board);
                        MessageBox.Show("Кроссворд сохранен");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при сохранении кроссворда");
                }
            }
        }

        private void dgvCrossword_SelectionChanged(object sender, EventArgs e)
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
                        !Char.IsLetter(dgvCrossword.Rows[i - 1].Cells[j].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i + 1].Cells[j].Value.ToString()[0]))
                    {
                        MessageBox.Show("Неверная область");
                    }
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
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) ||
                        !Char.IsLetter(dgvCrossword.Rows[i].Cells[j - 1].Value.ToString()[0]) && Char.IsLetter(dgvCrossword.Rows[i].Cells[j + 1].Value.ToString()[0]))
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
                        updateDGV(dgvVocabularyOfC, mask);
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
                        updateDGV(dgvVocabularyOfC, mask);
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
                        updateDGV(dgvVocabularyOfC, mask);
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
                        updateDGV(dgvVocabularyOfC, mask);
                    }
                }
            }
        }

        void updateDGV(DataGridView dgv, string pat)
        {

            listNot = dict.Keys.ToList();
            dgvVocabularyOfC.Rows.Clear();
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
            dgvVocabularyOfC.Rows.Clear();
            foreach (var item in list)
                dgvVocabularyOfC.Rows.Add(item.Key);
        }

        private void dgvVocabularyOfC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCrossword.SelectedCells.Count > 2)
            {

                clearDGV(dgvCrossword);

                string s = dgvVocabularyOfC.SelectedCells[0].Value.ToString();

                if (dir == 3)
                {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex - 1;
                    _board.AddWord(s, dict[s], xPos, yPos, 0);
                }
                else if (dir == 1)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex - 1;
                    _board.AddWord(s, dict[s], xPos, yPos, 0);
                }
                else if (dir == 0)
                {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex - 1;
                    _board.AddWord(s, dict[s], xPos, yPos, 1);
                }
                else if (dir == 2)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex - 1;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex - 1;
                    _board.AddWord(s, dict[s], xPos, yPos, 1);
                }

                Actualize();
            }
        }

        private void createCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _board.N + 2; i++)
            {
                for (var j = 0; j < _board.M + 2; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            _board.Reset();
            clearDGV(dgvCrossword);
        }

        private void dgvVocabularyOfV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void dgvVocabularyOfV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVocabularyOfV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string s = "";
                if (e.ColumnIndex == 0)
                    dgvVocabularyOfV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvVocabularyOfV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                else
                {
                    s = FirstUpper(dgvVocabularyOfV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    dgvVocabularyOfV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = s;
                }
            }
        }

        private void dgvVocabularyOfV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int number;
            Int32.TryParse(textBoxVocabularyWordsCountOnV.Text, out number);
            number++;
            textBoxVocabularyWordsCountOnV.Text = number.ToString();
        }

        private void deleteRowVocabularyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvVocabularyOfV.SelectedCells.Count == 1)
            {
                dgvVocabularyOfV.Rows.RemoveAt(dgvVocabularyOfV.SelectedCells[0].RowIndex);
                int number;
                Int32.TryParse(textBoxVocabularyWordsCountOnV.Text, out number);
                number--;
                textBoxVocabularyWordsCountOnV.Text = number.ToString();
            }
        }

        private void loadCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ChangeKeyboardLayout(System.Globalization.CultureInfo CultureInfo)
        {
            InputLanguage c = InputLanguage.FromCulture(CultureInfo);
            InputLanguage.CurrentInputLanguage = c;
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!(e.KeyChar >= 1040 && e.KeyChar <= 1103)) // 1040...1071 А ~ Я 1072...1103 а ~ я
            {
                String myCurrentLanguage = InputLanguage.CurrentInputLanguage.LayoutName;
                //MessageBox.Show("Ваша раскладка клавиатуры " + myCurrentLanguage + " изменена на Русскую"); todo после первой обработки event'а он начинает выдавать более чем одно сообщение
                ChangeKeyboardLayout(System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
                e.Handled = true;
            }
        }

        private void exitCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}