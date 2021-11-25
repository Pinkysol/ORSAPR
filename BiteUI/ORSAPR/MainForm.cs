using System;
using System.Drawing;
using System.Windows.Forms;

namespace ORSAPR
{
    public unsafe partial class MainForm : Form
    {
        private
        BiteParameters _biteParameters = new BiteParameters();
        void CheckTextBoxes(TextBox textBox, Parameter parameter)
        {
            textBox.BackColor = Color.White;

            if (textBox.Text == "")
            {
                return;
            }

            double value;
            if (!double.TryParse(textBox.Text, out value))
            {
                textBox.BackColor = Color.Red;
                return;
            }

            _biteParameters.SetValue(parameter, value);
            try
            {
                Validator.CheckParametersValue(parameter, _biteParameters);
            }
            catch (ArgumentException)
            {
                textBox.BackColor = Color.Red;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            _biteParameters.SetValue(Parameter.BiteLength, 25);
            textBox1.Text = "25";
            _biteParameters.SetValue(Parameter.LengthOfStraight, 3);
            textBox2.Text = "3";
            _biteParameters.SetValue(Parameter.LengthOfStraightConnector, 15);
            textBox3.Text = "15";
            _biteParameters.SetValue(Parameter.WidthOfAdjoiningPart, 0.91);
            textBox4.Text = "0,91";
            _biteParameters.SetValue(Parameter.Width, 0.45);
            textBox5.Text = "0,45";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "От 25 мм до 30 мм");
            CheckTextBoxes(textBox1, Parameter.BiteLength);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "от 3 мм до 4 мм, больше 2/15 от L и меньше 3/25 от L");
            CheckTextBoxes(textBox2, Parameter.LengthOfStraight);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "от 15 мм до 20 мм, меньше L на 10 мм");
            CheckTextBoxes(textBox3, Parameter.LengthOfStraightConnector);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "от 0.91 мм до 0.95 мм");
            CheckTextBoxes(textBox4, Parameter.WidthOfAdjoiningPart);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox5, "от 0.45 мм до 0.5 мм");
            CheckTextBoxes(textBox5, Parameter.Width);

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
