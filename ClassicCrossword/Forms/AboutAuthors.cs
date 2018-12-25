using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword.Forms
{
    public partial class AboutAuthors : Form
    {
        public AboutAuthors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/callmealexius");
        }

        private void buttonVK2_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/philatov182");
        }

        private void buttonVK3_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/rspzd");
        }
    }
}
