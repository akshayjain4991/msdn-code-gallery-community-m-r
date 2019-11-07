﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SLBlobUploader.Control {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ApplicationResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApplicationResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SLBlobUploader.Control.ApplicationResources", typeof(ApplicationResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Maximum file size allowed for upload is: {0} Mb..
        /// </summary>
        internal static string IllegalMaxFileSize {
            get {
                return ResourceManager.GetString("IllegalMaxFileSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File should not be empty..
        /// </summary>
        internal static string IllegalMinFileSize {
            get {
                return ResourceManager.GetString("IllegalMinFileSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a file to upload..
        /// </summary>
        internal static string NoFileSelected {
            get {
                return ResourceManager.GetString("NoFileSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your upload session has expired. Reload the page to create a fresh upload session and upload the file again..
        /// </summary>
        internal static string SASExpired {
            get {
                return ResourceManager.GetString("SASExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File of size {0} has been uploaded successfully in {1} seconds..
        /// </summary>
        internal static string SuccessfulUpload {
            get {
                return ResourceManager.GetString("SuccessfulUpload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File could not be uploaded due to an unknown error. Retry after sometime..
        /// </summary>
        internal static string UnknownErrorOccured {
            get {
                return ResourceManager.GetString("UnknownErrorOccured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File upload has been cancelled..
        /// </summary>
        internal static string UploadCancelled {
            get {
                return ResourceManager.GetString("UploadCancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File could not be uploaded because {0}..
        /// </summary>
        internal static string UploadFailed {
            get {
                return ResourceManager.GetString("UploadFailed", resourceCulture);
            }
        }
    }
}
