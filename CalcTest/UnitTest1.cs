using Xunit;
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
	}
}