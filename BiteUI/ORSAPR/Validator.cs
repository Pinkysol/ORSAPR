using System;
using System.Drawing;
using System.Windows.Forms;

namespace ORSAPR
{
    static class Validator
    {
         static public unsafe bool CheckParametersValue(Parameter parameter, BiteParameters biteParameters)
         {
            switch(parameter)
            {
                case Parameter.BiteLength:
                {
                    if (biteParameters.GetBiteLength() < 25)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetBiteLength() > 30)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    return true;
                }

                case Parameter.LengthOfStraight:
                {
                    if (biteParameters.GetLengthOfStraight() < 3)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetLengthOfStraight() > 4)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetLengthOfStraight() > (2 * biteParameters.GetBiteLength())/ 15)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetLengthOfStraight() < (3 * biteParameters.GetBiteLength())/ 25)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    return true;
                }

                case Parameter.LengthOfStraightConnector:
                {
                    if(biteParameters.GetLengthOfStraightConnector() < 15)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetLengthOfStraightConnector() > 20)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetLengthOfStraightConnector() != biteParameters.GetBiteLength() - 10)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    return true;
                }
                case Parameter.WidthOfAdjoiningPart:
                {   
                    if (biteParameters.GetWidthOfAdjoiningPart() < 0.91)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetWidthOfAdjoiningPart() > 0.95)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    return true;
                }
                case Parameter.Width:
                {
                    if (biteParameters.GetWidth() < 0.45)
                    {
                        throw new ArgumentException("incorrect value");
                    }
                    if (biteParameters.GetWidth() > 0.5)
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
}
