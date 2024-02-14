using BibliothequeApi.Services;
using Microsoft.IdentityModel.Tokens;

namespace TestBibliothequeApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestdateEmpruntsEstToday()
        {
            //test avec date du jour
            BibliothequeApi.Emprunt e = new BibliothequeApi.Emprunt(DateOnly.FromDateTime(DateTime.Now), null, 1, 1);
            bool test = EmpruntService.DateEmpruntEstToday(e);
            Assert.IsTrue(test);
            //test avec une date anterieur
            e.DateEmprunt = DateOnly.FromDateTime(new DateTime(2023,01,24));
            test = EmpruntService.DateEmpruntEstToday(e);
            Assert.IsFalse(test);
            //test avec une date dans le futur
            e.DateEmprunt = DateOnly.FromDateTime(new DateTime(4023, 01, 24));
            test = EmpruntService.DateEmpruntEstToday(e);
            Assert.IsFalse(test);
        }
        [TestMethod]
        public void TestDateEmpruntAvantDateRetour()
        {
            //test avec date retour = null
            BibliothequeApi.Emprunt e = new BibliothequeApi.Emprunt(DateOnly.FromDateTime(DateTime.Now), null, 1, 1);
            Assert.IsFalse(EmpruntService.DateEmpruntAvantDateRetour(e));
            //test avec date retour = date emprunt
            e.DateRetour = DateOnly.FromDateTime(DateTime.Now);
            Assert.IsTrue(EmpruntService.DateEmpruntAvantDateRetour(e));
            //test avec date retour avant date emprunt
            e.DateRetour = DateOnly.FromDateTime(new DateTime(2024,02,13));
            e.DateEmprunt = DateOnly.FromDateTime(DateTime.Now);
            Assert.IsFalse(EmpruntService.DateEmpruntAvantDateRetour(e));
            //test avec date retour apres date emprunt
            e.DateRetour = DateOnly.FromDateTime(new DateTime(2024,02,15));
            e.DateEmprunt = DateOnly.FromDateTime(new DateTime(2024,02,14));
            Assert.IsTrue(EmpruntService.DateEmpruntAvantDateRetour(e));
        }
        [TestMethod]
        public void TestDateRetourEstToday()
        {
            //test avec date du jour
            BibliothequeApi.Emprunt e = new BibliothequeApi.Emprunt(DateOnly.FromDateTime(new DateTime(2023, 01, 24)), DateOnly.FromDateTime(DateTime.Now), 1, 1);
            bool test = EmpruntService.DateRetourEstToday(e);
            Assert.IsTrue(test);
            //test avc date anterieur
            e.DateRetour = DateOnly.FromDateTime(new DateTime(2023, 01, 24));
            test = EmpruntService.DateRetourEstToday(e);
            Assert.IsFalse(test);
            //test avec date dans le futur
            e.DateRetour = DateOnly.FromDateTime(new DateTime(4023, 01, 24));
            test = EmpruntService.DateRetourEstToday(e);
            Assert.IsFalse(test);
        }
    }
}