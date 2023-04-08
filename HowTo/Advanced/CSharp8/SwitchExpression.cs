namespace CSharp8
{
    class SwitchExpression
    {
        public static double DoMathOld(double x, double y, MathType math)
        {
            switch (math) // switch statement
            {
                case MathType.Add:
                    return x + y;
                case MathType.Sub:
                    return x + y;
                case MathType.Div:
                    return x + y;
                case MathType.Mul:
                    return x + y;
                default:
                    throw new Exception("Bad input");
            }
        }

        public static double DoMathNew(double x, double y, MathType math)
        {
            double output = 0;

            output = math switch{ // switch expression
                MathType.Add => x + y,
                MathType.Sub => x - y,
                MathType.Div => x / y,
                MathType.Mul => x * y,
                _ => throw new Exception("Bad input")
            };

            return output;
        }

        public enum MathType
        {
            Add,
            Sub,
            Div,
            Mul
        }
    }
}