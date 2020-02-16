using Microsoft.VisualStudio.TestTools.UnitTesting;
using _200206_Exo4_Banque;

namespace _200212_Exo4_BanqueTest
{
    [TestClass]
    public class CompteTest
    {

        [TestMethod]
        public void Test_Depot()
        {
            Account c = new Account("0", 1000, 2);

            decimal depot = 12.36m;
            decimal expectedBalance = 1012.36m;

            c.Deposit(depot);
            decimal actualBalance = c.Balance;

            c = null;

            Assert.AreEqual(expectedBalance, actualBalance);

        }
        [TestMethod]
        public void Test_Retrait()
        {
            Account c = new Account("0", 1000, 2);

            decimal retrait = 12.36m;
            decimal expectedBalance = 987.64m;

            c.Withdraw(retrait);
            decimal actualBalance = c.Balance;

            c = null;

            Assert.AreEqual(expectedBalance, actualBalance);
        }
        [TestMethod]
        public void Test_Retrait_Excessive()
        {
            Account c = new Account("0", 10, 2);

            decimal retrait = 12.36m;
            decimal actualBalance = c.Balance;


            Assert.ThrowsException<MoneyWithdrawExceedException>(() => c.Withdraw(retrait),"Balance: "+actualBalance);
            c = null;
        }
    }
}
