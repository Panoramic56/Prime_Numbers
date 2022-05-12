using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PrimeNumber_SELF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor notPrimeColor = ConsoleColor.Red;
            ConsoleColor lengthCounterColor = ConsoleColor.DarkYellow;
            ConsoleColor actualPrimeColor = ConsoleColor.Green;
            ConsoleColor endResultColor = ConsoleColor.Magenta;
            ConsoleColor writerFileColor = ConsoleColor.DarkCyan;
            ConsoleColor multipliersColor = ConsoleColor.Blue;
            ConsoleColor fileReaderColor = ConsoleColor.Yellow;
            while (true)
            {
                int u = 0, start = 0, end = 0, length = 1, m = 0, exists = 0, startNew = 0, endNew = 0, x = 0;
                bool a = true;
                List<int> Numbers = new List<int>();
                char newRange = 'N';

                Console.Write("1 - Range\n2 - Exact\n3 - Find already-done ranges\nType the mode to be used: ");
                char mode = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                if (mode == '2' || mode == 'E')
                {
                    Console.Write("Is this number prime: ");
                    int testPrime = int.Parse(Console.ReadLine());

                    for (int s = testPrime-1; s > 1; s--)
                        Numbers.Add(s);

                    foreach (int s in Numbers)
                    {
                        if (testPrime % s == 0)
                        {
                            u++;
                            Console.WriteLine($"{testPrime} is divisible by {s}");
                        }
                    }
                    if (u == 0)
                        Console.WriteLine($"{testPrime} is prime\n");
                    else
                        Console.WriteLine($"{testPrime} is not prime\n");
                }

                else if (mode == '3' || mode == 'F')
                {
                    Console.Write("Start to find: ");
                    startNew = int.Parse(Console.ReadLine());
                    Console.Write("End to find: ");
                    endNew = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = fileReaderColor;
                    foreach (string line in File.ReadAllLines(@"D:\C# Projects\SELF Codes\Prime.txt"))
                    {
                        if (line.Contains($"Between {startNew} and {endNew} "))
                        {
                            Console.WriteLine(line);
                            exists = 1;
                            break;
                        }
                    }
                    
                }

                if (exists == 0 && mode == '3' || mode == 'F')
                {
                    Console.Write($"The range {startNew}-{endNew} was not done before\nDo you want to do it right now: ");
                    newRange = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                }

                Console.ForegroundColor = ConsoleColor.White;

                if (mode == '1' || newRange == 'Y')
                {
                    char notPrime = 'N', lengthCounter = 'N', primesLength = 'N', endResult = 'N', writerFile = 'N', multipliers = 'N';

                    if (newRange == 'Y')
                    {
                        x = startNew;
                        end = endNew;
                    }

                    else
                    {
                        Console.Write("Where to start: ");
                        x = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Where to end: ");
                        end = Convert.ToInt32(Console.ReadLine());
                    }
                    start = x;

                    if (start == 0)
                        start += 2;
                    else if (start == 1)
                        start++;

                    Console.Write("High Performance (disables all other modifiers): ");
                    char HP = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

                    if (HP == 'Y')
                    {
                        for (int i = start; i >= 2; i--)
                            Numbers.Add(i);


                        for (x = start; x <= end; x++)
                        {
                            u = 0;

                            foreach (int n in Numbers)
                            {
                                if (x % n == 0 && n != 1)
                                    u++;
                            }

                            if (u == 0)
                                Console.WriteLine($"{x} is prime");
                            if (x != 0 && x != 1)
                                Numbers.Add(x);
                        }
                    }

                    else
                    {
                        #region
                        Console.Write("Edit colors: ");
                        char c = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

                        if (c == 'Y')
                        {
                            Console.WriteLine("\n--COLORS--\n0 - Black\n1 - DarkBlue\n2 - DarkGreen\n3 - DarkCyan\n4 - DarkRed\n5 - DarkMagenta\n6 - DarkYellow\n7 - Gray\n8 - DarkGray\n9 - Blue\n10 - Green\n11 - Cyan\n12 - Red\n13 - Magenta\n14 - Yellow\n15 - White\n" 
                                +
                                $"\n--PLACES--\n1 - NotPrime ({notPrimeColor})\n2 - PrimesLength ({lengthCounterColor})\n3 - EndResult ({endResultColor})\n4 - WriterFile ({writerFileColor})\n5 - ActualPrimes({actualPrimeColor})\n6 - Multipliers ({multipliersColor})\n7 - FileReader ({fileReaderColor})");
                            Console.Write("Type the place you want to change the color of: ");
                            int colorPlace = int.Parse(Console.ReadLine());

                            Console.Write("Type the color you want: ");
                            string colorChange = Console.ReadLine();

                            if (colorPlace == 1)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    notPrimeColor = color;
                            }
                            else if (colorPlace == 2)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    lengthCounterColor = color;
                            }
                            else if (colorPlace == 3)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    endResultColor = color;
                            }
                            else if (colorPlace == 4)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    writerFileColor = color;
                            }
                            else if (colorPlace == 5)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    actualPrimeColor = color;
                            }
                            else if (colorPlace == 6)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    multipliersColor = color;
                            }
                            else if (colorPlace == 7)
                            {
                                if (Enum.TryParse(colorChange, out ConsoleColor color))
                                    fileReaderColor = color;
                            }
                        }
                        #endregion
                        Console.Write("Do you want to utilize Special Operations (Y/N): ");
                        char SP = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

                        if (SP == 'Y')
                        {
                            Console.Write("Show not-prime numbers: ");
                            notPrime = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                            Console.Write("Show length counter:");
                            lengthCounter = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                            Console.Write("Show primes-per-length: ");
                            primesLength = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                            Console.Write("Show end result: ");
                            endResult = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                            Console.Write("Write the final result in the text file: ");
                            writerFile = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                            Console.Write("Show all multipliers of non-prime numbers: ");
                            multipliers = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                        }

                        for (int i = x; i >= 2; i--)
                            Numbers.Add(i);

                        while (a == true)
                        {
                            if (end != 0)
                            {
                                if (x == end)
                                    a = false;
                            }

                            u = 0;

                            if (lengthCounter == 'Y' || primesLength == 'Y')
                            {
                                if (Convert.ToString(x).Length > length)
                                {
                                    Console.ForegroundColor = lengthCounterColor;
                                    length++;
                                    if (lengthCounter == 'Y')
                                        Console.WriteLine($"\n[Length = {length}]");

                                    if (primesLength == 'Y')
                                        Console.WriteLine($"[Between numbers with 1 and {length} characters there are {m} prime numbers]\n");

                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }

                            foreach (int n in Numbers)
                            {
                                if (x % n == 0)
                                {
                                    if (n != 1)
                                    {
                                        u++;
                                        if (multipliers == 'Y')
                                        {
                                            Console.ForegroundColor = multipliersColor;
                                            Console.WriteLine($"{x} is divisible by {n}");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }
                            }

                            if (notPrime == 'Y')
                            {
                                if (u == 0 && x != 1 || u == 1 && x == 2)
                                {
                                    Console.ForegroundColor = actualPrimeColor;
                                    Console.WriteLine($"{x} is prime --- u = {u}");
                                    m++;
                                }
                                else
                                {
                                    Console.ForegroundColor = notPrimeColor;
                                    Console.WriteLine($"{x} is not prime --- u = {u}\n");
                                }
                            }
                            else if (notPrime != 'Y')
                            {
                                if (u == 0 && x != 1 || u == 1 && x == 2)
                                {
                                    Console.ForegroundColor = actualPrimeColor;
                                    Console.WriteLine($"{x} is prime --- u = {u}");
                                    m++;
                                }
                            }

                            Console.ForegroundColor = ConsoleColor.White;
                            if (Numbers.Contains(x) == false && x != 0)
                                Numbers.Add(x);
                            x++;
                        }
                        if (endResult == 'Y')
                        {
                            Console.ForegroundColor = endResultColor;
                            Console.WriteLine($"Between {start} and {end} there are {m} prime numbers");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (writerFile == 'Y')
                        {
                            Console.ForegroundColor = writerFileColor;
                            Console.WriteLine("\nFinal result recorded in the text file Primes.txt");
                            if (File.ReadAllText(@"D:\C# Projects\SELF Codes\Prime.txt") != string.Empty)
                                File.AppendAllText(@"D:\C# Projects\SELF Codes\Prime.txt", "\n");

                            File.AppendAllText(@"D:\C# Projects\SELF Codes\Prime.txt", $"Between {start} and {end} there are {m} prime numbers.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (newRange == 'Y')
                        {
                            Console.ForegroundColor = writerFileColor;
                            Console.WriteLine("\nFinal result recorded in the text file Primes.txt");
                            if (File.ReadAllText(@"D:\C# Projects\SELF Codes\Prime.txt") != string.Empty)
                                File.AppendAllText(@"D:\C# Projects\SELF Codes\Prime.txt", "\n");

                            File.AppendAllText(@"D:\C# Projects\SELF Codes\Prime.txt", $"Between {startNew} and {endNew} there are {m} prime numbers.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
