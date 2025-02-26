using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	public class ReversePolishCalculator
	{
		public double Evaluate(string expression)
		{
			string[] tokens = expression.Split([' '], StringSplitOptions.RemoveEmptyEntries);
			Stack<double> stack = new Stack<double>();

			foreach (string token in tokens)
			{
				if (double.TryParse(token, out double num))
				{
					stack.Push(num);
				}
				else
				{
					double b = stack.Pop();
					double a = stack.Pop();

					switch (token)
					{
						case "+": stack.Push(a + b); break;
						case "-": stack.Push(a - b); break;
						case "*": stack.Push(a * b); break;
						case "/":
							if (b == 0) throw new DivideByZeroException();
							stack.Push(a / b);
							break;
						default:
							throw new InvalidOperationException($"Неизвестный оператор: {token}");
					}
				}
			}

			return stack.Pop();
		}
	}
}
