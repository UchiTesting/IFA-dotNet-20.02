using Microsoft.VisualStudio.TestTools.UnitTesting;
using _200206_Exo4_Banque;

namespace _200212_Exo4_BanqueTest
{
    [TestClass]
    public class BanqueTest
    {
        [TestMethod]
        public void Test_CreerCompte()
        {
            Bank b = new Bank("TestBank","Anywhere");

            Assert.AreEqual(0, b.Accounts.Count);

            b.CreateAccount("0",1000m,0.32f);
            b.CreateAccount("1",5000m,0.53f);

            Assert.IsNotNull(b.Accounts);
            Assert.AreEqual(2, b.Accounts.Count);

        }
        [TestMethod]
        public void Test_SupprimerCompte()
        {
            Bank b = new Bank("TestBank", "Anywhere");

            b.CreateAccount("0", 1000m, 0.32f);
            Assert.AreEqual(1, b.Accounts.Count);

            b.DeleteAccount(b.LookupAccount("0"));

            Assert.AreEqual(0, b.Accounts.Count);
        }
        /*
        [TestMethod]
        [TestMethod]
        [TestMethod]
        [TestMethod] */
    }
}
