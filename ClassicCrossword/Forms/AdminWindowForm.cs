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

            Grid.Create(mainPanel, n + 2, m + 2); // создание сетки заданной размерности

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

        static int Comparer(string a, string b)
        {
            var temp = a.Length.CompareTo(b.Length);
            return temp == 0 ? a.CompareTo(b) : temp;
        }

        private void parseDict(string filename)
        {
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("windows-1251")).Take(100).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string question = words[i].Substring(words[i].IndexOf(' ') + 1); //TODO убрать костыль

                dict.Add(word, question);
            }

            textBoxVocabularyWordsCountOnV.Text = words.Length.ToString();
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
            for (var i = 1; i < _board.N + 1; i++)
            {
                for (var j = 1; j < _board.M + 1; j++)
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

        private void сохранитьСловарьtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".dict";
            saveFileDialog1.InitialDirectory = @"..\..\Dict\";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "Vocabulary";
            saveFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dict.Clear();

                for (int i = 0; i < dataGridViewVocabularyOfV.RowCount - 1; i++)
                {
                    dict.Add(dataGridViewVocabularyOfV.Rows[i].Cells[0].Value.ToString(), dataGridViewVocabularyOfV.Rows[i].Cells[1].Value.ToString());
                }

                list.Clear();
                list.AddRange(dict);

                string s = "";

                foreach (var item in list)
                {
                    s += item.Key + " " + item.Value + "\n";
                }

                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                }

                //textBox1.Text = folderBrowserDialog1.SelectedPath;


            }
           


        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            openFileDialog1.InitialDirectory = @"..\..\Dict\";
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "Default";
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
                {
                    dataGridViewVocabularyOfC.Rows.Add(item.Key);
                    dataGridViewVocabularyOfV.Rows.Add(item.Key, item.Value);
                }
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

                using (FileStream fs = new FileStream("def.crs", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, _board);

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
