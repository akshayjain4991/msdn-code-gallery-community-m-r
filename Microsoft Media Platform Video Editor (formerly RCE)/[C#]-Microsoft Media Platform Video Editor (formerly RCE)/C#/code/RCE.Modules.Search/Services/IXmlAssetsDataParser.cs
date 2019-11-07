﻿// <copyright file="IXmlAssetsDataParser.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: IXmlAssetsDataParser.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Modules.Search.Services
{
    using System;
    using System.Collections.Generic;
    using RCE.Infrastructure;
    using RCE.Infrastructure.Models;

    public interface IXmlAssetsDataParser
    {
        event EventHandler<DataEventArgs<List<Asset>>> ResultsAvailable;

        void ParseAssets(string assetsXml, long cdnTime);
    }
}
