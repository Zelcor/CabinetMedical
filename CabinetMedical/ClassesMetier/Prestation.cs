// <copyright file="Prestation.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Initializes the <see cref="Prestation"/> class.
    /// </summary>
    internal class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant unIntervenant;
        private IntervenantExterne unIntervenantExterne;

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle"> Ici nous retrouvons le libelle de la prestation. </param>
        /// <param name="dateHeureSoin"> Ici nous retrouvons la date et l'heure de la prestation. </param>
        /// <param name="unIntervenant"> Ici nous retrouvosn l'intervenant de la classe Intervenant. </param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant unIntervenant)
        {
            this.libelle = libelle;
            this.dateHeureSoin = dateHeureSoin;
            this.unIntervenant = unIntervenant;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle"> Ici nous retrouvons le libelle de la prestation. </param>
        /// <param name="dateHeureSoin"> Ici nous retrouvons la date et l'heure de la prestation. </param>
        /// <param name="unIntervenantExterne"> Ici nous retrouvosn l'intervenant de la classe IntervenantExterne. </param>
        public Prestation(string libelle, DateTime dateHeureSoin, IntervenantExterne unIntervenantExterne)
        {
            this.libelle = libelle;
            this.dateHeureSoin = dateHeureSoin;
            this.unIntervenantExterne = unIntervenantExterne;
        }

        /// <summary>
        /// Gets or Sets libelle.
        /// </summary>
        public string Libelle { get => this.libelle; set => this.libelle = value; }

        /// <summary>
        /// Gets or Sets dateHeureSoin.
        /// </summary>
        public DateTime DateHeureSoin { get => this.dateHeureSoin; set => this.dateHeureSoin = value; }

        /// <summary>
        /// Gets un intervenant.
        /// </summary>
        public Intervenant UnIntervenant { get => this.unIntervenant; }

        /// <summary>
        /// Gets un intervenant externe.
        /// </summary>
        public IntervenantExterne UnIntervenantExterne { get => this.unIntervenantExterne; }

        /// <summary>
        /// Methode qui compare 2 prestations.
        /// </summary>
        /// <param name="a"> 1ère prestation à être comparée. </param>
        /// <param name="b"> 2ème prestation à être comparée. </param>
        /// <returns> comparaison. </returns>
        public static int CompareTo(Prestation a, Prestation b)
        {
            return DateTime.Compare(a.dateHeureSoin.Date, b.DateHeureSoin.Date);
        }
    }
}