using NUnit.Framework;
using BiteSDK;

namespace BiteUnitTest
{    /// <summary>
     /// ����� ������ ������ ��� ������������ BiteParameters
     /// </summary>
    [TestFixture]
    public class BiteParametersTests
    {
        private static BiteParameters DefaultParameters =>
            BiteParameters.DefaultParameters;

        #region [Positive tests]
        //TODO: UTF8?
        [TestCase(25, Parameter.BiteLength,
            TestName = "���������� - ���� ����� ����")]
        [TestCase(3, Parameter.LengthOfStraight,
            TestName = "���������� - ���� ����� ������ �����")]
        [TestCase(15, Parameter.LengthOfStraightConnector,
            TestName = "���������� - ���� ������ �������������� �����")]
        [TestCase(0.91, Parameter.WidthOfAdjoiningPart,
            TestName = "���������� - ���� ������ ����������� ����� ������")]
        [TestCase(5, Parameter.Diameter,
            TestName = "���������� - ���� ��������")]
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
            Assert.AreEqual(expected, actual, $"�������� {parameter} ������� �������.");
        }

        [TestCase(Parameter.BiteLength,
            "�������� ��������� BiteLength" +
            " �� ����� � ��������",
            TestName = "���������� - �������� ���������� ������ ������ " +
                       "��� ����� ���-�� ����� ��� �����������")]
        [TestCase(Parameter.LengthOfStraight,
            "�������� ��������� LengthOfStraight �� ����� � ��������",
           TestName = "���������� - �������� ���������� ������ ������" +
                      " ��� ����� ������ ��������")]
        [TestCase(Parameter.LengthOfStraightConnector,
            "�������� ��������� LengthOfStraightConnector" +
            " �� ����� � ��������",
           TestName = "���������� - �������� ���������� ������ ������ " +
                      "��� ����� ������ �� ���� �� ������ �����")]
        [TestCase(Parameter.WidthOfAdjoiningPart,
            "�������� ��������� WidthOfAdjoiningPart �� ����� � ��������",
           TestName = "���������� - �������� ���������� ������ ������ " +
                      "��� ����� ������� ��������")]
        [TestCase(Parameter.Diameter,
            "�������� ��������� Diameter �� ����� � ��������",
           TestName = "���������� - �������� ���������� ������ ������ " +
                      "��� ����� ������ ��������")]

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
                (errorText, actual, "����� ������ �� ���������");
        }

        [TestCase(TestName =
            "���������� - ��������� �������� �� ���������")]
        public void TestGetErrors_NoErrorsValue()
        {

            var biteParameters = DefaultParameters;
            var actual = biteParameters.ErrorsDictionary;

            Assert.IsEmpty(actual, "������� �� ����");
        }
        #endregion


    }
}