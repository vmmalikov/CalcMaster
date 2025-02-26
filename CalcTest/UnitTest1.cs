using Calc;

namespace CalcTest
{
	public class UnitTest1
	{
		private readonly ReversePolishCalculator calculator = new ReversePolishCalculator();

		[Theory]
		[InlineData("3 4 +", 7)]
		[InlineData("5 3 -", 2)]
		[InlineData("2 3 *", 6)]
		[InlineData("6 2 /", 3)]
		public void Evaluate_SimpleOperations_ReturnsCorrectResult(string expr, double expected)
		{
			double result = calculator.Evaluate(expr);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("3 4 + 2 *", 14)]
		[InlineData("8 4 / 2 +", 4)]
		public void Evaluate_TwoOperations_ReturnsCorrectResult(string expr, double expected)
		{
			double result = calculator.Evaluate(expr);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("15 7 1 1 + - / 3 * 2 1 1 + + -", 5)]
		[InlineData("2 3 4 + * 5 -", 9)]
		[InlineData("5 1 2 + 4 * + 3 -", 14)]
		public void Evaluate_ComplexExpressions_ReturnsCorrectResult(string expr, double expected)
		{
			double result = calculator.Evaluate(expr);
			Assert.Equal(expected, result);
		}

		[Fact]
		public void Evaluate_DivisionByZero_ThrowsException()
		{
			Assert.Throws<DivideByZeroException>(() => calculator.Evaluate("5 0 /"));
		}
	}
}