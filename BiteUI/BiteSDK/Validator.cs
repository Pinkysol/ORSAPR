using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteSDK
{
    //TODO: XML
    public static class Validator
    {
        //TODO:
        /// <summary>
        /// Статический метод, выполняющий проверку на соответствие 
        /// значения заданного диапозону
        /// <para> Если значение не прошло валидацию, выбрасывает
        /// исключение </para>
        /// </summary>
        /// <param name="minValue">Минималное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="currentValue">Текущее значение</param>
        /// <param name="parameter">Проверяемый параметр</param>
        ///  /// <exception cref="ArgumentException">исключение вызываемое при 
        /// несоответсвии заданного значения диапазону</exception>
        public static void CheckParametersValue(double minValue,
            double maxValue, double value, Parameter parametersType)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException
                    ($"Значение параметра {parametersType}" +
                    $" не вошло в диапазон");
            }
        }
    }
}
