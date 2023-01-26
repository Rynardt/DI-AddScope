// See https://aka.ms/new-console-template for more information
using Autofac;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ConsoleLogger>().As<ILogger>().InstancePerLifetimeScope();
        builder.RegisterType<Calculator>().As<ICalculator>();
        var container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var userInput = scope.Resolve<UserInput>();
            userInput.GetInputAndPrintResult();
        }
    }
}

class Calculator : ICalculator
{
    private readonly ILogger _logger;
    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int num1, int num2)
    {
        _logger.Log("Adding numbers...");
        return num1 + num2;
    }
}

class UserInput
{
    private readonly ICalculator _calculator;
    public UserInput(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public void GetInputAndPrintResult()
    {
        Console.Write("Enter first number: ");
        var num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        var num2 = int.Parse(Console.ReadLine());

        var result = _calculator.Add(num1, num2);
        Console.WriteLine("Result: " + result);
    }
}

interface ICalculator
{
    int Add(int num1, int num2);
}

interface ILogger
{
    void Log(string message);
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
