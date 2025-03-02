using System.Globalization;

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
				if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
				{
					stack.Push(num);
				}
				else
				{
					if (stack.Count < 2)
						throw new InvalidOperationException($"Недостаточно операндов для оператора '{token}'");

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
						case "^":
							stack.Push(Math.Pow(a, b));
							break;
						default:
							throw new InvalidOperationException($"Неизвестный оператор: {token}");
					}
				}
			}

			if (stack.Count != 1)
				throw new InvalidOperationException("Некорректное выражение");

			return stack.Pop();
		}
	}
}