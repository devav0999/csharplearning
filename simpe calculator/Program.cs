// See https://aka.ms/new-console-template for more information

using System.Collections;


Console.Title = "simple calculator";

string arythmeticExpresion = string.Empty;
string stringOfarythmeticSigns = string.Empty;
Stack stakOfDigits = new Stack();

bool correctExpresion = false;

/// <summary>Gets char character and array of char set.</summary>
/// <returns> Return true if char character is in array of char set.</returns>
bool IsInSet(char character, char[] set)
{
    try
    {
        foreach (char cha in set)
        {
            if (character == cha)
                return true;
        }
    }
    catch (Exception e)
    {
        Console.Error.WriteLine("An error has occured" + e);
    }
    return false;
}

/// <summary>Gets string.</summary>
/// <returns>Reversed input string.</returns>
string Reverse(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}


#region input value

while (!correctExpresion)
{
    try
    {
        Console.WriteLine("Input arythmetic expresion - check correct input values before enter");
        arythmeticExpresion = Console.ReadLine();
        arythmeticExpresion.Trim();
        char[] setOfDigits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' };
        char[] setOfArythmeticSigns = { '-', '+', '/', '*'};


        foreach (char element in arythmeticExpresion) 
        {
            if (!IsInSet(element, setOfDigits) && !IsInSet(element, setOfArythmeticSigns))
                throw new Exception("Input string contains incorrect sign");
        }
        correctExpresion = true;

        string temp = string.Empty;

        for ( int i = arythmeticExpresion.Length - 1 ; i > -1; i--)
        {
            if (int.TryParse(arythmeticExpresion[i].ToString(), out int result))
            {
                temp += arythmeticExpresion[i];

                if (i == 0) 
                {
                    stakOfDigits.Push(Reverse(temp));
                    temp = string.Empty;
                }
            }

            if (arythmeticExpresion[i] == ',' && temp.IndexOf(',') == -1)
                temp += arythmeticExpresion[i];

            if (arythmeticExpresion[i] == '-' || arythmeticExpresion[i] == '+' || arythmeticExpresion[i] == '/' || arythmeticExpresion[i] == '*')
            {
                stakOfDigits.Push(Reverse(temp));
                temp = string.Empty;
                stringOfarythmeticSigns += arythmeticExpresion[i];
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Something goes wrong, error: " + e.Message);
    }
}
#endregion

#region calculating 

double outPut = outPut = double.Parse(stakOfDigits.Pop().ToString());

try
{
    for (int i = stringOfarythmeticSigns.Length - 1; i > - 1; i--)
    {
        switch (stringOfarythmeticSigns.ElementAt(i))
        {
            case '+':
                outPut += double.Parse(stakOfDigits.Pop().ToString());
                break;

            case '-':
                outPut -= double.Parse(stakOfDigits.Pop().ToString());
                break;

            case '*':
                outPut *= double.Parse(stakOfDigits.Pop().ToString());
                break;

            case '/':
                outPut /= double.Parse(stakOfDigits.Pop().ToString());
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
