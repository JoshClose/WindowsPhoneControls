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
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CS.Windows.Controls
{
	public class WatermarkTextBox : TextBox
	{
		private Brush originalForeground;
		private ContentControl watermarkContent;
		private bool hasFocus;

		public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register( "WatermarkText", typeof( string ), typeof( WatermarkTextBox ), null );

		public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.Register( "WatermarkStyle", typeof( Style ), typeof( WatermarkTextBox ), null );

		public static readonly DependencyProperty FocusedForegroundProperty = DependencyProperty.Register( "FocusedForeground", typeof( Brush ), typeof( WatermarkTextBox ), null );

		public string WatermarkText
		{
			get { return (string)GetValue( WatermarkTextProperty ); }
			set { SetValue( WatermarkTextProperty, value ); }
		}

		public Style WatermarkStyle
		{
			get { return (Style)GetValue( WatermarkStyleProperty ); }
			set { SetValue( WatermarkStyleProperty, value ); }
		}

		public Brush FocusedForeground
		{
			get { return (Brush)GetValue( FocusedForegroundProperty ); }
			set { SetValue( FocusedForegroundProperty, value ); }
		}

		public WatermarkTextBox()
		{
			DefaultStyleKey = typeof( WatermarkTextBox );
			TextChanged += WatermarkTextBoxTextChanged;
		}

		private void WatermarkTextBoxTextChanged( object sender, TextChangedEventArgs e )
		{
			if( !hasFocus )
			{
				SetWatermarkVisibility();
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			originalForeground = Foreground;
			watermarkContent = (ContentControl)GetTemplateChild( "WatermarkElement" );
			SetWatermarkVisibility();
		}

		protected override void OnGotFocus( RoutedEventArgs e )
		{
			base.OnGotFocus( e );
			hasFocus = true;
			watermarkContent.Visibility = Visibility.Collapsed;
			Foreground = FocusedForeground;
		}

		protected override void OnLostFocus( RoutedEventArgs e )
		{
			base.OnLostFocus( e );
			hasFocus = false;
			SetWatermarkVisibility();
			Foreground = originalForeground;
		}

		private void SetWatermarkVisibility()
		{
			watermarkContent.Visibility = string.IsNullOrEmpty( Text ) ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
