#region License
// Copyright 2011 Josh Close
// This file is a part of CS.Windows.Controls and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
// https://github.com/JoshClose/Windows.Controls
#endregion
using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ExampleApp.WP7
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private string password;
		private string preFilledText = "this is the text";
		private string fillOnClickText;
		private string fillOnClickPassword;

		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				RaisePropertyChanged( "Password" );
			}
		}

		public string PreFilledText
		{
			get { return preFilledText; }
			set
			{
				preFilledText = value;
				RaisePropertyChanged( "PreFilledText" );
			}
		}

		public string FillOnClickText
		{
			get { return fillOnClickText; }
			set
			{
				fillOnClickText = value;
				RaisePropertyChanged( "FillOnClickText" );
			}
		}

		public string FillOnClickPassword
		{
			get { return fillOnClickPassword; }
			set
			{
				fillOnClickPassword = value;
				RaisePropertyChanged( "FillOnClickPassword" );
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged( string propertyName )
		{
			if( PropertyChanged != null )
			{
				PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
			}
		}

		public void ButtonClick( object sender, RoutedEventArgs e)
		{
			var x = "";
		}

		public void FillTextBoxButtonClick( object sender, RoutedEventArgs e )
		{
			FillOnClickText = "this is the text";
		}

		public void FillPasswordBoxButtonClick( object sender, RoutedEventArgs e )
		{
			FillOnClickPassword = "this is the password";
		}
	}
}
