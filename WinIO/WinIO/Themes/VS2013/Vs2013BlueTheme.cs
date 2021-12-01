/************************************************************************
   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at https://opensource.org/licenses/MS-PL
 ************************************************************************/

using System;

namespace WinIO.Themes.VS2013
{
    /// <inheritdoc/>
    public class Vs2013BlueTheme : Theme
    {
        /// <inheritdoc/>
        public override Uri GetResourceUri()
        {
            return new Uri(
                "/WinIO;compoent/Themes/VS2013/BlueTheme.xaml",
                UriKind.Relative);
        }
    }
}
