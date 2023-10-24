// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics.Metrics;

Console.Title = "simple calculator";

string arythmeticExpresion = string.Empty;

Regex isArythmeticExpresion = new Regex(@"(((\d+\.\d+|\d+)[\/\*\+\-](\d+\.\d+|\d+))|([\/\*\+\-](\d+\.\d+|\d+)))+$");
Regex isDigit = new Regex(@"\d+\.\d+|\d+");
Regex isArythmeticSign = new Regex(@"[\/\*\+\-]");

bool regexMatched = false;

#region input value
while (!regexMatched)
{
    try
    {
        Console.WriteLine("Input arythmetic expresion");
        arythmeticExpresion = Console.ReadLine();
        MatchCollection matches = isArythmeticExpresion.Matches(arythmeticExpresion);

        if (matches.Count == 1)
            regexMatched = true;
    }
    catch(Exception e)
    {
        Console.WriteLine("Something goes wrong, error: " + e.Message);
    }
}
#endregion

MatchCollection matchesDigit = isDigit.Matches(arythmeticExpresion);
MatchCollection matchesArythmeticSign = isArythmeticSign.Matches(arythmeticExpresion);

#region calculating 

double outPut = double.Parse(matchesDigit.ElementAt(0).ToString());

try
{
    for (int i = 0; i < matchesArythmeticSign.Count(); i++)
    {
        switch (matchesArythmeticSign.ElementAt(i).ToString())
        {
            case "+":
                outPut += double.Parse(matchesDigit.ElementAt(i + 1).ToString());
                break;

            case "-":
                outPut -= double.Parse(matchesDigit.ElementAt(i + 1).ToString());
                break;

            case "*":
                outPut *= double.Parse(matchesDigit.ElementAt(i + 1).ToString());
                break;

            case "/":
                outPut /= double.Parse(matchesDigit.ElementAt(i + 1).ToString());
                break;

            default:
                Console.WriteLine("Oh no, imposible case");
                break;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Something goes wrong, error: " + e.Message);
}
#endregion

//Write outPut
try
{
    Console.WriteLine(outPut);
}
catch (Exception e)
{
    Console.WriteLine("Something goes wrong, error: " + e.Message);
}


// Close Console
Console.WriteLine("Press enter to close...");
Console.ReadLine();
