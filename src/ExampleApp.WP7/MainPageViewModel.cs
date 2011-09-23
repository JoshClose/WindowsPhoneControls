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

		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				RaisePropertyChanged( "Password" );
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
	}
}
