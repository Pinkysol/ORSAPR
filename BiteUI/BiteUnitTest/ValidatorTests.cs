using System;
using NUnit.Framework;
using BiteSDK;

namespace BiteUnitTest
{
    /// <summary>
    /// класс тестирования валидатора
    /// </summary>
    [TestFixture]
    public class ValidatorTest
    {

        [TestCase(20, 25, 30,
            Parameter.BiteLength, TestName =
            "Негативный - ввод значений вне диапазона")]
        public void Validator_SetNegative(double incorrectValue,
            double minValue, double maxValue, Parameter parametersType)
        {

            Assert.Throws<ArgumentException>(() =>
                    BiteParameters.CheckParametersValue(minValue, maxValue,
                            incorrectValue, parametersType),
                $"Значение высоты стеллажа введено неверно.");

        }

        [TestCase(26, 25, 30,
            Parameter.BiteLength, TestName =
            "Позитивный - ввод значений в диапазоне")]
        public void Validator_SetPositive(double correctValue,
            double minValue, double maxValue, Parameter parametersType)
        {
            Assert.DoesNotThrow(() =>
                BiteParameters.CheckParametersValue(minValue, maxValue,
                correctValue, parametersType),
                $"значение вышло за пределы");
        }
    }

}
