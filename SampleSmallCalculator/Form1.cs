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
            int intKey = (int)keyData;
            if (intKey >= 96 && intKey <= 105) // 96 = 0, 97 = 1, ..., 105 = 9
            {
                textBox1.Text = textBox1.Text + (intKey - 96).ToString();
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
