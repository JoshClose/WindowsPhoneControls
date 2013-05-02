#region License
// Copyright 2011 Josh Close
// This file is a part of CS.Windows.Controls and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
// https://github.com/JoshClose/Windows.Controls
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ExampleApp.WP7
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			DataContext = new MainPageViewModel();
		}

		private void Button_Click( object sender, RoutedEventArgs e )
		{
			( (MainPageViewModel)DataContext ).ButtonClick( sender, e );
		}

		private void Button_Click_1( object sender, RoutedEventArgs e )
		{
			( (MainPageViewModel)DataContext ).FillTextBoxButtonClick( sender, e );
		}

		private void Button_Click_2( object sender, RoutedEventArgs e )
		{
			( (MainPageViewModel)DataContext ).FillPasswordBoxButtonClick( sender, e );
		}

		private void Button_Click_3( object sender, RoutedEventArgs e )
		{
			watermarkTextBoxClick.Focus();
		}

		private void Button_Click_4( object sender, RoutedEventArgs e )
		{
			watermarkPasswordBoxClick.Focus();
		}

        private void Button_Click_5( object sender, RoutedEventArgs e )
        {
            ( (MainPageViewModel)DataContext ).ToggleIsEnabledClick( sender, e );
        }
	}
}