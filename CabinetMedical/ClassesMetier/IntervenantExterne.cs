// <copyright file="IntervenantExterne.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Initializes the <see cref="IntervenantExterne"/> class.
    /// </summary>
    internal class IntervenantExterne : Intervenant
    {
        private string spécialité;
        private string adresse;
        private string tel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom"> Ici nous retrouvons le nom de l'intervenant externe. </param>
        /// <param name="prénom"> Ici nous retrouvons le prénom l'intervenant externe. </param>
        /// <param name="spécialité"> Ici nous retrouvons la spécialité de l'intervenant externe. </param>
        /// <param name="adresse"> Ici nous retrouvons l'addresse de l'intervenant externe. </param>
        /// <param name="tel"> Ici nous retrouvons le numéro de téléphone de l'intervenant externe. </param>
        public IntervenantExterne(string nom, string prénom, string spécialité, string adresse, string tel)
            : base(nom, prénom)
        {
            this.spécialité = spécialité;
            this.adresse = adresse;
            this.tel = tel;
        }

        /// <summary>
        /// Gets spécialitée.
        /// </summary>
        public string Spécialité { get => this.spécialité; }

        /// <summary>
        /// Gets or Sets addresse.
        /// </summary>
        public string Adresse { get => this.adresse; set => this.adresse = value; }

        /// <summary>
        /// Gets or Sets numéro de téléphone.
        /// </summary>
        public string Tel { get => this.tel; set => this.tel = value; }
    }
}
