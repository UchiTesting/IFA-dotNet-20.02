using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace _200218_Exo12_Echanges_entre_processus
{
    class Program
    {
        static int processType;
        static Mutex myMutex = null;
        static string fileName = "pipe.txt";
        static StreamWriter sw = null;
        static StreamReader sr = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Exo 12: Interprocess exchange.");

            processType = setupProcess();

            
            myMutex = new Mutex(false, "IOwnThePipe");
            Console.CursorVisible = false;
            Console.Clear();

            if (processType == 1)
                OperationProcess();
            else if (processType == 2)
                CalculationProcess();
        }

        public static int setupProcess()
        {
            int value = 0;
            bool ok = false;
            List<int> validOptions = new List<int>();
            validOptions.Add(0);
            validOptions.Add(1);
            validOptions.Add(2);

            Console.WriteLine("1) Operation retreval process.");
            Console.WriteLine("2) Calculator process.");
            Console.WriteLine("0) Quit.");
            Console.Write("What kind of process (1/2): ");

            do
            {
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());

                    if (validOptions.Exists(x => value == x))
                        ok = true;
                    else
                        Console.WriteLine("Please input a valid value.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input an integer.");

                }
            } while (!ok);

            return value;
        }

        public static void OperationProcess()
        {
            string saisie = string.Empty;

            while (saisie != "0")
            {
                if (myMutex.WaitOne())
                {
                    saisie = askValidOperationInput();

                    if (!saisie.Equals("0"))
                    {
                        try
                        {
                            sw = new StreamWriter(fileName, true);
                            sw.WriteLine(saisie);
                        }
                        catch (IOException ioe)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Could not work properly with pipe file:\n\t{0}", ioe.Message);
                            Console.ResetColor();
                        }
                        finally
                        {
                            sw.Close();
                        } 
                    }

                    myMutex.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// Process to calculate a line from the pipe.
        /// </summary>
        public static void CalculationProcess()
        {
            char saisie = '\0';

            do
            {
                if (myMutex.WaitOne())
                {
                    int n1 = 0;
                    int n2 = 0;
                    char operation ='\0';

                    string lastLine = ReadLastLine(fileName);
                    try
                    {
                        string[] operationLine = lastLine.Split(' ');

                        if (checkValidOperation(operationLine) && operationLine.Length != 1)
                        {
                            int.TryParse(operationLine[0], out n1);
                            char.TryParse(operationLine[1], out operation);
                            int.TryParse(operationLine[2], out n2);

                            try
                            {
                                sw = new StreamWriter(fileName, true);
                                sw.WriteLine(ComputeOperation(n1, n2, operation));
                            }
                            catch (IOException ioe)
                            {

                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Could not work properly with pipe file:\n\t{0}", ioe.Message);
                                Console.ResetColor();
                            }
                            finally
                            {
                                sw.Close();
                            }

                        }

                    }
                    catch (Exception e) when (e is NullReferenceException || e is IndexOutOfRangeException)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Pipe is empty."); ;
                    }

                    myMutex.ReleaseMutex();
                }

                if (Console.KeyAvailable)
                {
                    saisie = Console.ReadKey().KeyChar;
                }
            } while (saisie != '0');
        }

        /// <summary>
        /// Reads the last line of a text file.
        /// </summary>
        /// <param name="fileName">Path to a file to read.</param>
        /// <returns>The last line as a string.</returns>
        private static string ReadLastLine(string fileName)
        {
            string[] lines;
            string lastLine = null;

            try
            {
                lines = File.ReadAllLines(fileName);
                lastLine = lines[lines.Length - 1];
            }
            catch (IOException ioe)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not work properly with pipe file:\n\t{0}", ioe.Message);
                Console.ResetColor();
            } catch (IndexOutOfRangeException)
            {
                Console.WriteLine("File empty.");
            }

            return lastLine;
        }

        static string askValidOperationInput()
        {
            bool ok = false;
            string saisie;
            do
            {
                Console.Write("Please input an operation (0:quit): ");
                saisie = Console.ReadLine();
                string[] elements = saisie.Split(' ');
                ok = checkValidOperation(elements);
            } while (!ok);

            return saisie;
        }

        static bool checkValidOperation(string[] splittedString)
        {
            bool hasCorrectLength = false;
            bool hasValidOperator = false;

            bool n1IsInt = false;
            bool n2IsInt = false;

            if (splittedString.Length == 1 && splittedString[0].Equals("0"))  // Authorising this outfront to quit.
                return true;

            try
            {
                hasCorrectLength = (splittedString.Length == 3) ? true : false;
                hasValidOperator = "+-*/".Contains(splittedString[1]);

                n1IsInt = int.TryParse(splittedString[0], out int n1);
                n2IsInt = int.TryParse(splittedString[2], out int n2);
            }
            catch (IndexOutOfRangeException ioore)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Please respect the format: operand1 operation operand2 with spaces.\n\t{0}", ioore.Message);
                Console.ResetColor();
            }

            return hasCorrectLength && hasValidOperator && n1IsInt && n2IsInt;
        }

        static int ComputeOperation(int operand1, int operand2, char operation)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
            }

            return 0;
        }
    }
}
