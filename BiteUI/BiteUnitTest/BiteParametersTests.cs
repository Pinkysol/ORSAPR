using NUnit.Framework;
using BiteSDK;

namespace BiteUnitTest
{    /// <summary>
     /// Класс хранит методы для тестирования BiteParameters
     /// </summary>
    [TestFixture]
    public class BiteParametersTests
    {
        private static BiteParameters DefaultParameters =>
            BiteParameters.DefaultParameters;

        #region [Positive tests]

        [TestCase(25, Parameter.BiteLength,
            TestName = "Позитивный - ввод длины биты")]
        [TestCase(3, Parameter.LengthOfStraight,
            TestName = "Позитивный - ввод длины прямой части")]
        [TestCase(15, Parameter.LengthOfStraightConnector,
            TestName = "Позитивный - ввод прямой соединительной части")]
        [TestCase(0.91, Parameter.WidthOfAdjoiningPart,
            TestName = "Позитивный - ввод Ширины прилегающей части носика")]
        [TestCase(5, Parameter.Diameter,
            TestName = "Позитивный - ввод диаметра")]
        public void TestParametersBite_CorrectSetValue(double correctValue, Parameter parameter)
        {
            // Arrange
            var biteParameters = DefaultParameters;
            var value = correctValue;
            var expected = correctValue;

            // Act
            var propertyInfo = typeof(BiteParameters).
                GetProperty(parameter.ToString());
            propertyInfo.SetValue(biteParameters, value);

            var actual = propertyInfo.GetValue(biteParameters);

            //Assert
            Assert.AreEqual(expected, actual, $"Значение {parameter} введено неверно.");
        }

        [TestCase(Parameter.BiteLength,
            "Значение параметра BiteLength" +
            " не вошло в диапазон",
            TestName = "Позитивный - проверка совпадения текста ошибки " +
                       "при вводе кол-во полок для объединения")]
        [TestCase(Parameter.LengthOfStraight,
            "Значение параметра LengthOfStraight не вошло в диапазон",
           TestName = "Позитивный - проверка совпадения текста ошибки" +
                      " при вводе высоты стеллажа")]
        [TestCase(Parameter.LengthOfStraightConnector,
            "Значение параметра LengthOfStraightConnector" +
            " не вошло в диапазон",
           TestName = "Позитивный - проверка совпадения текста ошибки " +
                      "при вводе высоты от пола до нижней полки")]
        [TestCase(Parameter.WidthOfAdjoiningPart,
            "Значение параметра WidthOfAdjoiningPart не вошло в диапазон",
           TestName = "Позитивный - проверка совпадения текста ошибки " +
                      "при вводе глубины стеллажа")]
        [TestCase(Parameter.Diameter,
            "Значение параметра Diameter не вошло в диапазон",
           TestName = "Позитивный - проверка совпадения текста ошибки " +
                      "при вводе ширины стеллажа")]

        public void TestGetErrors_HaveErrorsValue
            (Parameter parametersType, string errorText)
        {
            var biteParameters =
                new BiteParameters(1, 1,
                    1, 1, 1);

            var error =
                biteParameters.ErrorsDictionary[parametersType];
            var actual = error;

            Assert.AreEqual
                (errorText, actual, "Текст ошибки не совпадает");
        }

        [TestCase(TestName =
            "Позитивный - Отправить значения по умолчанию")]
        public void TestGetErrors_NoErrorsValue()
        {

            var biteParameters = DefaultParameters;
            var actual = biteParameters.ErrorsDictionary;

            Assert.IsEmpty(actual, "Словарь не пуст");
        }
        #endregion


    }
}