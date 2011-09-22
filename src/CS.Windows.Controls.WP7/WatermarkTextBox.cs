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

		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register( "Watermark", typeof( string ), typeof( WatermarkTextBox ), null );

		public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.Register( "WatermarkStyle", typeof( Style ), typeof( WatermarkTextBox ), null );

		public static readonly DependencyProperty WatermarkForegroundProperty = DependencyProperty.Register( "WatermarkForeground", typeof( Brush ), typeof( WatermarkTextBox ), null );

		public static readonly DependencyProperty FocusedForegroundProperty = DependencyProperty.Register( "FocusedForeground", typeof( Brush ), typeof( WatermarkTextBox ), null );

		public string Watermark
		{
			get { return (string)GetValue( WatermarkProperty ); }
			set { SetValue( WatermarkProperty, value ); }
		}

		public Style WatermarkStyle
		{
			get { return (Style)GetValue( WatermarkStyleProperty ); }
			set { SetValue( WatermarkStyleProperty, value ); }
		}

		public Brush WatermarkForeground
		{
			get { return (Brush)GetValue( WatermarkForegroundProperty ); }
			set { SetValue( WatermarkForegroundProperty, value ); }
		}

		public Brush FocusedForeground
		{
			get { return (Brush)GetValue( FocusedForegroundProperty ); }
			set { SetValue( FocusedForegroundProperty, value ); }
		}

		public WatermarkTextBox()
		{
			DefaultStyleKey = typeof( WatermarkTextBox );
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

			SetWatermarkVisibility();
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
			watermarkContent.Visibility = string.IsNullOrEmpty( Text ) ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
