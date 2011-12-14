namespace app.specs
{
    using Machine.Specifications;

    public class CalculatorSpecs
    {
        public class when_calculator_is_asked_to_add
        {
            It should_return_the_sum = () => Calculator.add(2, 3).ShouldEqual(5);
        }
    }
}