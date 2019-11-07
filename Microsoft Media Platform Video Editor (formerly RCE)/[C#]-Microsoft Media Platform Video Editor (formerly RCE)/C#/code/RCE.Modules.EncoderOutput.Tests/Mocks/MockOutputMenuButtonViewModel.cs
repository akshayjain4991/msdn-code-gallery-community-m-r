﻿// <copyright file="MockOutputMenuButtonViewModel.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: MockOutputMenuButtonViewModel.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Modules.EncoderOutput.Tests.Mocks
{
    using RCE.Infrastructure.Menu;

    public class MockOutputMenuButtonViewModel : IMenuButtonViewModel
    {
        public IMenuButtonView View { get; set; }

        public object ViewToDisplay { get; set; }

        public bool IsViewActive { get; set; }

        public string Text { get; set; }
    }
}
