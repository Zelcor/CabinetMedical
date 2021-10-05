// <copyright file="CabinetMedicalException.cs" company="Clément LOZE">
// Copyright (c) Clément LOZE. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Initializes the <see cref="CabinetMedicalException"/> class.
    /// </summary>
    internal class CabinetMedicalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        /// <param name="message"> message. </param>
        public CabinetMedicalException(string message)
            : base(message)
        {
            TempException tempException = new TempException();

            var methodInfo = MethodBase.GetCurrentMethod();
            var fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
            tempException.Application = Assembly.GetExecutingAssembly().GetName().Name;
            tempException.ClasseException = fullName;
            tempException.DateException = DateTime.Now;
            tempException.MessageException = message;
            tempException.UserException = Environment.UserName;
            tempException.UserMachine = Environment.MachineName;

            // Json j = new Json(tempException.Application, tempException.ClasseException, tempException.DateException, tempException.MessageException, tempException.UserException, tempException.UserMachine);
            // jaddError();
        }

// public
    }
}
