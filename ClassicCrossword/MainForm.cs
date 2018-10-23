using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword
{
    public partial class MainForm : Form
    {
        public static int n = 20; // максимальное число строк в сетке
        public static int m = 20; // максимальное число столбцов в сетке

        private List<string> wordsList = new List<string>(); //список слов
        private List<string> questionsList = new List<string>(); //список вопросов


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Grid.Create(GridPanel, n - 2 , m - 2); // создание сетки заданной размерности
           
            string[] word = File.ReadAllLines("Glavny.dict", Encoding.GetEncoding("windows-1251")).Take(10).ToArray();
            for (int i = 0; i < 10; i++)
            {
                var words = word[i].Split(' ')[0]; //удалить все что после слова
                wordsListView.Items.Add(words);
            }

            string[] question = File.ReadAllLines("Glavny.dict", Encoding.GetEncoding("windows-1251")).Take(10).ToArray();
            for (int i = 0; i < 10; i++)
            {
                var questions = question[i].Substring(question[i].IndexOf(' ')); //удалить с пробелом все что до вопроса
                questionsListView.Items.Add(questions);
            }
        }

        private void addwordButton_Click(object sender, EventArgs e)
        {
            var word = wordsTextBox.Text.Trim();
            if (word.Length != 0)
            {
                if (wordsList.Contains(word))
                    {
                        MessageBox.Show("Такое слово уже имеется");
                        wordsTextBox.Text = "";
                        return;
                    }
                wordsList.Add(word);
                wordsListView.Items.Add(word);
            }
            wordsTextBox.Text = "";
            wordsTextBox.Focus();
        }

        private void addquestionButton_Click(object sender, EventArgs e)
        {
            var question = questionsTextBox.Text.Trim();
            if (question.Length != 0)
            {
                if (questionsList.Contains(question))
                    {
                        MessageBox.Show("Такой вопрос уже имеется");
                        questionsTextBox.Text = "";
                        return;
                    }
                questionsList.Add(question);
                questionsListView.Items.Add(question);
            }
            questionsTextBox.Text = "";
            questionsTextBox.Focus();
        }

        private void deletewordButton_Click(object sender, EventArgs e)
        {
            if (wordsListView.Items.Count > 0)
                wordsListView.Items.RemoveAt(wordsListView.Items.Count - 1);

            if (wordsList.Any())
            {
                wordsList.RemoveAt(wordsList.Count - 1);
            }
        }

        private void deletequestionButton_Click(object sender, EventArgs e)
        {
            if (questionsListView.Items.Count > 0)
                questionsListView.Items.RemoveAt(questionsListView.Items.Count - 1);

            if (questionsList.Any())
            {
                questionsList.RemoveAt(questionsList.Count - 1);
            }
        }
    }
}
