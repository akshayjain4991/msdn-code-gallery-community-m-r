﻿// <copyright file="IOverlayMetadataView.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: IOverlayMetadataView.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Modules.Metadata.Views
{
    public interface IOverlayMetadataView
    {
        /// <summary>
        /// Gets or sets the value for the <see cref="IOverlayMetadataViewPresentationModel"/>.
        /// </summary>
        /// <value>The model.</value>
        IOverlayMetadataViewPresentationModel Model { get; set; }
    }
}