using System;
using System.Linq.Expressions;

namespace Derivation
{
    public class Derivator
    {
        public static Func<double, double> Derivate(Expression<Func<double, double>> sourceFunc)
        {
            var simplified = Simplify(sourceFunc);
            return simplified.Compile();
        }

        public static Expression<Func<double, double>> Simplify(Expression<Func<double, double>> sourceFunc)
        {
            if (sourceFunc.Body is BinaryExpression)
            {
                var expression = (BinaryExpression) sourceFunc.Body;
            }

            return sourceFunc;
        }
    }
}
