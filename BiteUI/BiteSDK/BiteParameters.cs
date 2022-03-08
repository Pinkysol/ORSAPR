using System;
using System.Collections.Generic;

namespace BiteSDK
{
    public class BiteParameters
    {
        private double _biteLength;
        private double _lengthOfStraight;
        private double _lengthOfStraightConnector;
        private double _widthOfAdjoiningPart;
        private double _diameter;
        public Dictionary<Parameter, string> ErrorsDictionary { get; }
    = new Dictionary<Parameter, string>();
        static void Main ()
        {

        }
        public void SetValue(Parameter parameter, double value)
        {
            switch (parameter)
            {
                case Parameter.BiteLength:
                    {
                        _biteLength = value;
                        break;
                    }
                case Parameter.LengthOfStraight:
                    {
                        _lengthOfStraight = value;
                        break;
                    }
                case Parameter.LengthOfStraightConnector:
                    {
                        _lengthOfStraightConnector = value;
                        break;
                    }
                case Parameter.WidthOfAdjoiningPart:
                    {
                        _widthOfAdjoiningPart = value;
                        break;
                    }
                case Parameter.Diameter:
                    {
                        _diameter = value;
                        break;
                    }

            }
        }
        public double GetBiteLength()
        {
            return this._biteLength;
        }
        public double GetLengthOfStraight()
        {
            return this._lengthOfStraight;
        }
        public double GetLengthOfStraightConnector()
        {
            return this._lengthOfStraightConnector;
        }
        public double GetWidthOfAdjoiningPart()
        {
            return this._widthOfAdjoiningPart;
        }
        public double GetDiameter()
        {
            return this._diameter;
        }
        public bool CheckParametersValue(Parameter parameter)
        {
            switch (parameter)
            {
                case Parameter.BiteLength:
                    {
                        if (this.GetBiteLength() < 25)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetBiteLength() > 30)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        return true;
                    }

                case Parameter.LengthOfStraight:
                    {
                        if (this.GetLengthOfStraight() < 3)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetLengthOfStraight() > 4)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetLengthOfStraight() > (2 * this.GetBiteLength()) / 15)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetLengthOfStraight() < (3 * this.GetBiteLength()) / 25)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        return true;
                    }

                case Parameter.LengthOfStraightConnector:
                    {
                        if (this.GetLengthOfStraightConnector() < 15)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetLengthOfStraightConnector() > 20)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetLengthOfStraightConnector() != this.GetBiteLength() - 10)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        return true;
                    }
                case Parameter.WidthOfAdjoiningPart:
                    {
                        if (this.GetWidthOfAdjoiningPart() < 0.91)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetWidthOfAdjoiningPart() > 0.95)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        return true;
                    }
                case Parameter.Diameter:
                    {
                        if (this.GetDiameter() < 5)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        if (this.GetDiameter() > 6)
                        {
                            throw new ArgumentException("incorrect value");
                        }
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

    }

    public enum Parameter
    {
        BiteLength = 1,
        LengthOfStraight = 2,
        LengthOfStraightConnector = 3,
        WidthOfAdjoiningPart = 4,
        Diameter = 5
    }
}
