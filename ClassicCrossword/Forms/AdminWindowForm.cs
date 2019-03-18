using ClassicCrossword.Controller;
using ClassicCrossword.Model;
using ClassicCrossword.Forms;
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
        private DictController dictController;

        private static int n = 20; // максимальное число строк в сетке

        private static int m = 20; // максимальное число столбцов в сетке

        int counter = 0;

        public DataGridView DGV
        {
            get { return this.dgvCrossword; }
            set { this.dgvCrossword = value; }
        }

        public static int N
        {
            get { return n; }
            set { n = value; }
        }
        public static int M
        {
            get {return m; }
            set { m = value; }
        }

        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

        private List<string> listNot;
        private List<string> listDef;

        private SortedDictionary<string, string> notUsedDict;
        private SortedDictionary<string, string> tmpDict;
        
        private int currentDirection;
        private enum direction {right, left, up, down};
        private int lastDirection;
        private int startDirection;
        private Point lastCell;
        private int lastSelectionLength;
        private bool decFlag;
        private int crossingCount = 0;
      

        private int colInd;
        private int rowInd;
        bool toggle = false;

        private string mask = "";

        Crossword _board = new Crossword(n, m);

        public AdminWindowForm()
        {
            InitializeComponent();
            dictController = new DictController();
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

        internal static void clearDGV(object dataGridView)
        {
            throw new NotImplementedException();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранного игрока?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvAccount.CurrentRow.Cells[0].Value);
                string log = dgvAccount.CurrentRow.Cells[1].Value.ToString();
                string pass = dgvAccount.CurrentRow.Cells[2].Value.ToString();
                try
                {
                    playerTableAdapter.Delete(id, log, pass);
                    //new UserController().DeleteById(id);
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

            fillGrid(n, m);
            fillDict();
        }

        public void deleteGrid()
        {
            while (dgvCrossword.Rows.Count > 1)
            {
                dgvCrossword.Rows.RemoveAt(0);
            }
            while (dgvCrossword.Columns.Count > 0)
            {
                dgvCrossword.Columns.RemoveAt(0);
            }
        }

        public void fillGrid(int n , int m)
        {
            Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
            dgvCrossword.Font = font;

            int k;
            for (int i = 0; i < m; i++)
            {
                k = dgvCrossword.Columns.Add(i.ToString(), i.ToString());
                dgvCrossword.Columns[k].Width = 25;
            }

            for (int i = 0; i < n; i++)
            {
                k = dgvCrossword.Rows.Add();
                dgvCrossword.Rows[k].Height = 25;
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Value = " ";
                    dgvCrossword.Rows[i].Cells[j].ReadOnly = true;
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
        }

        public void fillDict()
        {
            try
            {
                dict = dictController.ParseDict(@"..\..\Dict\Glavny.dict");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("В словаре имеются одинаковые понятия");
                textBoxVocabularyWordsCountOnC.Text = "0";
                textBoxVocabularyWordsCountOnV.Text = "0";
                return;
            }
            dictShow();
        }

        public void dictShow()
        {
            groupBoxVocabularyOfC.Text = "Glavny.dict";
            groupBoxVocabularyOfV.Text = "Glavny.dict";

            if (list.Count > 0 )
                list.Clear();

            list.AddRange(dict);

            listNot = dict.Keys.ToList();
            listDef = dict.Values.ToList();

            List<string> tmplist = new List<string>();

            foreach (var item in list)
            {
                dgvVocabularyOfC.Rows.Add(item.Key);
                dgvVocabularyOfV.Rows.Add(item.Key, item.Value);
            }

            textBoxVocabularyWordsCountOnC.Text = dict.Count.ToString();
            textBoxVocabularyWordsCountOnV.Text = dict.Count.ToString();
        }

        

        private void chooseVocabularyOfCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            string initPath = @"..\..\Dict\";
            openFileDialog1.InitialDirectory = Path.GetFullPath(initPath);
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chooseVocabulary(openFileDialog1);
            }
        }

        public void chooseVocabulary(OpenFileDialog openFileDialog1)
        {
            dict.Clear();
            list.Clear();
            listNot.Clear();
            listDef.Clear();
            dgvVocabularyOfC.Rows.Clear();
            dgvVocabularyOfV.Rows.Clear();


            try
            {
                dict = dictController.ParseDict(openFileDialog1.FileName); 
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

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _board.N; i++)
            {
                for (var j = 0; j < _board.M; j++)
                {
                    dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    dgvCrossword.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                }
            }
            _board.Reset();
            clearDGV(dgvCrossword);
            GenerateCrossword();
        }

        private class ComparerForDict : IComparer<string>
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

        static IComparer<string> GetComparerForDict()
        {
            return new ComparerForDict();
        }

        public void GenerateCrossword()
        {
            notUsedDict = new SortedDictionary<string, string>();
            tmpDict = new SortedDictionary<string, string>();
            try
            {
                SortedDictionary<string, string> srcDict = new SortedDictionary<string, string>(dict, GetComparerForDict());
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
                        dgvCrossword.Rows[i].Cells[j].Value = letter.ToString();
                        dgvCrossword.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                    p++;
                }
            }
        }

        public void clearDGV(DataGridView dgv)
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
            Dictionary<string, string> localDict = new Dictionary<string, string>();
            try
            {
                for (int i = 0; i < dgvVocabularyOfV.RowCount - 1; i++)
                {
                    localDict.Add(dgvVocabularyOfV.Rows[i].Cells[0].Value.ToString(), dgvVocabularyOfV.Rows[i].Cells[1].Value.ToString());
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
            List<KeyValuePair<string, string>> localList = new List<KeyValuePair<string, string>>();
            localList.AddRange(localDict);

            string s = "";
            foreach (var item in localList)
                s += item.Key + " " + item.Value + "\n";

            saveFileDialog1.DefaultExt = ".dict";
            saveFileDialog1.InitialDirectory = @"..\..\Dict\";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "Vocabulary";
            saveFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(dictController.SaveDict(s, saveFileDialog1.FileName))
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

        private bool checkRight(int selectedCellsCount)
        {
            bool flag = true;
            //верхняя граница
            if (lastCell.Y == 0 && dgvCrossword.SelectedCells[0].RowIndex == 0)
            {
                //слева сверху по горизонтали
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {                        
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли снизу, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y + 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева сверху по горизонтали");
                }
                //справа сверху по горизонтали
                else if (dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.ColumnCount - 1 || dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли снизу, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " "  && dgvCrossword.Rows[lastCell.Y + 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа сверху по горизонтали");
                }
                //сверху по горизонтали
                else
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли снизу, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Сверху по горизонтали");
                }
            }
            //нижняя граница
            else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.RowCount - 1)
            {
                //слева снизу по горизонтали
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли сверху, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y - 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева снизу по горизонтали");
                }
                //справа снизу по горизонтали
                else if (dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.ColumnCount - 1 || dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли сверху, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y - 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа снизу по горизонтали");
                }
                //снизу по горизонтали
                else
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли сверху, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y - 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Снизу по горизонтали");
                }
            }
            //не на верхней/нижней границе границе
            else
            {
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //проверка есть ли снизу, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху, где нет пересечений
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " " && dgvCrossword.Rows[lastCell.Y - 2].Cells[i].Value.ToString() == " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева по горизонтали");
                }
                else if (dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.ColumnCount - 1 || dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа по горизонтали");
                }
                else
                {
                    if (startDirection == (int)direction.right)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Общий случай");
                }
            }
            return flag;
        }
        private bool checkLeft(int selectedCellsCount)
        {
            bool flag = true;
            //верхняя граница
            if (lastCell.Y == 0 && dgvCrossword.SelectedCells[0].RowIndex == 0)
            {
                //слева сверху по горизонтали
                if (dgvCrossword.SelectedCells[0].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева сверху по горизонтали");
                }
                //справа сверху по горизонтали
                else if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {

                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа сверху по горизонтали");
                }
                //сверху по горизонтали
                else
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Сверху по горизонтали");
                }
            }
            //нижняя граница
            else if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == dgvCrossword.RowCount - 1)//?
            {
                //слева снизу по горизонтали
                if (dgvCrossword.SelectedCells[0].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева снизу по горизонтали");
                }
                //справа снизу по горизонтали
                else if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа снизу по горизонтали");
                }
                //снизу по горизонтали
                else
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Снизу по горизонтали");
                }
            }
            //не на верхней/нижней границе
            else
            {
                if (dgvCrossword.SelectedCells[0].ColumnIndex == 0)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева по горизонтали");
                }
                else if (dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex == dgvCrossword.ColumnCount - 1)
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа по горизонтали");
                }
                else
                {
                    if (startDirection == (int)direction.left)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " " || dgvCrossword.Rows[lastCell.Y].Cells[dgvCrossword.SelectedCells[selectedCellsCount - 1].ColumnIndex - 1].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли снизу
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y + 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли сверху
                        for (int i = dgvCrossword.SelectedCells[0].ColumnIndex; i < dgvCrossword.SelectedCells[0].ColumnIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[lastCell.Y - 1].Cells[i].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Общий случай");
                }
            }
            return flag;
        }
        private bool checkDown(int selectedCellsCount)
        {
            bool flag = true;
            //левая граница
            if (lastCell.X == 0 && dgvCrossword.SelectedCells[0].ColumnIndex == 0)
            {
                //слева сверху по вертикали
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == 0)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева сверху по вертикали");
                }
                //слева снизу по вертикали
                else if (lastCell.Y == dgvCrossword.RowCount - 1)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева снизу по вертикали");
                }
                //слева
                else
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Cлева по вертикали");
                }
            }
            //правая граница
            else if (lastCell.X == dgvCrossword.ColumnCount - 1)
            {
                //справа сверху по вертикали
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == 0)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа сверху по вертикали");
                }
                //справа снизу по вертикали
                else if (lastCell.Y == dgvCrossword.RowCount - 1)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа снизу по вертикали");
                }
                //справа
                else
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Cправа по вертикали");
                }
            }
            //не на левой/правой границе
            else
            {
                if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == 0)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Сверху по вертикали");
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.RowCount - 1 || dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == dgvCrossword.RowCount - 1)
                {
                    if (startDirection == (int)direction.down)
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Снизу по вертикали");
                }
                else
                {
                    if (startDirection == (int)direction.down) //обратная индексация грида
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    else
                    {
                        if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                        {
                            dgvVocabularyOfC.Rows.Clear();
                            flag = false;
                        }
                    }
                    if (crossingCount == 0)
                    {
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex; i < dgvCrossword.SelectedCells[0].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Общий случай");
                }
            }
            return flag;
        }
        private bool checkUp(int selectedCellsCount)
        {
            bool flag = true;
            //левая граница
            if (lastCell.X == 0 && dgvCrossword.SelectedCells[0].ColumnIndex == 0)
            {
                //слева сверху по вертикали
                if (dgvCrossword.SelectedCells[0].RowIndex == 0 || dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == 0)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up) //прямой порядок нумерации
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else //обратный порядок нумерации
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева сверху по вертикали");
                }
                //слева снизу по вертикали
                else  if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == dgvCrossword.RowCount - 1)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }

                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Слева снизу по вертикали");
                }
                //слева
                else
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Cлева по вертикали");
                }
            }
            //правая граница
            else if (lastCell.X == dgvCrossword.ColumnCount - 1)
            {
                //справа сверху по вертикали
                if (dgvCrossword.SelectedCells[0].RowIndex == 0)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа сверху по вертикали");
                }
                //справа снизу по вертикали
                else if (dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex == dgvCrossword.RowCount - 1)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }

                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Справа снизу по вертикали");
                }
                //справа
                else
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Cправа по вертикали");
                }
            }
            //не на левой/правой границе
            else
            {
                if (dgvCrossword.SelectedCells[0].RowIndex == 0)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < selectedCellsCount; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Сверху по вертикали");
                }
                else if (dgvCrossword.SelectedCells[selectedCellsCount-1].RowIndex == dgvCrossword.RowCount - 1)
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }

                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Снизу по вертикали");
                }
                else
                {
                    if (crossingCount == 0)
                    {
                        if (startDirection == (int)direction.up)
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        else
                        {
                            if (dgvCrossword.Rows[dgvCrossword.SelectedCells[0].RowIndex + 1].Cells[lastCell.X].Value.ToString() != " " || dgvCrossword.Rows[dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex - 1].Cells[lastCell.X].Value.ToString() != " ")
                            {
                                dgvVocabularyOfC.Rows.Clear();
                                flag = false;
                            }
                        }
                        //проверка есть ли cправа
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex + 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                        //проверка есть ли cлева
                        for (int i = dgvCrossword.SelectedCells[0].RowIndex; i < dgvCrossword.SelectedCells[selectedCellsCount - 1].RowIndex + 1; i++)
                        {
                            if (dgvCrossword.Rows[i].Cells[dgvCrossword.SelectedCells[0].ColumnIndex - 1].Value.ToString() != " ")
                            {
                                dgvCrossword.ClearSelection();
                                return false;
                            }
                        }
                    }
                    //MessageBox.Show("Общий случай");
                }
            }
            return flag;
        }

        private void dgvCrossword_SelectionChanged(object sender, EventArgs e)
        {
            decFlag = false;
            int selectedCellsCount = dgvCrossword.SelectedCells.Count;

            if (selectedCellsCount == 1)
            {
                lastCell = new Point(dgvCrossword.SelectedCells[0].ColumnIndex, dgvCrossword.SelectedCells[0].RowIndex);
                lastDirection = (int)direction.right;
                dgvVocabularyOfC.Rows.Clear();
                mask = "";
                crossingCount = 0;
            }
            else if (selectedCellsCount == 2)
            {
                dgvVocabularyOfC.Rows.Clear();
                mask = "";
                if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex + 1)
                {
                    lastCell = new Point(lastCell.X + 1, lastCell.Y);
                    lastDirection = (int)direction.right;

                    //вправо
                    startDirection = (int)direction.right;
                    currentDirection = (int)direction.right;

                    rowInd = dgvCrossword.SelectedCells[0].RowIndex;

                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = "^\\w" + dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                    }
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + "\\w" + '$';
                    }
                    else mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + dgvCrossword.SelectedCells[0].Value.ToString() + '$';

                    checkRight(selectedCellsCount);
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex - 1)
                {
                    lastCell = new Point(lastCell.X - 1, lastCell.Y);
                    lastDirection = (int)direction.left;

                    //влево
                    startDirection = (int)direction.left;
                    currentDirection = (int)direction.left;
                    rowInd = dgvCrossword.SelectedCells[0].RowIndex;

                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = "^\\w" + dgvCrossword.SelectedCells[1].Value.ToString() + '$';
                    }
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + "\\w" + '$';
                    }
                    else mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + dgvCrossword.SelectedCells[1].Value.ToString() + '$';

                    checkLeft(selectedCellsCount);
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex + 1 &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex)
                {
                    lastCell = new Point(lastCell.X, lastCell.Y + 1);
                    lastDirection = (int)direction.down;

                    //вниз
                    startDirection = (int)direction.down;
                    currentDirection = (int)direction.down;
                    colInd = dgvCrossword.SelectedCells[0].ColumnIndex;

                    

                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                        mask = "^\\w\\w$";
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = "^\\w" + dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                    }
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + "\\w" + '$';
                    }                        
                    else mask = '^' + dgvCrossword.SelectedCells[1].Value.ToString() + dgvCrossword.SelectedCells[0].Value.ToString() + '$';//??

                    checkDown(selectedCellsCount);
                }
                else if (dgvCrossword.SelectedCells[0].RowIndex == dgvCrossword.SelectedCells[1].RowIndex - 1 &&
                    dgvCrossword.SelectedCells[0].ColumnIndex == dgvCrossword.SelectedCells[1].ColumnIndex)
                {
                    lastCell = new Point(lastCell.X, lastCell.Y - 1);
                    lastDirection = (int)direction.up;

                    //вверх
                    startDirection = (int)direction.up;
                    currentDirection = (int)direction.up;
                    colInd = dgvCrossword.SelectedCells[0].ColumnIndex;

                    if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" ") && dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                    {
                        mask = "^\\w\\w$";
                    }
                    else if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = "^\\w" + dgvCrossword.SelectedCells[1].Value.ToString() + '$';
                    }
                    else if (dgvCrossword.SelectedCells[1].Value.ToString().Equals(" "))
                    {
                        crossingCount++;
                        mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + "\\w" + '$';
                    }
                    else mask = '^' + dgvCrossword.SelectedCells[0].Value.ToString() + dgvCrossword.SelectedCells[1].Value.ToString() + '$';

                    checkUp(selectedCellsCount);
                }
                else
                    MessageBox.Show("Неверная область");

                lastSelectionLength = selectedCellsCount;
            }
            else if (selectedCellsCount > 2)
            {
                //если накапливание
                if (selectedCellsCount > lastSelectionLength)
                {
                    //если прежде двигались вправо, накопление идет вправо и сейчас идём вправо
                    if (lastDirection == (int)direction.right && dgvCrossword.SelectedCells[1].ColumnIndex + 1 == dgvCrossword.SelectedCells[0].ColumnIndex)
                        currentDirection = (int)direction.right;
                    //если прежде двигались вправо, накопление идет влево и сейчас идём влево
                    else if (lastDirection == (int)direction.right && dgvCrossword.SelectedCells[1].ColumnIndex - 1 == dgvCrossword.SelectedCells[0].ColumnIndex)
                        currentDirection = (int)direction.left;
                    //если прежде двигались влево, накопление идет вправо и сейчас идём вправо
                    else if (lastDirection == (int)direction.left && dgvCrossword.SelectedCells[1].ColumnIndex + 1 == dgvCrossword.SelectedCells[0].ColumnIndex)
                        currentDirection = (int)direction.right;
                    //если прежде двигались влево , накопление идет влево и сейчас идём влево
                    else if (lastDirection == (int)direction.left && dgvCrossword.SelectedCells[1].ColumnIndex - 1 == dgvCrossword.SelectedCells[0].ColumnIndex)
                        currentDirection = (int)direction.left;

                    //если прежде двигались вниз, накопление идет вниз и сейчас идём вниз
                    else if (lastDirection == (int)direction.down && dgvCrossword.SelectedCells[1].RowIndex + 1 == dgvCrossword.SelectedCells[0].RowIndex)
                        currentDirection = (int)direction.down;
                    //если прежде двигались вниз, накопление идет вверх и сейчас идём вверх
                    else if (lastDirection == (int)direction.down && dgvCrossword.SelectedCells[1].RowIndex - 1 == dgvCrossword.SelectedCells[0].RowIndex)
                        currentDirection = (int)direction.up;
                    //если прежде двигались вверх, накопление идет вниз и сейчас идём вниз
                    else if (lastDirection == (int)direction.up && dgvCrossword.SelectedCells[1].RowIndex + 1 == dgvCrossword.SelectedCells[0].RowIndex)
                        currentDirection = (int)direction.down;
                    //если прежде двигались вверх, накопление идет вверх и сейчас идём вверх
                    else if (lastDirection == (int)direction.up && dgvCrossword.SelectedCells[1].RowIndex - 1 == dgvCrossword.SelectedCells[0].RowIndex)
                        currentDirection = (int)direction.up;
                }
                //если декремент выделения
                else
                {
                    decFlag = true;
                    //если прежде двигались вправо, декремент идет влево и сейчас идём влево
                    if (lastDirection == (int)direction.right && dgvCrossword.SelectedCells[0].ColumnIndex == lastCell.X - 1)
                        currentDirection = (int)direction.left;
                    //если прежде двигались влево, декремент идет влево и сейчас идём влево
                    else if (lastDirection == (int)direction.left && dgvCrossword.SelectedCells[0].ColumnIndex == lastCell.X - 1)
                        currentDirection = (int)direction.left;
                    //если прежде двигались влево, декремент идет вправо и сейчас идем вправо
                    else if (lastDirection == (int)direction.left && dgvCrossword.SelectedCells[0].ColumnIndex == lastCell.X + 1)
                        currentDirection = (int)direction.right;
                    //если прежде двигались вправо, декремент идет вправо и сейчас идем вправо
                    else if (lastDirection == (int)direction.right && dgvCrossword.SelectedCells[0].ColumnIndex == lastCell.X + 1)
                        currentDirection = (int)direction.right;

                    //если прежде двигались вниз, декремент вверх и сейчас идём вверх
                    else if (lastDirection == (int)direction.down && dgvCrossword.SelectedCells[0].RowIndex == lastCell.Y - 1)
                        currentDirection = (int)direction.up;
                    //если прежде двигались вниз, декремент вниз и сейчас идём вниз
                    else if (lastDirection == (int)direction.down && dgvCrossword.SelectedCells[0].RowIndex == lastCell.Y + 1)
                        currentDirection = (int)direction.down;
                    //если прежде двигались вверх, декремент идет вниз и сейчас идём вниз
                    else if (lastDirection == (int)direction.up && dgvCrossword.SelectedCells[0].RowIndex == lastCell.Y + 1)
                        currentDirection = (int)direction.down;
                    //если прежде двигались вверх, декремент вверх и сейчас идём вверх
                    else if (lastDirection == (int)direction.up && dgvCrossword.SelectedCells[0].RowIndex == lastCell.Y - 1)
                        currentDirection = (int)direction.up;
                }
                //вправо
                if (currentDirection == (int)direction.right)
                {
                    if (rowInd != dgvCrossword.SelectedCells[0].RowIndex || dgvCrossword.SelectedRows.Count > 1)
                    {
                        dgvCrossword.ClearSelection();
                        dgvVocabularyOfC.Rows.Clear();
                    }
                    else
                    {
                        if (!decFlag && (lastDirection == (int)direction.right || lastDirection == (int)direction.left))
                        {
                            if (!dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                            {
                                mask = mask.Remove(mask.Length - 1);
                                mask += dgvCrossword.SelectedCells[0].Value.ToString() + '$';
                                crossingCount++;
                            }
                            else
                            {
                                mask = mask.Remove(mask.Length - 1);
                                mask += "\\w$";
                            }
                        }
                        else if (decFlag)
                        {
                            String m = mask.Substring(0, 3);
                            if (m != "^\\w")
                            {
                                mask = mask.Remove(1, 1);
                                crossingCount--;
                            }
                            else if (m == "^\\w")
                            {
                                mask = mask.Remove(1, 2);
                            }
                        }

                        lastDirection = (int)direction.right;
                        lastCell = new Point(lastCell.X + 1, lastCell.Y);
                        if (checkRight(selectedCellsCount))
                        {
                            updateDGV(dgvVocabularyOfC, mask);
                        }
                        else
                        {  }

                    }
                }
                //влево
                else if (currentDirection == (int)direction.left)
                {
                   
                    if (rowInd != dgvCrossword.SelectedCells[0].RowIndex || dgvCrossword.SelectedRows.Count > 1)
                    {
                        dgvCrossword.ClearSelection();
                        dgvVocabularyOfC.Rows.Clear();
                    }
                    else
                    {
                        if (!decFlag && (lastDirection == (int)direction.left || lastDirection == (int)direction.right))
                        {
                            if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                            {
                                mask = mask.Remove(0, 1);
                                mask = mask.Insert(0, "^\\w");
                            }
                            else if (!dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                            {
                                mask = mask.Remove(0, 1);
                                mask = mask.Insert(0, '^' + dgvCrossword.SelectedCells[0].Value.ToString());
                                crossingCount++;
                            }
                        }
                        else if (decFlag)
                        {
                            String m = mask.Substring(mask.Length - 2, 1);
                            if (mask.Substring(mask.Length - 2, 1) != "w")
                            {
                                mask = mask.Remove(mask.Length - 2);
                                crossingCount--;
                            }
                            else
                            {
                                mask = mask.Remove(mask.Length - 3);
                            }
                            mask += '$';
                        }
                        lastDirection = (int)direction.left;
                        lastCell = new Point(lastCell.X - 1, lastCell.Y);
                        if (checkLeft(selectedCellsCount))
                        {
                            updateDGV(dgvVocabularyOfC, mask);
                        }
                        else
                        { }


                    }
                }
                //вниз
                else if (currentDirection == (int)direction.down)
                {
                    
                    if (colInd != dgvCrossword.SelectedCells[0].ColumnIndex || dgvCrossword.SelectedColumns.Count > 1)
                    {
                        dgvCrossword.ClearSelection();
                        dgvVocabularyOfC.Rows.Clear();
                    }
                    else
                    {
                        if (!decFlag && (lastDirection == (int)direction.down || lastDirection == (int)direction.up))
                        {
                            if (dgvCrossword.SelectedCells[0].Value.ToString().Equals(" "))
                            {
                                mask = mask.Remove(mask.Length - 1);
                                mask = mask.Insert(mask.Length, "\\w$");
                            }
                            else
                            {
                                mask = mask.Remove(mask.Length - 1);
                                mask = mask.Insert(mask.Length, dgvCrossword.SelectedCells[0].Value.ToString() + '$');
                                crossingCount++;
                            }
                        }
                        else if (decFlag)
                        {
                            String m = mask.Substring(0, 3);
                            if (m != "^\\w")
                            {
                                mask = mask.Remove(1, 1);
                                crossingCount--;
                            }
                            else if (m == "^\\w")
                            {
                                mask = mask.Remove(1, 2);
                            }
                        }

                        lastDirection = (int)direction.down;
                        lastCell = new Point(lastCell.X, lastCell.Y + 1);
                        if (checkDown(selectedCellsCount))
                        {
                            updateDGV(dgvVocabularyOfC, mask);
                        }
                        else
                        { }

                    }
                }
                //вверх
                else
                {
                    
                    if (colInd != dgvCrossword.SelectedCells[0].ColumnIndex || dgvCrossword.SelectedColumns.Count > 1)
                    {
                        dgvCrossword.ClearSelection();
                        dgvVocabularyOfC.Rows.Clear();
                    }
                    else
                    {
                        if (!decFlag && (lastDirection == (int)direction.up || lastDirection == (int)direction.down))
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
                                crossingCount++;
                            }
                        }
                        else if (decFlag)
                        {
                            String m = mask.Substring(mask.Length - 2, 1);
                            if (mask.Substring(mask.Length - 2, 1) != "w")
                            {
                                mask = mask.Remove(mask.Length - 2);
                                crossingCount--;
                            }
                            else
                            {
                                mask = mask.Remove(mask.Length - 3);
                            }
                            mask += '$';
                        }
                        lastDirection = (int)direction.up;
                        lastCell = new Point(lastCell.X, lastCell.Y - 1);
                        if (checkUp(selectedCellsCount))
                        {
                            updateDGV(dgvVocabularyOfC, mask);
                        }
                        else
                        { }


                    }
                }
                lastSelectionLength = selectedCellsCount;
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

                if (currentDirection == (int)direction.right)
                {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex;
                    _board.AddWord(s, dict[s], xPos, yPos, 0);
                }
                else if (currentDirection == (int)direction.left)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex;
                    _board.AddWord(s, dict[s], xPos, yPos, 0);
                }
                else if (currentDirection == (int)direction.down)
                {
                    int xPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].RowIndex;
                    int yPos = dgvCrossword.SelectedCells[dgvCrossword.SelectedCells.Count - 1].ColumnIndex;
                    _board.AddWord(s, dict[s], xPos, yPos, 1);
                }
                else if (currentDirection == (int)direction.up)
                {
                    int xPos = dgvCrossword.SelectedCells[0].RowIndex;
                    int yPos = dgvCrossword.SelectedCells[0].ColumnIndex;
                    _board.AddWord(s, dict[s], xPos, yPos, 1);
                }
                Actualize();
            }
        }

        private class ComparerForLengthAsc : IComparer<string>
        {
            public int Compare(string not1, string not2)
            {
                if (not1.Length >= not2.Length)
                    return 1;
                else if (not1.Length < not2.Length)
                    return -1;
                else return 0;
            }
        }

        static IComparer<string> GetComparerForLengthAsc()
        {
            return new ComparerForLengthAsc();
        }

        private class ComparerForLengthDesc : IComparer<string>
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

        static IComparer<string> GetComparerForLengthDesc()
        {
            return new ComparerForLengthDesc();
        }

        private class ComparerForAlphabetAsc : IComparer<string>
        {
            public int Compare(string not1, string not2)
            {
                if (not1.CompareTo(not2) == 1)
                    return 1;
                else if (not1.CompareTo(not2) == -1)
                    return -1;
                else return 0;
            }
        }

        static IComparer<string> GetComparerForAlphabetAsc()
        {
            return new ComparerForAlphabetAsc();
        }

        private class ComparerForAlphabetDesc : IComparer<string>
        {
            public int Compare(string not1, string not2)
            {
                if (not1.CompareTo(not2) != 1)
                    return 1;
                else if (not1.CompareTo(not2) != -1)
                    return -1;
                else return 0;
            }
        }

        static IComparer<string> GetComparerForAlphabetDesc()
        {
            return new ComparerForAlphabetDesc();
        }

        private void buttonSortByLength_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            //для datagridview
            dgvVocabularyOfC.AllowUserToAddRows = false;

            listNot = dict.Keys.ToList();
            List<string> tempList = new List<string>();

            for (int i = 0; i < dgvVocabularyOfC.Rows.Count; i++)
            {
                tempList.Add(dgvVocabularyOfC.Rows[i].Cells[0].Value.ToString());
            }
            dgvVocabularyOfC.Rows.Clear();

            switch (toggle) {
                case true: tempList.Sort(GetComparerForLengthAsc()); break;
                case false: tempList.Sort(GetComparerForLengthDesc()); break;
            }

            foreach (var item in tempList)
            {
                dgvVocabularyOfC.Rows.Add(item);
            }
        }

        private void buttonSortByAlphabet_Click(object sender, EventArgs e)
        {
            //для исходного массива
            //listNot = dict.Keys.ToList();
            //dgvVocabularyOfC.Rows.Clear();
            //listNot.Sort();
            //foreach (var item in listNot)
            //{
            //    dgvVocabularyOfC.Rows.Add(item);
            //}

            //для datagridview

            // dgvVocabularyOfC.Rows.RemoveAt(dgvVocabularyOfC.Rows.Count - 1 );

            //string[,] tempLists = new string[dgvVocabularyOfC.Rows.Count, dgvVocabularyOfC.Columns.Count];

            //foreach (DataGridViewRow Row in dgvVocabularyOfC.Rows)
            //{
            //    foreach (DataGridViewColumn Column in dgvVocabularyOfC.Columns)
            //    {
            //        tempLists[Row.Index, Column.Index] = dgvVocabularyOfC.Rows[Row.Index].Cells[Column.Index].Value.ToString();
            //    }
            //}

            toggle = !toggle;
            dgvVocabularyOfC.AllowUserToAddRows = false;
            listNot = dict.Keys.ToList();
            List<string> tempList = new List<string>();

            for (int i = 0; i < dgvVocabularyOfC.Rows.Count; i++)
            {
                tempList.Add(dgvVocabularyOfC.Rows[i].Cells[0].Value.ToString());
            }
            dgvVocabularyOfC.Rows.Clear();

            switch(toggle){
              case true:   tempList.Sort(GetComparerForAlphabetAsc()) ; break;
              case false:  tempList.Sort(GetComparerForAlphabetDesc()); break;
            }

            foreach (var item in tempList)
            {
                dgvVocabularyOfC.Rows.Add(item);
            }
        }

        private void textBoxSearchByMask_TextChanged(object sender, EventArgs e)
        {
            textBoxSearchByMask.Text = textBoxSearchByMask.Text.ToUpper();
            string pat = textBoxSearchByMask.Text;
            listNot = dict.Keys.ToList();
            dgvVocabularyOfC.Rows.Clear();
            
            foreach (var item in listNot)
            {
                Regex mask = new Regex(pat
                    .Replace("*", ".*") //*: предыдущий символ повторяется 0 и более раз
                    .Replace("?", ".?") //?: предыдущий символ повторяется 0 или 1 раз
                    .Replace("+", ".+"));//+: предыдущий символ повторяется 1 и более раз
                                         //.: знак точки определяет любой одиночный символ (например, выражение "м.р" соответствует слову "мир" или "мор") 
                if (mask.IsMatch(item))
                {
                    dgvVocabularyOfC.Rows.Add(item);
                }
            }
            textBoxSearchByMask.SelectionStart = textBoxSearchByMask.Text.Length;
        }

        private void createCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _board.N; i++)
            {
                for (var j = 0; j < _board.M; j++)
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
                deleteRowVocabularyToolStripMenuItem.Enabled = true;

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
            string initPath = @"..\..\Crosswords\";
            openFileDialog1.InitialDirectory = Path.GetFullPath(initPath);
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

                for (var i = 0; i < _board.N; i++)
                {
                    for (var j = 0; j < _board.M; j++)
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

        private void aboutAuthorsCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAuthors form = new AboutAuthors();
            form.Show();
        }

        static void UserManual()
        {
            //get current folderpath of the .exe
            string ProgramPath = AppDomain.CurrentDomain.BaseDirectory;
            //jump back relative to the .exe-Path to the Resources Path
            string FileName = string.Format("{0}Resources\\crosswordGuide.chm", Path.GetFullPath(Path.Combine(ProgramPath, @"..\..\")));

            //Open PDF
            // System.Diagnostics.Process.Start(@"" + FileName + "");
            if (System.IO.File.Exists(FileName))
            {
                System.Diagnostics.Process.Start(FileName);
            }
        }

        private void manualCrosswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManual();
        }

        //todo при открытии словаря во вкладке "словарь", datagrid словаря во вкладке "кроссворд" становится равным ему, и активный словарь также
        private void chooseVocabularyOfVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            string initPath = @"..\..\Dict\";
            openFileDialog1.InitialDirectory = Path.GetFullPath(initPath);
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvVocabularyOfV.Rows.Clear();
                Dictionary<string, string> localDict = new Dictionary<string, string>();
                try
                {
                    localDict = dictController.ParseDict(openFileDialog1.FileName);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("В словаре имеются одинаковые понятия");
                    textBoxVocabularyWordsCountOnV.Text = "0";
                    return;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("В словаре отсутствует понятие | определение");
                    textBoxVocabularyWordsCountOnV.Text = "0";
                    return;
                }

                groupBoxVocabularyOfV.Text = openFileDialog1.SafeFileName;

                List<KeyValuePair<string, string>> localList = new List<KeyValuePair<string, string>>();
                localList.AddRange(localDict);

                foreach (var item in localList)
                {
                    dgvVocabularyOfV.Rows.Add(item.Key, item.Value);
                }

                textBoxVocabularyWordsCountOnV.Text = localDict.Count.ToString();
            }
        }

        private void dgvVocabularyOfV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVocabularyOfV.SelectedCells.Count == 1)
            {
                int rowInd = dgvVocabularyOfV.SelectedCells[0].RowIndex;
                if (dgvVocabularyOfV.Rows[rowInd].Cells[0].Value == null && dgvVocabularyOfV.Rows[rowInd].Cells[1].Value == null)
                {
                    deleteRowVocabularyToolStripMenuItem.Enabled = false;
                }
                else { deleteRowVocabularyToolStripMenuItem.Enabled = true; }
            }
        }

        private void crosswordPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CrosswordSettings().Show();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormClosed += closeForm;
            Hide();
            Close();
        }

        private void closeForm(object sender, FormClosedEventArgs e)
        {
            var authForm = new AuthForm();
            if (authForm.ShowDialog() == DialogResult.OK)
            {
                if (authForm.Usr.GetType() == typeof(Admin))
                    new AdminWindowForm().ShowDialog();
                else
                    new PlayerWindowForm((Player)authForm.Usr).ShowDialog();
            }
        }
    }
}
 