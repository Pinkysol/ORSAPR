using System;
using System.Collections.Generic;

namespace BiteSDK
{
    //TODO: XML
    /// <summary>
    /// публичный класс предназначенный для хранения 
    /// и выполнения валидации нижнего уровня
    /// </summary>
    public class BiteParameters
    {
        /// <summary>
        /// Длина биты
        /// <summary>
        private double _biteLength;
        /// <summary>
        /// Длина прямой части
        /// <summary>
        private double _lengthOfStraight;
        /// <summary>
        /// Длина прямой соединительной части
        /// <summary>
        private double _lengthOfStraightConnector;
        /// <summary>
        /// Ширина прилегающей части носика
        /// <summary>
        private double _widthOfAdjoiningPart;
        /// <summary>
        /// Диаметр
        /// <summary>
        private double _diameter;
        /// <summary>
        /// словарь для хранения ошибок ввода
        /// </summary>
        public Dictionary<Parameter, string> ErrorsDictionary { get; }
            = new Dictionary<Parameter, string>();

        /// <summary>
        /// установка значений по умолчанию 
        /// для проектируемой 3D-модели биты
        /// </summary>
        public static BiteParameters DefaultParameters =>
            new(25, 3, 15, 0.91, 5);


        /// <summary>
        /// свойство обрабатывающее поле 
        /// Длины биты,
        /// содержит валидацию допустимых значений 
        /// </summary>
        public double BiteLength
        {
            get => _biteLength;

            set
            {
                const double minValue = 25;
                const double maxValue = 30;
                SetValue(ref _biteLength, value,
                    minValue, maxValue, Parameter.BiteLength);
            }
        }

        /// <summary>
        /// свойство обрабатывающее поле 
        /// Длины прямой части,
        /// содержит валидацию допустимых значений 
        /// </summary>
        public double LengthOfStraight
        {
            get => _lengthOfStraight;

            set
            {
                //TODO:
                const double minMultipiler = 3;
                const double maxMultipiler = 4;
                SetValue(ref _lengthOfStraight, value, minMultipiler,
                    maxMultipiler, Parameter.LengthOfStraight);
            }
        }

        /// <summary>
        /// свойство обрабатывающее поле 
        /// Длины прямой соединительной части,
        /// содержит валидацию допустимых значений 
        /// </summary>
        public double LengthOfStraightConnector
        {
            get => _lengthOfStraightConnector;

            set
            {
                //TODO:
                const int range = 10;
                SetValue(ref _lengthOfStraightConnector, value,
                    BiteLength - range, BiteLength - range, Parameter.LengthOfStraightConnector);
            }
        }

        /// <summary>
        /// свойство обрабатывающее поле 
        /// Ширины прилегающей части носика,
        /// содержит валидацию допустимых значений 
        /// </summary>
        public double WidthOfAdjoiningPart
        {
            get => _widthOfAdjoiningPart;

            set
            {
                const double minValue = 0.91;
                const double maxValue = 0.95;
                SetValue(ref _widthOfAdjoiningPart, value,
                    minValue, maxValue, Parameter.WidthOfAdjoiningPart);
            }
        }

        /// <summary>
        /// свойство обрабатывающее поле 
        /// Диаметра,
        /// содержит валидацию допустимых значений 
        /// </summary>
        public double Diameter
        {
            get => _diameter;

            set
            {
                const double minValue = 5;
                const double maxValue = 6;
                SetValue(ref _diameter, value, minValue, maxValue,
                    Parameter.Diameter);
            }
        }

        /// <summary>
        /// Устанавливает значение в требуемое свойство
        /// </summary>
        /// <param name="property">зачение которое будет занесено</param>
        /// <param name="value">Текущее значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="parameter">Название параметра</param>
        public void SetValue(ref double property, double value,
            double minValue, double maxValue, Parameter parameter)
        {
            try
            {
                CheckParametersValue(minValue, maxValue,
                    value, parameter);
                property = value;
            }
            catch (Exception ex)
            {
                ErrorsDictionary.Add(parameter,
                    ex.Message);
            }
        }

        /// <summary>
        /// конструктор класса, присваивающий значения
        /// </summary>
        /// <param name="biteLength">Длина биты</param>
        /// <param name="lengthOfStraight">Длина прямой части</param>
        /// <param name="lengthOfStraightConnector">Длина прямой 
        /// соединительной части</param>
        /// <param name="widthOfAdjoiningPart">Ширина прилегающей 
        /// части носика</param>
        /// <param name="diameter">Диаметр</param>
        public BiteParameters(double biteLength, double lengthOfStraight,
    double lengthOfStraightConnector, double widthOfAdjoiningPart, double diameter)
        {
            ErrorsDictionary.Clear();
            BiteLength = biteLength;
            LengthOfStraight = lengthOfStraight;
            LengthOfStraightConnector = lengthOfStraightConnector;
            WidthOfAdjoiningPart = widthOfAdjoiningPart;
            Diameter = diameter;
        }
        /// <summary>
        /// Статический метод, выполняющий проверку на соответствие 
        /// значения заданного диапозону
        /// <para> Если значение не прошло валидацию, выбрасывает
        /// исключение </para>
        /// </summary>
        /// <param name="minValue">Минималное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="value">Текущее значение</param>
        /// <param name="parameter">Проверяемый параметр</param>
        ///  /// <exception cref="ArgumentException">исключение вызываемое при 
        /// несоответсвии заданного значения диапазону</exception>
        public static void CheckParametersValue(double minValue,
            double maxValue, double value, Parameter parameter)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException
                    ($"Значение параметра {parameter}" +
                    $" не вошло в диапазон");
            }
        }
    }

    //TODO: RSDN
    public enum Parameter
    {
        /// <summary>
        /// Длина биты
        /// </summary>
        BiteLength,
        /// <summary>
        /// Длина прямой части
        /// </summary>
        LengthOfStraight,
        /// <summary>
        /// Длина прямой соединительной части
        /// </summary>
        LengthOfStraightConnector,
        /// <summary>
        /// Ширина прилегающей части носика
        /// </summary>
        WidthOfAdjoiningPart,
        /// <summary>
        /// Диаметр
        /// </summary>
        Diameter
    }
}
