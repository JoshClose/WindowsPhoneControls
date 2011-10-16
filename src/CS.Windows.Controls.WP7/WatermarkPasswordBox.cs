#region License
// Copyright 2011 Josh Close
// This file is a part of CS.Windows.Controls and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
// https://github.com/JoshClose/WindowsPhoneControls
#endregion
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CS.Windows.Controls
{
	public class WatermarkPasswordBox : Control
	{
		private Brush originalForeground;
		private WatermarkTextBox watermarkTextBox;
		private PasswordBox passwordBox;
		private string passwordSetBeforeTemplateApplied;

		public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register( "Password", typeof( string ), typeof( WatermarkPasswordBox ), new PropertyMetadata( OnPasswordPropertyChanged ) );

		public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register( "WatermarkText", typeof( string ), typeof( WatermarkPasswordBox ), null );

		public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.Register( "WatermarkStyle", typeof( Style ), typeof( WatermarkPasswordBox ), null );

		public static readonly DependencyProperty FocusedForegroundProperty = DependencyProperty.Register( "FocusedForeground", typeof( Brush ), typeof( WatermarkPasswordBox ), null );

		public static readonly DependencyProperty SelectionBackgroundProperty = DependencyProperty.Register( "SelectionBackground", typeof( Brush ), typeof( WatermarkPasswordBox ), null );

		public static readonly DependencyProperty SelectionForegroundProperty = DependencyProperty.Register( "SelectionForeground", typeof( Brush ), typeof( WatermarkPasswordBox ), null );

		public string Password
		{
			get { return GetValue( PasswordProperty ) as string; }
			set { SetValue( PasswordProperty, value ); }
		}

		public string WatermarkText
		{
			get { return GetValue( WatermarkTextProperty ) as string; }
			set { SetValue( WatermarkTextProperty, value ); }
		}

		public Style WatermarkStyle
		{
			get { return GetValue( WatermarkStyleProperty ) as Style; }
			set { SetValue( WatermarkStyleProperty, value ); }
		}

		public Brush FocusedForeground
		{
			get { return GetValue( FocusedForegroundProperty ) as Brush; }
			set { SetValue( FocusedForegroundProperty, value ); }
		}

		public Brush SelectionBackground
		{
			get { return GetValue( SelectionBackgroundProperty ) as Brush; }
			set { SetValue( SelectionForegroundProperty, value ); }
		}

		public Brush SelectionForeground
		{
			get { return GetValue( SelectionForegroundProperty ) as Brush; }
			set { SetValue( SelectionForegroundProperty, value ); }
		}

		public WatermarkPasswordBox()
		{
			DefaultStyleKey = typeof( WatermarkPasswordBox );
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			originalForeground = Foreground;

			watermarkTextBox = (WatermarkTextBox)GetTemplateChild( "WatermarkElement" );
			passwordBox = (PasswordBox)GetTemplateChild( "ContentElement" );
			passwordBox.PasswordChanged += PasswordBoxPasswordChanged;
			if( !string.IsNullOrEmpty( passwordSetBeforeTemplateApplied ) )
			{
				passwordBox.Password = passwordSetBeforeTemplateApplied;
			}

			SetWatermarkVisibility();
		}

		protected override void OnGotFocus( RoutedEventArgs e )
		{
			base.OnGotFocus( e );

			watermarkTextBox.Opacity = 0;
			passwordBox.Opacity = 1;
			Foreground = FocusedForeground;
		}

		protected override void OnLostFocus( RoutedEventArgs e )
		{
			base.OnLostFocus( e );

			SetWatermarkVisibility();
			Foreground = originalForeground;
		}

		private void SetWatermarkVisibility()
		{
			watermarkTextBox.Opacity = string.IsNullOrEmpty( Password ) ? 1 : 0;
			passwordBox.Opacity = !string.IsNullOrEmpty( Password ) ? 1 : 0;
		}

		#region Password Binding Hack

		// This is a hack to bind this control's Password property
		// to the template's PasswordBox.Password property.
		// Using Password="{TemplateBinding Password}" does not
		// work for some reason.

		public static void OnPasswordPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			( (WatermarkPasswordBox)d ).OnPasswordChanged( d, e );
		}

		private void OnPasswordChanged(  DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			if( passwordBox == null )
			{
				passwordSetBeforeTemplateApplied = Password;
				return;
			}

			if( Password != passwordBox.Password )
			{
				passwordBox.Password = Password;
				SetWatermarkVisibility();
			}
		}

		private void PasswordBoxPasswordChanged( object sender, RoutedEventArgs e )
		{
			if( passwordBox.Password != Password )
			{
				Password = passwordBox.Password;
			}
		}

		#endregion
	}
}
