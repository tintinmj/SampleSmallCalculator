using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSmallCalculator
{
    public partial class formCalc : Form
    {
        private double operandOne;
        public formCalc()
        {
            InitializeComponent();
        }

        private void number_button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + "" + button.Text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operandOne = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.NumPad0 |
                Keys.NumPad1 |
                Keys.NumPad2 |
                Keys.NumPad3 |
                Keys.NumPad4 |
                Keys.NumPad5 |
                Keys.NumPad6 |
                Keys.NumPad7 |
                Keys.NumPad8 |
                Keys.NumPad9))
            {

                // also not sure about the KeyEventArgs(keyData)... is it ok?
                number_button_Click(keyData, new KeyEventArgs(keyData));
                return true;

            }

            else if (keyData == (Keys.Add))
            {
                btnPlus_Click(keyData, new KeyEventArgs(keyData));
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double operanTwo = double.Parse(textBox1.Text);
            textBox1.Text = "";
            operandOne = operandOne + operanTwo;
            textBox1.Text = "" + operandOne;
        }
    }
}
