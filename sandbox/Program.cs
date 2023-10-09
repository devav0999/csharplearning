// See https://aka.ms/new-console-template for more information
Console.Title = "adding two numbers";

string first_number;
string second_number;


Console.WriteLine("write first number");
first_number = Console.ReadLine();

Console.WriteLine("write second number");
second_number = Console.ReadLine();


try
{
    Console.WriteLine("sum of numbers");
    Console.WriteLine(Double.Parse(first_number) + Double.Parse(second_number));
    
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine("Press enter to close...");
Console.ReadLine();
