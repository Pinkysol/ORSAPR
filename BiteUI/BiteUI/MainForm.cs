using System;
using System.Drawing;
using System.Windows.Forms;
using BiteSDK;
using BiteBuilder;

namespace BiteUI
{
    //TODO:
    public unsafe partial class MainForm : Form
    {
        /// <summary>
        /// Цвет TextBox при некорректном заполнении
        /// </summary>
        private readonly Color _incorrectInputColor = Color.Red;

        /// <summary>
        /// Текущие корректные параметры биты
        /// </summary>
        private BiteParameters _currentParameters =
            BiteParameters.DefaultParameters;

        public MainForm()
        {
            InitializeComponent();

        }
        //TODO: XML
        /// <summary>
        /// Метод для парса строки в double
        /// <pama>В случае неудачного парса выбрасывает исключение</pama>
        /// </summary>
        /// <param name="data">Текст, который требуется спарсить</param>
        /// <param name="parameterName">Текущий параметр</param>
        /// <returns></returns>
        private double DoubleParse(TextBox textBox, Parameter parameter)
        {
            try
            {
                double tmp = double.Parse(textBox.Text);
                textBox.BackColor = Color.White;
                return tmp;
            }
            catch 
            {
                textBox.BackColor = _incorrectInputColor;
                throw new ArgumentException($"Значение параметра {parameter}" +
                    $" может содержать только цифры и запятую");
            }
        }
        /// <summary>
        /// Обработчик события клик на кнопку Build,
        /// устанавливает количество отводов и
        /// запускает процесс построения 3D модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            _currentParameters =
                //TODO: RSDN
                       new BiteParameters(
                           DoubleParse(BiteLength, Parameter.BiteLength),
                           DoubleParse(LengthOfStraight, Parameter.LengthOfStraight),
                           DoubleParse(LengthOfStraightConnector, Parameter.LengthOfStraightConnector),
                           DoubleParse(WidthOfAdjoiningPart, Parameter.WidthOfAdjoiningPart),
                           DoubleParse(Diameter, Parameter.Diameter));
            try
            {
                if (_currentParameters.ErrorsDictionary.Count != 0)
                {
                    string message = null;
                    foreach (var param in
                        _currentParameters.ErrorsDictionary.Keys)
                    {
                        message +=
                           _currentParameters.ErrorsDictionary[param]
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
                //TODO: RSDN
                BiteModelBuilder _builder = new BiteModelBuilder();
                _builder.Assembly(_currentParameters);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TODO: XML
        private void SchemeButton_Click(object sender, EventArgs e)
        {
            var schemeForm = new SchemeForm();
            schemeForm.Show();
        }
    }
}
