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
using System.Diagnostics;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            Debug.WriteLine("Constructor");
            InitializeComponent();
            IsTabStop = true;
            Focus();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            var sb = block.Resources["mover"] as Storyboard;
            if (sb != null)
            {
                sb.Begin();
            }
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            var sb = block.Resources["mover"] as Storyboard;
            if (sb != null)
            {
                var pt = block.GetCanvasLocation();
                pt = block.RenderTransform.Transform(pt);
                sb.Stop();
                block.SetCanvasLocation(pt);
                block.SetValue(Canvas.LeftProperty, pt.X);
                block.SetValue(Canvas.TopProperty, pt.Y);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = block.Resources["mover"] as Storyboard;
            var da = sb.Children[0] as DoubleAnimation;
            da.Completed += da_Completed;
        }

        void da_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("da_Completed");
        }
    }
}
