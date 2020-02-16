using Microsoft.VisualStudio.TestTools.UnitTesting;
using _200213_Exo8_Thread_affichage_multiple_de_lettres;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace _200213_Exo8_Thread_affichage_multiple_de_lettres.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void computeResultTest()
        {
            const int numberOfDesiredThreads = 3;

            for (int i = 0; i < numberOfDesiredThreads; i++)
            {
                Program.ThreadList.Add(new Thread(emptyThread));
            }

            Assert.AreEqual(numberOfDesiredThreads, Program.ThreadList.Count);

            Program.TabChars = "AZERTY";

            string actualOutput = Program.computeResult();
            // For numberOfDesiredThreads = 3
            string expectedOutput = "AAAZZZEEERRRTTTYYY";

            Assert.AreEqual(expectedOutput, actualOutput);


        }

        public static void emptyThread() { }
    }
}