

namespace ORSAPR
{
    public class BiteParameters
    {
        private double _biteLength;
        private double _lengthOfStraight;
        private double _lengthOfStraightConnector;
        private double _widthOfAdjoiningPart;
        private double _width;
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
                case Parameter.Width:
                    {
                        _width = value;
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
            return this ._lengthOfStraightConnector;
        }
        public double GetWidthOfAdjoiningPart()
        {
            return this._widthOfAdjoiningPart ;
        }
        public double GetWidth()
        {
            return this._width ;
        }

    }

    public enum Parameter
    {
        BiteLength = 1,
        LengthOfStraight = 2,
        LengthOfStraightConnector = 3,
        WidthOfAdjoiningPart = 4,
        Width = 5
    }
}
