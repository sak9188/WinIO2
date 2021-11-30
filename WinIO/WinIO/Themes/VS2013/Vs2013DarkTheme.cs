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
	public class Vs2013DarkTheme : Theme
	{
		/// <inheritdoc/>
		public override Uri GetResourceUri()
		{
			return new Uri(
				"/WinIO;component/Themes/VS2013/DarkTheme.xaml",
				UriKind.Relative);
		}
	}
}
