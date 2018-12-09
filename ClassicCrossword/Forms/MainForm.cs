using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassicCrossword.Forms
{
    public partial class MainForm : Form
    {
        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Grid.Create(GridPanel, n - 2 , m - 2); // создание сетки заданной размерности
            parseDict("Glavny.dict");
            list.AddRange(dict);
        }

        private void parseDict(string filename)
        {
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("windows-1251")).Take(10).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Split(' ')[0];
                string question = words[i].Substring(words[i].IndexOf(' '));

                dict.Add(word, question);
            }
        }

        void GenerateCrossword()
        {
            
        }

        private void generatecrosswordButton_Click(object sender, EventArgs e)
        {
            GenerateCrossword();
        }
    }
}
