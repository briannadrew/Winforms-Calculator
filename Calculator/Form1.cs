using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double total = 0; // keep running total
        private bool isNewNum = true; // whether a new number is being entered
        private string op = ""; // to store the current operation
        public Calculator()
        {
            InitializeComponent();
        }

        /* NUMBER BUTTONS */
        private void NumClick(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get button clicked
            if (OutputBox.Text == "0" || isNewNum) // if the current display is 0 or we are entering a new number
            {
                OutputBox.Text = ""; // clear display
                isNewNum = false;
            }
            if (button.Text == ".")
            {
                if (!OutputBox.Text.Contains(".")) // do not allow multiple decimal points in the same number
                {
                    OutputBox.Text += button.Text; // add digit to the end of the number
                }
            } else
            {
                OutputBox.Text += button.Text; // add digit to the end of the number
            }
        }

        /* OPERATOR BUTTONS */
        private void OpClick(object sender, EventArgs e)
        {
            if (op != "") // if not first number in an equation, make the calculation
            {
                Compute();
            }
            else
            {
                total += Convert.ToDouble(OutputBox.Text); // add to the running total
            }
            Button button = (Button)sender; // get button clicked
            op = button.Text; // set current operator
            isNewNum = true;
        }

        /* MAKE A CALCULATION */
        private void Compute()
        {
            double inputVal = Convert.ToDouble(OutputBox.Text); // get most recent number entered
            switch (op)
            {
                case "+": // perform addition and display result
                    total += inputVal;
                    OutputBox.Text = total.ToString();
                    break;
                case "-": // perform subtraction and display result
                    total -= inputVal;
                    OutputBox.Text = total.ToString();
                    break;
                case "x": // perform multipication and display result
                    total *= inputVal;
                    OutputBox.Text = total.ToString();
                    break;
                case "÷": // perform division and display result
                    if (inputVal != 0)
                    {
                        total /= inputVal;
                        OutputBox.Text = total.ToString();
                    } else // throw error if trying to divide by 0
                    {
                        OutputBox.Text = "ERROR";
                        return;
                    }
                    break;
                default: break;
            }
        }

        /* CLEAR BUTTON */
        private void BttnCl_Click(object sender, EventArgs e)
        {
            // reset display and all variables
            OutputBox.Text = "0";
            isNewNum = true;
            total = 0;
            op = "";
        }

        /* EQUALS BUTTON */
        private void BttnEq_Click(object sender, EventArgs e)
        {
            Compute(); // perform the calculation and reset
            op = "";
            isNewNum = true;
        }

        /* PERCENT BUTTON */
        private void BttnPer_Click(object sender, EventArgs e)
        {
            if (OutputBox.Text != "0")
            {
                double inputVal = Convert.ToDouble(OutputBox.Text);
                OutputBox.Text = (inputVal / 100).ToString(); // convert current number into a percentage
            }
        }

        /* PLUS-MINUS BUTTON */
        private void BttnPM_Click(object sender, EventArgs e)
        {
            if (OutputBox.Text != "0")
            {
                double inputVal = Convert.ToDouble(OutputBox.Text);
                OutputBox.Text = Convert.ToString(-1 * inputVal); // toggle negative/positive for current number
            }
        }
    }
}
