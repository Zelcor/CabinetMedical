// <copyright file="Intervenant.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Initializes the <see cref="Intervenant"/> class.
    /// </summary>
    public class Intervenant
    {
        private string nom;
        private string prénom;
        private Collection<Prestation> prestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous retrouvons le nom de l'intervenant externe. </param>
        /// <param name="prénom"> Ici nous retrouvons le prénom l'intervenant externe. </param>
        public Intervenant(string nom, string prénom)
        {
            this.nom = nom;
            this.prénom = prénom;
            this.prestations = new Collection<Prestation>();
        }

        /// <summary>
        /// Gets nom de l'intervenant.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets prénom de l'intervenant.
        /// </summary>
        public string Prénom { get => this.prénom; }

        /// <summary>
        /// Ajoute une prestation.
        /// </summary>
        /// <param name="prestation"> Ici nous retrouvons la prestations qui est ajoutée. </param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        /// <summary>
        /// Méthode qui récuppère le nombre total de prestations.
        /// </summary>
        /// <returns> Nombre total de prestations. </returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }
    }
}
