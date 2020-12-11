using System;

namespace Task3
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(char.IsNumber('3'));
                
                Console.WriteLine(
                    "The program is calculator." +
                    "\nCreated by Ivan Zherybor.");

                Console.WriteLine("Rules:" +
                                  "\nCalculator of unary and binary expressions(-5 is unary, 5+5 is binary expression)." +
                                  "\nBinary : a + b, a - b, a * b, a x b, a / b, a \\ b, a % b, a pow b." +
                                  "\nBinary bit : a & b, a | b, a ^ b. Only positive operands." +
                                  "\nUnary bit: !a, a is positive number." +
                                  "\nUnary: a!, a, -a." +
                                  "\nCalculate can work expression only with 2 operands, for example, 1+2, !2, 2!." +
                                  "\nWrite exit to stop program, help to get list of enable expressions.");

                while (true)
                {
                    Console.Write("\nEnter your expression:");
                    var str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str))
                    {
                        Console.WriteLine("Enter something!");
                        continue;
                    }

                    if (str == "exit")
                    {
                        Console.WriteLine("See you!");
                        return 0;
                    }

                    if (str == "help")
                    {
                        PrintExpressions();
                        continue;
                    }

                    try
                    {
                        var result = Calculate(ParseString(str));
                        if(double.IsPositiveInfinity(result))
                            throw new OverflowException();
                        
                        Console.WriteLine($"Result: {result}");
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Divizion by zero!");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid expression. " +
                                          "\nWrite help to get list of enable expressions.");
                    }
                    catch(OverflowException)
                    {
                        Console.WriteLine("Overflow!");
                    }
                }
            }

            string message = "";
            foreach (var str in args)
            {
                message += str;
            }

            try
            {
                Console.WriteLine(Calculate(ParseString(message)));
            }
            catch
            {
                return -1;
            }

            return 0;
        }

        static double Calculate(string[] parsed)
        {
            if (parsed[0] == null && parsed[1] == "!") // if !2
            {
                if(parsed[2].Contains("."))
                    throw new ArgumentException();
                
                return ~Convert.ToInt32(parsed[2]);
            }

            if (parsed[1] == null)
                return Convert.ToDouble(parsed[0]);

            checked
            {
                char _operator = parsed[1][0];
                
                double operand1 = Convert.ToDouble(parsed[0]);
                double operand2 = Convert.ToDouble(parsed[2]);

                switch (_operator) // binary operation
                {
                    case '+':
                        return operand1 + operand2;
                    case '-':
                        return operand1 - operand2;
                    case '*':
                        return operand1 * operand2;
                    case '/':
                        if (operand2 == 0)
                            throw new ArgumentNullException();
                        return operand1 / operand2;
                    case '~':
                        return Math.Pow(operand1, operand2);
                    case '%':
                        return operand1 % operand2;
                    case '!':
                        if(parsed[2] != null)
                            throw new ArgumentException();

                        return Factorial((int)operand1);
                    default:
                        if (parsed[0].Contains(".") || parsed[2].Contains(".")) // if values is double
                            throw new ArgumentException();
                        
                        switch (_operator) // binary bit operations
                        {
                            case '|':
                                return (int) operand1 | (int) operand2;
                            case '&':
                                return (int) operand1 & (int) operand2;
                            case '^':
                                return (int) operand1 ^ (int) operand2;
                            default:
                                throw new ArgumentException();
                        }
                }
            }
        }

        static int Factorial(int value)
        {
            int res = value;
            while (value > 1)
            {
                value--;
                res *= value;
            }

            return res;
        }

        static string[] ParseString(string str)
        {
            str = str.Replace(" ", ""); // replace some symbols
            str = str.Replace(",", ".");
            str = str.Replace("x", "*");
            str = str.Replace("pow", "~");
            str = str.Replace("--", "+");
            str = str.Replace("\\", "/");
                        
            var charArray = str.ToCharArray();
            if (charArray[0] != '-' && charArray[0] != '!' && !char.IsNumber(charArray[0])) // check first symbol
                throw new ArgumentException();
                        
            if (charArray[charArray.Length - 1] != '!' && !char.IsNumber(charArray[charArray.Length - 1])) // check last symbol
                throw new ArgumentException();
            
            string[] result = new string[3]; // [0] - first operand, [1] - operator, [2] - second operand

            int index = 0; // index for string array
            for(int i = 0; i < charArray.Length; i++)
            {
                if(i == 0 && charArray[i] == '-') // if minus on first position
                    result[index] = "-" + result[index];
                else if (char.IsNumber(charArray[i]) || charArray[i] == '.') // if number or dot
                {
                    result[index] += charArray[i].ToString();
                }
                else if(char.IsLetter(charArray[i])) // if letter
                    throw new ArgumentException();
                else if(charArray[i] == '-' && !char.IsNumber(charArray[i - 1])) // if operator - like -3
                {
                    result[index] = "-" + result[index];
                }
                else // when operator
                {
                    index = 1;
                    result[index] += charArray[i].ToString();
                    index = 2;
                }
            }
            
            if(result[1] != null && result[1].Length > 1) // if operators more then 1
                throw new ArgumentException();

            return result;
        }

        static void PrintExpressions()
        {
            Console.WriteLine("Enable expressions:" +
                              "\na + b, a - b, a * b, a x b, a / b, a \\ b, a % b, " +
                              "\na pow b, a & b, a | b, a ^ b, !a, a!, a, -a");
        }
    }
}