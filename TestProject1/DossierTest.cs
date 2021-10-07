// <copyright file="DossierTest.cs" company="Clément loze">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestProject1
{
    using System;
    using System.Collections.Generic;
    using CabinetMedical.ClassesMetier;
    using CabinetMedical.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test de la méthode dossier.
    /// </summary>
    [TestClass]
    public class DossierTest
    {
        /// <summary>
        /// Teste le nombre de prestations d'un intervenant externe.
        /// </summary>
        [TestMethod]
        public void TestGetNbPrestationsI()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Pierre");
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }

        /// <summary>
        /// Teste le nombre de prestations d'un intervenant externe.
        /// </summary>
        [TestMethod]
        public void TestGetNbPrestationIE()
        {
            IntervenantExterne intervenantExt = new IntervenantExterne("Delacour", "Charles", "Cardiologue", "12, rue de la chapelle 83000 Toulon", "0612345678");
            intervenantExt.AjoutePrestation(new Prestation("Presta 10", new DateTime(2021, 6, 15), intervenantExt));
            intervenantExt.AjoutePrestation(new Prestation("Presta 11", new DateTime(2021, 7, 14), intervenantExt));
            Assert.AreEqual(2, intervenantExt.GetNbPrestations());
        }

        /// <summary>
        /// Permet de tester que la date du dossier est OK.
        /// </summary>
        [TestMethod]
        public void TestDateCreationDossierOK()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        /// <summary>
        /// Permet de tester que la date du dossier est KO.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDateCreationDossierKO()
        {
            // Quel que soit le moment où on exécute le test, la date de création du dossier sera supérieure à la date du jour.
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Dossier dossier = new Dossier("Dupont", "Jean", dateCreationDossier, new DateTime(2019, 3, 31));
        }

        /// <summary>
        /// Permet de tester que la date de Prestation soit inférieure a la date création du dossier.
        /// </summary>
        [TestMethod]
        public void TestDatePrestationSupérieureDateDossierOK()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 4, 1), new Intervenant("Pierre", "Luc"));
        }

        /// <summary>
        /// Permet de tester que la date de Prestation soit inférieure a la date création du dossier.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDatePrestationSupérieureDateDossierKO()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 3, 21), new Intervenant("Pierre", "Luc"));
        }

        /// <summary>
        /// Permet de tester le nombre de prestations effectuées par des intervenants externes.
        /// </summary>
        [TestMethod]
        public void TesteGetNbPrestationExt()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            IntervenantExterne intervenantExterne = new IntervenantExterne("Pierre", "Luc", "cardiologue", "51, chemin du lac Paris", "0123456789");
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 4, 22), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 11", new DateTime(2019, 4, 22), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 12", new DateTime(2019, 4, 22), intervenantExterne);
            Assert.AreEqual(1, dossier.GetNbPrestationsExternes());
        }

        /// <summary>
        /// Permet de tester le nombre de jour de soins d'un dossier v1.
        /// </summary>
        [TestMethod]
        public void TesteNbJoursSoins()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            IntervenantExterne intervenantExterne = new IntervenantExterne("Pierre", "Luc", "cardiologue", "51, chemin du lac Paris", "0123456789");
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 11", new DateTime(2019, 4, 22), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 12", new DateTime(2019, 4, 22), intervenantExterne);
            Assert.AreEqual(2, dossier.GetNbJourSoinV1());
        }

        /// <summary>
        /// Permet de tester le nombre de jour de soins d'un dossier v2.
        /// </summary>
        [TestMethod]
        public void TesteNbJoursSoinsV2()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            IntervenantExterne intervenantExterne = new IntervenantExterne("Pierre", "Luc", "cardiologue", "51, chemin du lac Paris", "0123456789");
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 11", new DateTime(2019, 4, 22), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 12", new DateTime(2019, 4, 22), intervenantExterne);
            Assert.AreEqual(2, dossier.GetNbJourSoinV2());
        }

        /// <summary>
        /// Permet de tester le nombre de jour de soins d'un dossier v3.
        /// </summary>
        [TestMethod]
        public void TesteNbJoursSoinsV3()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            IntervenantExterne intervenantExterne = new IntervenantExterne("Pierre", "Luc", "cardiologue", "51, chemin du lac Paris", "0123456789");
            dossier.AjoutePrestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 11", new DateTime(2019, 4, 22), new Intervenant("Pierre", "Luc"));
            dossier.AjoutePrestation("Presta 12", new DateTime(2019, 4, 22), intervenantExterne);
            Assert.AreEqual(2, dossier.GetNbJoursSoinsV3());
        }

        /// <summary>
        /// Permet de tester l'ajout d'une liste de prestation.
        /// </summary>
        [TestMethod]
        public void TestAjoutPrestationList()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            List<Prestation> prestations = new List<Prestation>();
            Prestation unePrestation = new Prestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            prestations.Add(unePrestation);
            dossier.AjoutPrestationList(prestations);
            Assert.AreEqual(1, dossier.ListePrestations.Count);
        }

        /// <summary>
        /// Permet de tester l'ajout d'une liste de prestation.
        /// </summary>
        [TestMethod]
        public void TestAjoutPrestationList2()
        {
            List<Prestation> prestations = new List<Prestation>();
            Prestation unePrestation = new Prestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            prestations.Add(unePrestation);
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), prestations, new DateTime(2019, 3, 31));
            Assert.AreEqual(1, dossier.ListePrestations.Count);
        }

        /// <summary>
        /// Permet de tester l'ajout d'une prestation.
        /// </summary>
        [TestMethod]
        public void TestAjoutPrestation()
        {
            Prestation unePrestation = new Prestation("Presta 10", new DateTime(2019, 4, 21), new Intervenant("Pierre", "Luc"));
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), unePrestation, new DateTime(2019, 3, 31));
            Assert.AreEqual(1, dossier.ListePrestations.Count);
        }

        /// <summary>
        /// Permet de tester l'ajout d'un dossier.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestAjoutDossierKO()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2022, 3, 31));
        }

        /// <summary>
        /// Permet de tester la date de naissance du dossier.
        /// </summary>
        [TestMethod]
        public void TestDateNaissance()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2021, 3, 31));
            Assert.AreEqual(new DateTime(1990, 11, 12), dossier.DateNaissance);
        }

        /// <summary>
        /// Permet de tester le nom du patient du dossier.
        /// </summary>
        [TestMethod]
        public void TestNom()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2021, 3, 31));
            Assert.AreEqual("Dupont", dossier.Nom);
        }

        /// <summary>
        /// Permet de tester le prénom du patient du dossier.
        /// </summary>
        [TestMethod]
        public void TestPrenom()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2021, 3, 31));
            Assert.AreEqual("Jean", dossier.Prénom);
        }
    }
}
