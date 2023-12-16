﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NorthWind.Sales.Backend.Presenters.ExceptionHandlers.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El acceso al recurso solicitado esta restringido a usuarios autorizados..
        /// </summary>
        internal static string UnauthorizedAccessExceptionDetail {
            get {
                return ResourceManager.GetString("UnauthorizedAccessExceptionDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Acceso no autorizado..
        /// </summary>
        internal static string UnauthorizedAccessExceptionTitle {
            get {
                return ResourceManager.GetString("UnauthorizedAccessExceptionTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Consulte al administrador..
        /// </summary>
        internal static string UnhandledExceptionDetail {
            get {
                return ResourceManager.GetString("UnhandledExceptionDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El servicio no se encuntra disponible..
        /// </summary>
        internal static string UnhandledExceptionTitle {
            get {
                return ResourceManager.GetString("UnhandledExceptionTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se encontraron uno o mas errores de actualizacion de datos. Consulte al administrador..
        /// </summary>
        internal static string UnitOfWorkExceptionDetail {
            get {
                return ResourceManager.GetString("UnitOfWorkExceptionDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error de actualizacion.
        /// </summary>
        internal static string UnitOfWorkExceptionTitle {
            get {
                return ResourceManager.GetString("UnitOfWorkExceptionTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se encontraron uno o mas errores de validacion de datos..
        /// </summary>
        internal static string ValidationExceptionDetail {
            get {
                return ResourceManager.GetString("ValidationExceptionDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error en los datos de entrada..
        /// </summary>
        internal static string ValidationExceptionTitle {
            get {
                return ResourceManager.GetString("ValidationExceptionTitle", resourceCulture);
            }
        }
    }
}
