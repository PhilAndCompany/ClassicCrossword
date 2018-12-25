using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassicCrossword.Forms;

namespace ClassicCrossword.Forms
{
    public partial class CrosswordSettings : Form
    {
        public int GridSizeHorizontal
        {
            get
            {
                return (Convert.ToInt32(gridSizeHorizontal.Value));
            }
            set
            {
                gridSizeHorizontal.Value = value;
            }
        }
        public int GridSizeVertical
        {
            get
            {
                return (Convert.ToInt32(gridSizeVertical.Value));
            }
            set
            {
                gridSizeVertical.Value = value;
            }
        }

        public CrosswordSettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dict";
            string initPath = @"..\..\Dict\";
            openFileDialog1.InitialDirectory = Path.GetFullPath(initPath);
            openFileDialog1.AddExtension = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Файл словаря (*.dict)|*.dict";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //это открытие диалогового окна и сигнал того что словарь выбран и нажат окич
            {/* todo сом щит хир плиз
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
            */}
        }
    

        private void applyButton_Click(object sender, EventArgs e)
        {
            AdminWindowForm.M = GridSizeHorizontal;
            AdminWindowForm.N = GridSizeVertical;
            //я конкретно поменял у себя Adminку поэтому сейчас смержим
            //TODO кстати просто чекни как работает кнопка СОЗДАТЬ в меню кроссворда, можно оттуда код взять и сюда всунуть
            //____________________________ то что снизу мб и не понадобится
            //todo закрасить клетки черным
            //todo убрать старый словарь и поставить новый
            //todo новый борд с заданными размерами, возможно даже не придется использовать строчки 60-61
            //и передавать это гавно в форму админа
            //todo изменить размеры грида в соответствии с M N
            Program.adminForm.clearDGV(Program.adminForm.DGV); //очистка слов с кроссворда
            //инициализация параши(кроссворда с новыми параметрами)
            this.Close();
            this.Dispose();
        }
    }
}
