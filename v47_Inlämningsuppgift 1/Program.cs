using System;
using System.Collections.Generic;
using System.Threading;

namespace v47_Inlämningsuppgift_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string operatorOne, operatorTwo, operators = "+-*/";
            float termOne = 0, termTwo = 0, termThree = 0, result = 0;
            int tries = 0;
            bool engaged = false, allowed = false, firstTimeRunning = false; ;
            List<float> listOfResults = new List<float>();

            Console.Title = "Inlämningsuppgift 1";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            while (tries < 3)
            {
                if (tries == 2)
                    Console.WriteLine("Du har nu gjort fel 2 ggr. Nästa gång avslutas programmet.");
                tries++;
                allowed = true;

                if (!firstTimeRunning)
                {
                    firstTimeRunning = true;
                    Console.WriteLine("Välkommen till Lee's inlämningsuppgift 1.");
                }

                Thread.Sleep(1000);
                Console.Write("Skriv ín en operand: ");
                operatorOne = Console.ReadLine();
                if (operatorOne.Length == 1 && operators.Contains(operatorOne))
                {

                    //If you don't type numbers only, then you get thrown back to the begining.

                    Console.Write("Skriv ín en till operand: ");
                    operatorTwo = Console.ReadLine();
                    if (operatorTwo.Length == 1 && operators.Contains(operatorTwo))
                    {
                        Console.Write("Skriv in den första termen: ");
                        try
                        {
                            termOne = float.Parse(Console.ReadLine());
                            //Console.WriteLine("{0:F1}", termOne);

                            Console.Write("Skriv in den andra termen: ");
                            try
                            {
                                termTwo = float.Parse(Console.ReadLine());
                                //Console.WriteLine("{0:F1}", termTwo);
                                Console.Write("Skriv in den tredje termen: ");
                                try
                                {
                                    termThree = float.Parse(Console.ReadLine());
                                    //Console.WriteLine("{0:F1}", termThree);

                                    //Make calculations 
                                    try
                                    {
                                        engaged = true;

                                        if (operatorOne != "/" && operatorTwo != "/")
                                        {
                                            if (operatorOne == "*" && operatorTwo == "*")
                                                result = termOne * termTwo * termThree;
                                            else if (operatorOne == "*" && operatorTwo == "+")
                                                result = termOne * termTwo + termThree;
                                            else if (operatorOne == "*" && operatorTwo == "-")
                                                result = termOne * termTwo - termThree;
                                            else if (operatorOne == "+" && operatorTwo == "+")
                                                result = termOne + termTwo + termThree;
                                            else if (operatorOne == "+" && operatorTwo == "*")
                                                result = termOne + termTwo * termThree;
                                            else if (operatorOne == "+" && operatorTwo == "-")
                                                result = termOne + termTwo - termThree;
                                            else if (operatorOne == "-" && operatorTwo == "*")
                                                result = termOne - termTwo * termThree;
                                            else if (operatorOne == "-" && operatorTwo == "-")
                                                result = termOne - termTwo - termThree;
                                            else
                                                result = termOne - termTwo - termThree;
                                        }
                                        else if (operatorOne == "/" && operatorTwo != "/" && termTwo != 0)
                                        {
                                            if (operatorTwo == "*")
                                                result = termOne / termTwo * termThree;
                                            else if (operatorTwo == "+")
                                                result = termOne / termTwo + termThree;
                                            else
                                                result = termOne / termTwo - termThree;
                                        }
                                        else if (operatorOne != "/" && operatorTwo == "/" && termThree != 0)
                                        {
                                            if (operatorOne == "*")
                                                result = termOne * termTwo / termThree;
                                            else if (operatorOne == "+")
                                                result = termOne + termTwo / termThree;
                                            else
                                                result = termOne - termTwo / termThree;
                                        }
                                        else if (termTwo != 0 && termThree != 0)
                                            result = termOne / termTwo / termThree;
                                        /*
                                        else
                                        {
                                            allowed = false;
                                            Console.WriteLine("Du Kan inte dela med 0!");
                                        }
                                        */

                                        if (allowed)
                                        {
                                            tries = 0;
                                            listOfResults.Add(result);

                                            Console.WriteLine("{0:F1} {1} {2:F1} {3} {4:F1} = {5:F1}", termOne, operatorOne, termTwo, operatorTwo, termThree, result);
                                            if (result > 100)
                                                Console.WriteLine("Resultatet är över 100.");
                                            else if (result < 100)
                                                Console.WriteLine("Resultatet är mindre än 100.");
                                            else
                                                Console.WriteLine("Resultatet är 100");
                                        }
                                    }
                                    catch { Console.WriteLine("Du kan inte dela med 0!"); }
                                }
                                catch { Console.WriteLine("Du skrev inte in ett tal! CATCH 1"); }
                            }
                            catch { Console.WriteLine("Du skrev inte in ett tal! CATCH 2"); }
                        }
                        catch { Console.WriteLine("Du skrev inte in ett tal! CHATCH 3"); }
                    }


                }
                else
                    allowed = !allowed;
                if (!allowed)
                    Console.WriteLine($"Försök {tries} gick inte.");

                float tot = 0;

                Console.WriteLine("Vill du försöka igen? J/N?");
                if (Console.ReadLine().ToLower() != "j")
                {
                    foreach (float f in listOfResults)
                        tot += f;
                    Console.Clear();
                    if (engaged)
                        Console.WriteLine("Den totala summan av alla beräkningar är {0:F1}", tot);
                    else
                        Console.WriteLine("Du lyckades inte göra en uträkning. Bättre lycka nästa gång.");
                    Console.ReadKey();
                    break;
                }

                Console.Clear();
            }

            Console.WriteLine("Nu avslutas programmet. Hej Då!");
            Console.ReadKey();

        }
    }
}
