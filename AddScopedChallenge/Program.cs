using Autofac;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        //Your Code for registering goes here...
    }
}

class Calculator : ICalculator
{
    private readonly ILogger _logger;
    //Your constructors and methods

}

class UserInput
{
    private readonly ICalculator _calculator;
   //Your constructor and methods
}

interface ICalculator
{
    //Definition of Interface
}

interface ILogger
{
    //Definition of Interface
}

class ConsoleLogger : ILogger
{
    //Your logging method
}
