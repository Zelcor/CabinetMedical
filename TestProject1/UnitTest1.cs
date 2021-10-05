using CabinetMedical.ClassesMetier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SommePourRienTest()
        {
            int a = 3;
            int b = 5;
            int somme = new SertAFaireUnTestUnitaire().SommePourRien(a, b);
            Assert.AreEqual(8, somme);
        }
    }
}
