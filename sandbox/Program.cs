// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text;

Console.Title = "adding two numbers";

double firstNumber = 0, secondNumber = 0;
bool corectType = false;

//Input first number
while (!corectType)
{
    try
    {
        Console.WriteLine("Input first number");

        corectType = true;
        firstNumber = double.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine("Wrong input data type, error: " + e.Message);
        corectType = false;
    }
}


//Input second number
corectType = false;

while (!corectType)
{
    try
    {
        Console.WriteLine("Input second number");

        corectType = true;
        secondNumber = double.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine("Wrong input data type, error: " + e.Message);
        corectType = false;
    }
}

//Add numbers
try
{
    Console.WriteLine(firstNumber+secondNumber);
}
catch (Exception e)
{
    Console.WriteLine("Something goes wrong, error: " + e.Message);
}

// Close Console
Console.WriteLine("Press enter to close...");
Console.ReadLine();
