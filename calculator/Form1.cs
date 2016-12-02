using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator {
    enum stageType { operand1, modifier, operand2, equals }

    public partial class Form1 : Form {
        private float memory;

        private bool sign;
        private string firstNum;
        private string secondNum;
        private string myOperator;
        private float result;

        stageType stage;

        public Form1 () {
            InitializeComponent();

            stage = stageType.operand1;
            initCalculator();
            clearMemory();
        }
        private void initCalculator () {
            sign = true;

            firstNum = "0";
            secondNum = "0";
            result = 0.0f;

            stageType temp = stage;

            stage = stageType.equals;
            updateDisplay();
            stage = temp;
        }

        private void btnBackspace_Click (object sender, EventArgs e) {
            popEquation();
        }

        private void btnCE_Click (object sender, EventArgs e) {
            popEquation(-1);
        }

        private void btnC_Click (object sender, EventArgs e) {
            initCalculator();
        }

        private void btnMC_Click (object sender, EventArgs e) {
            clearMemory();
        }

        private void btnMR_Click (object sender, EventArgs e) {
            switch (stage) {
                case stageType.operand1:
                    firstNum = memory.ToString();
                    break;
                case stageType.operand2:
                    secondNum = memory.ToString();
                    break;
                case stageType.equals:
                    result = memory;
                    break;
                default:
                    break;
            }
            updateDisplay();
        }

        private void btnMS_Click (object sender, EventArgs e) {
            if (stage == stageType.modifier) return; //error, cannot store an operator
            try {
                memory = float.Parse(txtOutput.Text);
                txtM.Text = "M";
            } catch(Exception ex) {
                //do nothing
            }

        }

        private void btnMPlus_Click (object sender, EventArgs e) {
            switch (stage) {
                case stageType.operand1:
                    try {
                        memory += float.Parse(firstNum);
                    } catch (ArgumentNullException ex) {
                        //do nothing
                    }
                    break;
                case stageType.operand2:
                    try {
                        memory += float.Parse(secondNum);
                    } catch (ArgumentNullException ex) {
                        //do nothing
                    }
                    break;
                case stageType.equals:
                    try {
                        memory += result;
                    } catch (ArgumentNullException ex) {
                        //do nothing
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnDivide_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) {
                firstNum = result.ToString();
            }
            stage = stageType.modifier;
            addToEquation("/");
        }

        private void btnTimes_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) {
                firstNum = result.ToString();
            }
            stage = stageType.modifier;
            addToEquation("*");
        }

        private void btnMinus_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) {
                firstNum = result.ToString();
            }
            stage = stageType.modifier;
            addToEquation("-");
        }

        private void btnPlus_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) {
                firstNum = result.ToString();
                //secondNum = "";
            }
            stage = stageType.modifier;
            addToEquation("+");
        }

        private void btnSqrt_Click (object sender, EventArgs e) {
            double number;
            switch (stage) {
                case stageType.operand1:
                    firstNum = Math.Sqrt(double.Parse(firstNum)).ToString();
                    break;
                case stageType.operand2:
                    secondNum = Math.Sqrt(double.Parse(secondNum)).ToString();
                    break;
                case stageType.equals:
                    result = (float) Math.Sqrt(result);
                    break;
                default:
                    break;
            }
            updateDisplay();
        }

        private void btnPercent_Click (object sender, EventArgs e) {
            switch (stage) {
                case stageType.operand1:
                    firstNum = (float.Parse(firstNum) / 100).ToString();
                    break;
                case stageType.operand2:
                    secondNum = (float.Parse(secondNum) / 100).ToString();
                    break;
                case stageType.equals:
                    result = (result / 100);
                    break;
                default:
                    break;
            }
            updateDisplay();
        }

        private void btnInverse_Click (object sender, EventArgs e) {
            switch (stage) {
                case stageType.operand1:
                    firstNum = (1 / float.Parse(firstNum)).ToString();
                    break;
                case stageType.operand2:
                    secondNum = (1 / float.Parse(secondNum)).ToString();
                    break;
                case stageType.equals:
                    result = (result / 100);
                    break;
                default:
                    break;
            }
            updateDisplay();
        }

        private void btnEquals_Click (object sender, EventArgs e) {
            stage = stageType.equals;
            updateDisplay();
        }

        private void btn0_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("0");
        }

        private void btn1_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("1");
        }

        private void btn2_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("2");
        }

        private void btn3_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("3");
        }

        private void btn4_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("4");
        }

        private void btn5_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("5");
        }

        private void btn6_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("6");
        }

        private void btn7_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("7");
        }

        private void btn8_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("8");
        }

        private void btn9_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation("9");
        }

        private void btnReciprical_Click (object sender, EventArgs e) {
            switch (stage) {
                case stageType.operand1:
                    firstNum = (-float.Parse(firstNum)).ToString();
                    break;
                case stageType.operand2:
                    secondNum = (-float.Parse(secondNum)).ToString();
                    break;
                case stageType.equals:
                    result = (-result);
                    break;
                default:
                    break;
            }
            updateDisplay();
        }

        private void btnDecimal_Click (object sender, EventArgs e) {
            if (stage == stageType.equals) stage = stageType.operand1;
            if (stage == stageType.modifier) stage = stageType.operand2;
            addToEquation(".");
        }

        private void updateDisplay () {
            //calculate new result
            calculateResult();
            
            switch (stage) {
                case stageType.operand1:
                    txtOutput.Text = firstNum + " ";
                    break;
                case stageType.modifier:
                    txtOutput.Text = firstNum + " " + myOperator + " ";
                    break;
                case stageType.operand2:
                    txtOutput.Text = firstNum + " " + myOperator + " " + secondNum + " ";
                    break;
                case stageType.equals:
                    firstNum = "0";
                    secondNum = "0";
                    txtOutput.Text = result.ToString() + " ";
                    break;
                default:
                    break;
            }
        }

        private void calculateResult () {
            if (firstNum == null || secondNum == null || myOperator == null) {
                return; //error
            }

            switch (myOperator) {
                case "+":
                    result = float.Parse(firstNum) + float.Parse(secondNum);
                    break;
                case "-":
                    result = float.Parse(firstNum) - float.Parse(secondNum);
                    break;
                case "/":
                    result = float.Parse(firstNum) / float.Parse(secondNum);
                    if (float.IsInfinity(result)) result = 0.0f; //catch divide by zero exceptions
                    break;
                case "*":
                    result = float.Parse(firstNum) * float.Parse(secondNum);
                    break;
                default:
                    break; //error
            }
        }

        private void addToEquation (string token) {
            if (stage == stageType.operand1) {
                if (firstNum == "0") firstNum = null;
                firstNum += token;
                myOperator = null;
                secondNum = null;
            } else if (stage == stageType.operand2) {
                if (secondNum == "0") secondNum = null;
                secondNum += token;
            } else if (stage == stageType.modifier) {
                myOperator = token;
                secondNum = null;
            }
            updateDisplay();
        }

        private void popEquation (int amount = 1) {
            int number = new int();
            stageType temp = stage;
            if (stage == stageType.operand1) {
                try {
                    if (amount == -1) { firstNum = "0"; }
                    firstNum = firstNum.Substring(0, firstNum.Length - 1);
                    if (firstNum == null || firstNum.Length == 0) firstNum = "0";
                } catch (Exception ex) {
                    //do nothing
                }
            } else if (stage == stageType.operand2) {
                try {
                    if (amount == -1) { secondNum = "0"; }
                    secondNum = secondNum.Substring(0, secondNum.Length - 1);
                    if (secondNum == null || secondNum.Length == 0) secondNum = "0";
                } catch(Exception ex) {
                    //do nothing
                }
            } else if (stage == stageType.modifier) {
                myOperator = "";
            } else if(stage == stageType.equals) {
                initCalculator();
            }

            updateDisplay();
        }

        private void clearMemory () {
            memory = 0.0f;
            txtM.Text = "";
        }
    }
}
