using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace AppEscritorio.UI.UserControls
{
    /// <summary>
    /// Lógica de interacción para ControlBar.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
		public static readonly DependencyProperty ParentWindowProperty =
		DependencyProperty.Register("ParentWindow", typeof(Window), typeof(ControlBar), new PropertyMetadata(null));

		public Window ParentWindow
		{
			get { return (Window)GetValue(ParentWindowProperty); }
			set { SetValue(ParentWindowProperty, value); }
		}
		public ControlBar()
        {
            InitializeComponent();
        }

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			if(ParentWindow != null)
			{
				ParentWindow.WindowState = WindowState.Minimized;
			}
			
		}

		private void btnMaximize_Click(object sender, RoutedEventArgs e)
		{
			if(ParentWindow != null)
			{
				if (ParentWindow.WindowState == WindowState.Normal) { ParentWindow.WindowState = WindowState.Maximized; }
				else { ParentWindow.WindowState = WindowState.Normal; }
			}
			
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			if(ParentWindow != null)
			{
				Application.Current.Shutdown();
			}
			
		}
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if(ParentWindow != null)
			{
				WindowInteropHelper helper = new WindowInteropHelper(ParentWindow);
				SendMessage(helper.Handle, 161, 2, 0);
			}
			
		}
		private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
		{
			if(ParentWindow != null)
			{
				ParentWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			}
			
		}

	}
}
