// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text;

Console.Title = "adding two numbers";

double firstNumber = 0, secondNumber = 0;

void InputNumber(out double variable)
{
    bool corectType = false;
    variable = 0;

    while (!corectType)
    {
        try
        {
            Console.WriteLine("Input number");

            corectType = true;
            variable = double.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Wrong input data type, error: " + e.Message);
            corectType = false;
        }
    }
}

//Input first number
InputNumber(out firstNumber);

//Input second number
InputNumber(out secondNumber);

//Add numbers
try
{
    Console.WriteLine(firstNumber + secondNumber);
}
catch (Exception e)
{
    Console.WriteLine("Something goes wrong, error: " + e.Message);
}


// Close Console
Console.WriteLine("Press enter to close...");
Console.ReadLine();
