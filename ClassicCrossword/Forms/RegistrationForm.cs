using ClassicCrossword.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword.Forms
{
    public partial class RegistrationForm : Form
    {
        UserController usrController;

        public RegistrationForm()
        {
            InitializeComponent();
            this.ActiveControl = tbLogin;
            usrController = new UserController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
