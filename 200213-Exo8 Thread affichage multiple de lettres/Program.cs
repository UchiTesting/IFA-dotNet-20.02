using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using IHMConsole;
using System.Media;

namespace _200213_Exo8_Thread_affichage_multiple_de_lettres
{
    public class Program
    {
        private static readonly object synlock = new object();
        private static List<Thread> threadList = new List<Thread>();
        private static string tabChars = null;

        private static MainCanvas mc = null;
        private static Canvas menuCanvas = null;
        private static Canvas threadCanvas = null;
        private static Canvas resultCanvas = null;

        public static string TabChars { get => tabChars; set => tabChars = value; }
        public static List<Thread> ThreadList { get => threadList; set => threadList = value; }

        public static object Synlock => synlock;

        static void Main(string[] args)
        {
            Console.WriteLine("Exo 8: Affichage de Lettres threadé");
            TabChars = "ABC";
            initDisplay();

            bool stop = false;
            ConsoleKey choix;

            Console.CursorVisible = false;

            do
            {
                if (Console.KeyAvailable)
                {
                    choix = Console.ReadKey().Key;

                    switch (choix)
                    {
                        case ConsoleKey.NumPad1:
                            addThread();

                            break;
                        case ConsoleKey.NumPad2:
                            removeThread();
                            break;
                        case ConsoleKey.NumPad0:
                            stop = true;
                            break;
                    }
                }

                updateThreadList();
                updateResult();
            } while (!stop);
        }

        public static void initDisplay()
        {

            mc = MainCanvas.Instance;

            // Configuring Thread Canvas
            threadCanvas = new Canvas(1, 0, mc.Width, mc.Height - 11);
            threadCanvas.Add(new Label(displayThreadList(), 1, 0));

            // Configuring Menu Canvas
            menuCanvas = new Canvas(1, threadCanvas.Height + 4, mc.Width, 5);
            menuCanvas.Add(new Label(displayMenu(), 0, 0));

            // Configuring Result Canvas
            resultCanvas = new Canvas(1, threadCanvas.Height + 2, mc.Width, 1);
            resultCanvas.Add(new Label(computeResult(), 0, 0));

            // Setting up the main canvas with prepared elements
            mc.Add(threadCanvas);
            mc.Add(new HorizontalSeparator(0, threadCanvas.Height + 0));
            mc.Add(resultCanvas);
            mc.Add(new HorizontalSeparator(0, threadCanvas.Height + 3));
            mc.Add(menuCanvas);

            mc.Show();
        }

        public static string displayThreadInfo(Thread t)
        {
            return string.Format("{0,5}\t{1,5}", t.ManagedThreadId, t.ThreadState);
        }

        public static string displayThreadList(List<Thread> threadList)
        {
            StringBuilder sb = new StringBuilder();
            if (threadList.Count > 0)
            {
                foreach (Thread t in threadList)
                {
                    sb.AppendLine(displayThreadInfo(t));
                }
            }
            else
            {
                sb.AppendLine("Liste de threads vide.");
            }

            return sb.ToString();
        }

        public static string displayThreadList()
        {
            return displayThreadList(ThreadList);
        }

        public static string displayMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu");
            sb.AppendLine("========");
            sb.AppendLine("1) Ajouter un thread.");
            sb.AppendLine("2) Supprimer un thread.");
            sb.AppendLine("0) Quitter.");

            return sb.ToString();
        }

        public static string computeResult()
        {
            int finalLength = threadList.Count * TabChars.Length;
            char[] charTabStringBuilder = new char[finalLength];
            //Console.WriteLine("fl:{0} t:{1} c:{2}", finalLength, threadList.Count, TabChars.Length);


            if (ThreadList.Count > 0)
            {
                for (int indexOfLetter = 0; indexOfLetter < TabChars.Length; indexOfLetter++)
                {
                    for (int indexOfThread = 0; indexOfThread < threadList.Count; indexOfThread++)
                    {
                        Thread currentThread = threadList[indexOfThread];
                        try
                        {
                            currentThread.Start();
                        }
                        catch (ThreadStateException)
                        {
                            /*
                            Console.SetCursorPosition(1, mc.Height - 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Pas bien... >:(");
                            Console.ResetColor();*/
                        }

                        lock (synlock)
                        {
                            int letterPositionInResult = threadList.Count * indexOfLetter + indexOfThread;
                            charTabStringBuilder[letterPositionInResult] = TabChars[indexOfLetter];
                        }
                    }
                }
            }

            return new string(charTabStringBuilder);
        }

        public static void addThread()
        {
            if (ThreadList.Count < 10) //Limiting the number of threads.
            {
                ThreadList.Add(new Thread((object o) =>
                {
                    Thread.Sleep(500);
                }));
            }
        }

        public static void removeThread()
        {
            if (ThreadList.Count > 0)
            {
                ThreadList.RemoveAt(ThreadList.Count - 1);
            }
        }

        public static void updateThreadList()
        {
            Label threadListLabel = ((Label)threadCanvas.Content[0]);
            threadListLabel.Text = displayThreadList();
            threadListLabel.Show(); // Refreshes the Label
            threadCanvas.Show();
            Console.SetCursorPosition(1, mc.Height - 1);
        }

        public static void updateResult()
        {

            Label resultLabel = ((Label)resultCanvas.Content[0]);
            resultLabel.Text = computeResult();
            resultLabel.Show();

        }
    }
}
