using System;
using System.Collections.Generic;

namespace BiteSDK
{
    //TODO: XML
    public class BiteParameters
    {
        private double _biteLength;
        private double _lengthOfStraight;
        private double _lengthOfStraightConnector;
        private double _widthOfAdjoiningPart;
        private double _diameter;
        public Dictionary<Parameter, string> ErrorsDictionary { get; }
            = new Dictionary<Parameter, string>();
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
        /// установка значений по умолчанию 
        /// для проектируемой 3D-модели стеллажа 
        /// </summary>
        public static BiteParameters DefaultParameters =>
            new(25, 3, 15, 0.91, 5);
        public double LengthOfStraight
        {
            get => _lengthOfStraight;

            set
            {
                //TODO:
                SetValue(ref _lengthOfStraight, value, 3 * BiteLength / 25,
                    2 * BiteLength / 15, Parameter.LengthOfStraight);
            }
        }

        public double LengthOfStraightConnector
        {
            get => _lengthOfStraightConnector;

            set
            {
                //TODO:
                SetValue(ref _lengthOfStraightConnector, value,
                    BiteLength - 10, BiteLength - 10, Parameter.LengthOfStraightConnector);
            }
        }

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
        /// <param name="field">Текущее свойство</param>
        /// <param name="value">Текущее значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="parameter">Название параметра</param>
        public void SetValue(ref double property, double value,
            double minValue, double maxValue, Parameter parameter)
        {
            try
            {
                Validator.CheckParametersValue(minValue, maxValue,
                    value, parameter);
                property = value;
            }
            catch (Exception ex)
            {
                ErrorsDictionary.Add(parameter,
                    ex.Message);
            }
        }
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
        LengthOfStraightConnector,
        WidthOfAdjoiningPart,
        Diameter
    }
}
