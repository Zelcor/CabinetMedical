// <copyright file="Dossier.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Initializes the <see cref="Dossier"/> class.
    /// </summary>
    public class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private DateTime dateCreation;
        private List<Prestation> listePrestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous pouvons retrouver le nom du patient. </param>
        /// <param name="prenom"> Ici nous pouvons retrouver le prénom du patient. </param>
        /// <param name="dateNaissance"> Ici nous pouvons retrouver la date de naissance du patient. </param>
        public Dossier(string nom, string prenom, DateTime dateNaissance) // Dossier seul sans prestation
        {
            if (dateNaissance > DateTime.Now)
            {
                throw new CabinetMedicalException("Erreur la date de naissance est supérieure à la date du jour");
            }

            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.dateCreation = DateTime.Now;
            this.listePrestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous pouvons retrouver le nom du patient. </param>
        /// <param name="prenom"> Ici nous pouvons retrouver le prénom du patient. </param>
        /// <param name="dateNaissance"> Ici nous pouvons retrouver la date de naissance du patient. </param>
        /// <param name="dateCreation"> Ici nous pouvons retrouver la date du dossier du patient. </param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
            : this(nom, prenom, dateNaissance)
        {
            if (dateCreation > DateTime.Now)
            {
                throw new CabinetMedicalException("Erreur la date de création ne peut être supérieure à la date du jour");
            }

            this.dateCreation = dateCreation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous pouvons retrouver le nom du patient. </param>
        /// <param name="prenom"> Ici nous pouvons retrouver le prénom du patient. </param>
        /// <param name="dateNaissance"> Ici nous pouvons retrouver la date de naissance du patient. </param>
        /// <param name="prestation"> Ici nous pouvons inserer un attribut de la classe prestation. </param>
        /// <param name="dateCreation"> Ici nous pouvons retrouver la date du dossier du patient. </param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, Prestation prestation, DateTime dateCreation)
            : this(nom, prenom, dateNaissance) // Dossier avec une seule prestation
        {
            this.AjoutePrestation(prestation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous pouvons retrouver le nom du patient. </param>
        /// <param name="prenom"> Ici nous pouvons retrouver le prénom du patient. </param>
        /// <param name="dateNaissance"> Ici nous pouvons retrouver la date de naissance du patient. </param>
        /// <param name="listePrestation"> Ici nous pouvons retrouver la liste des prestations associée au patient. </param>
        /// <param name="dateCreation"> Ici nous pouvons retrouver la date du dossier du patient. </param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> listePrestation, DateTime dateCreation)
            : this(nom, prenom, dateNaissance) // Dossier avec une liste de prestation
        {
            this.listePrestations = listePrestation;
        }

        /// <summary>
        /// Gets nom.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets prenom.
        /// </summary>
        public string Prénom { get => this.prenom; }

        /// <summary>
        /// Gets date de naissance.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; }

        /// <summary>
        /// Gets liste des prestations.
        /// </summary>
        public List<Prestation> ListePrestations { get => this.listePrestations; }

        /// <summary>
        /// Methode pour ajouter une prestation.
        /// </summary>
        /// <param name="prestation"> La prestation qui est ajoutée par la méthode. </param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.listePrestations.Add(prestation);
        }

        /// <summary>
        /// Surcharge de la méthode AjoutePrestation.
        /// </summary>
        /// <param name="libelle"> Ici nous retrouvons le libellé de la prestation. </param>
        /// <param name="date"> Ici nous retrouvons la date où s'effectue la prestation. </param>
        /// <param name="intervenant"> Ici nous retrouvons l'intervenant qui intervient sur la prestation. </param>
        public void AjoutePrestation(string libelle, DateTime date, IntervenantExterne intervenant)
        {
            Prestation prestation = new Prestation(libelle, date, intervenant);
            this.AjoutePrestation(prestation);
        }

        /// <summary>
        /// Surcharge de la méthode AjoutePrestation.
        /// </summary>
        /// <param name="libelle"> Ici nous retrouvons le libellé de la prestation. </param>
        /// <param name="date"> Ici nous retrouvons la date où s'effectue la prestation. </param>
        /// <param name="intervenant"> Ici nous retrouvons l'intervenant qui intervient sur la prestation. </param>
        public void AjoutePrestation(string libelle, DateTime date, Intervenant intervenant)
        {
            Prestation prestation = new Prestation(libelle, date, intervenant);
            if (prestation.DateHeureSoin > this.dateCreation)
            {
                this.AjoutePrestation(prestation);
            }
            else
            {
                throw new CabinetMedicalException("Date de soin plus petite que date de création, insertion impossible");
            }
        }

        /// <summary>
        /// Methode pour ajouter une liste de prestation.
        /// </summary>
        /// <param name="listePrestation"> Ici nous retrouvons la liste de prestation. </param>
        public void AjoutPrestationList(List<Prestation> listePrestation)
        {
            this.listePrestations = listePrestation;
        }

        /// <summary>
        /// Méthode qui receuille le nombre de jour de soins.
        /// </summary>
        /// <returns> Retourne le nombre de prestations. </returns>
        public int GetNbJourSoinV1()
        {
            int nbPresta = this.listePrestations.Count;
            for (int i = 0; i < this.listePrestations.Count - 1; i++)
            {
                for (int a = i + 1; a < this.listePrestations.Count; a++)
                {
                    if (Prestation.CompareTo(this.listePrestations[i], this.listePrestations[a]) == 0)
                    {
                        nbPresta--;
                    }
                }
            }

            return nbPresta;
        }

        /// <summary>
        /// Méthode qui receuille le nombre de jours de soins v2.
        /// </summary>
        /// <returns>Retourne le nombre de prestations. </returns>
        public int GetNbJourSoinV2()
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation prestation in this.listePrestations)
            {
                if (!dates.Contains(prestation.DateHeureSoin.Date))
                {
                    dates.Add(prestation.DateHeureSoin.Date);
                }
            }

            return dates.Count;
        }

        /// <summary>
        /// Méthode qui receuille le nombre de jours soins v3.
        /// </summary>
        /// <returns>Retourne le nombre de prestations.</returns>
        public int GetNbJoursSoinsV3()
        {
            List<Prestation> dateTrie = this.listePrestations.OrderBy(prest => prest.DateHeureSoin).ToList(); // ordre croissant

            // List<Prestation> dateTrie = prestations.OrderByDescending(prest => prest.DateHeureSoin).ToList(); //ordre décroissant
            DateTime baser = dateTrie[0].DateHeureSoin.Date;
            int cpt = 0;

            foreach (Prestation date in dateTrie)
            {
                if (!(date.DateHeureSoin.Date == baser))
                {
                    cpt++;
                    baser = date.DateHeureSoin.Date;
                }
            }

            return cpt + 1;
        }
            /// <summary>
            /// Permet d'obtenir le nombre de prestation effectué par un intervenant externe.
            /// </summary>
            /// <returns>la somme totale.</returns>
            public int GetNbPrestationsExternes()
        {
            int cpt = 0;
            foreach (Prestation prestation in this.listePrestations)
            {
                if (prestation.UnIntervenant is IntervenantExterne)
                {
                    cpt++;
                }
            }

            return cpt;
        }
    }
}