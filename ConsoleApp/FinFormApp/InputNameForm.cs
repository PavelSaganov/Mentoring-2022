using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class InputNameForm : Form
    {
        public InputNameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutputHelloForm outputHelloForm = new OutputHelloForm (NameTextBox.Text);
            outputHelloForm.ShowDialog(this);
        }
    }
}
