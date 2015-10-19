﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="AssemblyLoadingHelper.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the AssemblyLoadingHelper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace ARAManager.Business.Dao.NHibernate.Helper {
    /// <summary>
    /// Assembly loading helper class
    /// </summary>
    public static class AssemblyLoadingHelper {
        /// <summary>
        /// Gets an already loaded assembly or loads it if necessary.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns>The loaded assembly.</returns>
        public static Assembly GetOrLoadAssembly(string assemblyName) {
            // Is assembly already loaded?
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly t in asms) {
                AssemblyName name = t.GetName();

                // Check for short and full name
                if (name.FullName == assemblyName || name.Name == assemblyName) {
                    return t;
                }
            }
            // Not found --> load it explicitly
            return Assembly.Load(assemblyName);
        }
    }
}
