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
            {
                textBox1.Text = openFileDialog1.FileName;
                Program.adminForm.chooseVocabulary(openFileDialog1);

            }
        }
    

        private void applyButton_Click(object sender, EventArgs e)
        {
            AdminWindowForm.M = GridSizeHorizontal;
            AdminWindowForm.N = GridSizeVertical;
            //я конкретно поменял у себя Adminку поэтому сейчас смержим
            //TODO кстати просто чекни как работает кнопка СОЗДАТЬ в меню кроссворда, можно оттуда код взять и сюда всунуть
            //____________________________ то что снизу мб и не понадобится дальше сам
            //todo закрасить клетки черным
            //todo убрать старый словарь и поставить новый
            //todo новый борд с заданными размерами, возможно даже не придется использовать строчки 60-61
            //и передавать это гавно в форму админа
            //todo изменить размеры грида в соответствии с M N
            //Program.adminForm.clearDGV(Program.adminForm.DGV); //очистка слов с кроссворда
            Program.adminForm.deleteGrid();
            Program.adminForm.fillGrid(AdminWindowForm.M, AdminWindowForm.N);
            if (manualRadioButton.Checked != true) { Program.adminForm.GenerateCrossword(); }
            else { }
            Program.adminForm.dictShow();
            //инициализация параши(кроссворда с новыми параметрами)
            this.Close();
            this.Dispose();
        }
    }
}
