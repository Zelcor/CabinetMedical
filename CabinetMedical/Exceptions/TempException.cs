// <copyright file="TempException.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;

    /// <summary>
    /// Initializes the <see cref="TempException"/> class.
    /// </summary>
    internal class TempException
    {
        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="TempException"/> class.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        public string ClasseException { get; set; }

        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        public DateTime DateException { get; set; }

        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        public string MessageException { get; set; }

        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        public string UserException { get; set; }

        /// <summary>
        /// Gets or sets initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        public string UserMachine { get; set; }
    }
}
