using System;
using System.Drawing;
using System.Windows.Forms;
using BiteSDK;
using BiteBuilder;

namespace BiteUI
{
    public unsafe partial class MainForm : Form
    {
        private
        Color _incorrectInputColor = Color.Red;
        Color _correctInputColor = Color.White;
        BiteModelBuilder _builder;
        BiteParameters _biteParameters = new BiteParameters();
        void CheckTextBoxes(TextBox textBox, Parameter parameter)
        {
            textBox.BackColor = _correctInputColor;

            if (textBox.Text == "")
            {
                return;
            }

            double value;
            if (!double.TryParse(textBox.Text, out value))
            {
                textBox.BackColor = _incorrectInputColor;
                return;
            }

            _biteParameters.SetValue(parameter, value);
            try
            {
                _biteParameters.CheckParametersValue(parameter);
            }
            catch (ArgumentException)
            {
                textBox.BackColor = _incorrectInputColor;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            _biteParameters.SetValue(Parameter.BiteLength, 25);
            BiteLength.Text = "25";
            _biteParameters.SetValue(Parameter.LengthOfStraight, 3);
            LengthOfStraight.Text = "3";
            _biteParameters.SetValue(Parameter.LengthOfStraightConnector, 15);
            LengthOfStraightConnector.Text = "15";
            _biteParameters.SetValue(Parameter.WidthOfAdjoiningPart, 0.91);
            WidthOfAdjoiningPart.Text = "0,91";
            _biteParameters.SetValue(Parameter.Diameter, 5);
            Diameter.Text = "5";
        }

        private void BiteLength_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BiteLength, "От 25 мм до 30 мм");
            CheckTextBoxes(BiteLength, Parameter.BiteLength);
        }

        private void LengthOfStraight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(LengthOfStraight, "от 3 мм до 4 мм, больше 2/15 от L и меньше 3/25 от L");
            CheckTextBoxes(LengthOfStraight, Parameter.LengthOfStraight);

        }

        private void LengthOfStraightConnector_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(LengthOfStraightConnector, "от 15 мм до 20 мм, меньше L на 10 мм");
            CheckTextBoxes(LengthOfStraightConnector, Parameter.LengthOfStraightConnector);

        }

        private void WidthOfAdjoiningPart_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(WidthOfAdjoiningPart, "от 0.91 мм до 0.95 мм");
            CheckTextBoxes(WidthOfAdjoiningPart, Parameter.WidthOfAdjoiningPart);

        }

        private void Diameter_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Diameter, "от 5 мм до 6 мм");
            CheckTextBoxes(Diameter, Parameter.Diameter);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new SchemeForm();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (_biteParameters.ErrorsDictionary.Count != 0)
                {
                    string message = null;
                    foreach (var param in
                        _biteParameters.ErrorsDictionary.Keys)
                    {
                        message +=
                           _biteParameters.ErrorsDictionary[param]
                           + "\n";
                        string textboxname = param.ToString();
                        TextBox textBox =
                             Controls.Find(textboxname, false)[0]
                            as TextBox;
                        textBox.BackColor = _incorrectInputColor;
                    }
                    MessageBox.Show(
                       message,
                       "Ошибка ввода",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                    );
                    return;
                }

                _builder = new BiteModelBuilder();
                _builder.Assembly(_biteParameters);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
