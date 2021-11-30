/************************************************************************
   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at https://opensource.org/licenses/MS-PL
 ************************************************************************/

using System;

namespace WinIO.AvalonDock.Themes
{
    /// <inheritdoc/>
    public class GenericTheme : Theme
    {
        /// <inheritdoc/>
        public override Uri GetResourceUri()
        {
            return new Uri("/WinIO;component/Themes/Generic.xaml", UriKind.Relative);
        }
    }
}