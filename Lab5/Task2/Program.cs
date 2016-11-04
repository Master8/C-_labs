using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<double, double>> source = x => (10 * x + Math.Sin(x)) * x;

            Func<double, double> f = Differentiate(source);

            Console.WriteLine(f(12));
        }

        static Func<double, double> Differentiate(Expression<Func<double, double>> expression)
        {
            return Expression.Lambda<Func<double, double>>(Convert(expression.Body), expression.Parameters).Compile();
        }

        static Expression Convert(Expression expression)
        {
            if (expression is ConstantExpression)
            {
                return Expression.Constant(0.0);
            }
            else if (expression is ParameterExpression)
            {
                return Expression.Constant(1.0);
            }
            else if (expression is BinaryExpression)
            {
                var binaryExpression = (BinaryExpression)expression;
                var left = binaryExpression.Left;
                var right = binaryExpression.Right;

                if (binaryExpression.NodeType == ExpressionType.Add)
                {
                    return Expression.Add(Convert(left), Convert(right));
                }
                else if (binaryExpression.NodeType == ExpressionType.Multiply)
                {
                    var result = Expression.Add(
                        Expression.Multiply(
                            Convert(left),
                            right),
                        Expression.Multiply(
                            left,
                            Convert(right)));

                    return result;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (expression is MethodCallExpression)
            {
                var methodCallExpression = (MethodCallExpression)expression;

                if (methodCallExpression.Method.Name == "Sin")
                {
                    var result = Expression.Call(
                        typeof(Math).GetMethod("Cos"),
                        methodCallExpression.Arguments);

                    return result;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
