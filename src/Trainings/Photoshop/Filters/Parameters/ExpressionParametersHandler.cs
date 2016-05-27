using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyPhotoshop
{
    public class ExpressionParametersHandler<TParameters> : IParametersHandler<TParameters> where TParameters : IParameters, new()
    {
        private static readonly ParameterInfo[] _descriptions;

        private static readonly Func<double[], TParameters> _parser;

        static ExpressionParametersHandler()
        {
            var properties = typeof (TParameters)
                .GetProperties()
                .Where(i => i.GetCustomAttributes(typeof (ParameterInfo), false).Length != 0)
                .ToArray();

            var arg = Expression.Parameter(typeof (double[]), "values");

            var bindings = properties
                .Select((property, i) => Expression.Bind(property, Expression.ArrayIndex(arg, Expression.Constant(i))))
                .Cast<MemberBinding>()
                .ToArray();

            var body = Expression.MemberInit(Expression.New(typeof (TParameters).GetConstructor(new Type[0])), bindings);

            var lambda = Expression.Lambda<Func<double[], TParameters>>(body, arg);

            _parser = lambda.Compile();
        }

        public ParameterInfo[] Description()
        {
            return _descriptions;
        }

        public TParameters CreateParameters(double[] values)
        {
            return _parser(values);
        }
    }
}