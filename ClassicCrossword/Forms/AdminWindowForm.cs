using System;
using System.Collections.Generic;
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
        public AdminWindowForm()
        {
            InitializeComponent();
        }

        private void редактироватьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        }
    }
}
