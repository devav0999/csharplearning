// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime;

Console.Title = "simple calculator";

string trimedArythmeticExpresion = string.Empty;

/// <summary>Return first finding number in arythmetic expresion</summary>
/// <param name="s">The string which has arithmetic sign.</param>
/// <returns>Returns number  whitch is in string s bfore arythmetic sign or in its end </returns>
double RetrunFirstNumberFromString(string s) 
{
    int[] tebleOfMachedIndex = new int[4];
    tebleOfMachedIndex[0] = s.IndexOf('-');
    tebleOfMachedIndex[1] = s.IndexOf('+');
    tebleOfMachedIndex[2] = s.IndexOf('*');
    tebleOfMachedIndex[3] = s.IndexOf('/');

    int minIndex = int.MaxValue;

    // if there is not any sign
    if (tebleOfMachedIndex[0] == tebleOfMachedIndex[1] && tebleOfMachedIndex[2] == tebleOfMachedIndex[3])
        return double.Parse(s);
    
    // smalest index from finded sign or signs
    foreach (int index in tebleOfMachedIndex)
    { 
        if(index != -1 && minIndex > index)
            minIndex = index;
    }
    return double.Parse(s.Substring(0, minIndex));
}

#region input value

try
{
    Console.WriteLine("Input arythmetic expresion - check correct input values before enter");
    string arythmeticExpresion = Console.ReadLine();
    trimedArythmeticExpresion = new string(arythmeticExpresion.Where(a => a == '-' || 
                                                            a == '+' || 
                                                            a == '/' || 
                                                            a == '*' || 
                                                            a == '1' || 
                                                            a == '2' || 
                                                            a == '3' || 
                                                            a == '4' || 
                                                            a == '5' || 
                                                            a == '6' || 
                                                            a == '7' || 
                                                            a == '8' || 
                                                            a == '9' || 
                                                            a == '0' || 
                                                            a == ',').ToArray());

}
catch(Exception e)
{
    Console.Error.WriteLine("Input proces error - message: " + e);
}

#endregion

#region calculating 

double outPut = RetrunFirstNumberFromString(trimedArythmeticExpresion);

try
{
    for (int i = 0; i < trimedArythmeticExpresion.Length; i++)
    {
        if (trimedArythmeticExpresion.ElementAt(i) is '-')
        {
            outPut -= RetrunFirstNumberFromString(trimedArythmeticExpresion. Substring(i + 1));
        }
        if (trimedArythmeticExpresion.ElementAt(i) is '+')
        {
            outPut += RetrunFirstNumberFromString(trimedArythmeticExpresion.Substring(i + 1));
        }
        if (trimedArythmeticExpresion.ElementAt(i) is '*')
        {
            outPut *= RetrunFirstNumberFromString(trimedArythmeticExpresion.Substring(i + 1));
        }
        if (trimedArythmeticExpresion.ElementAt(i) is '/')
        {
            outPut /= RetrunFirstNumberFromString(trimedArythmeticExpresion.Substring(i + 1));
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Calculating proces error - message: " + e);
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
