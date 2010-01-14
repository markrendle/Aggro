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
using Aggro.Models;
using Aggro.Engine;
using Aggro.ViewModels;
using Aggro.Converters;

namespace Aggro
{
    public partial class MainPage : UserControl
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            IsTabStop = true;
            Focus();

            Input.Default.SetDirectionSources(
                KeyToDirectionConverter.ToDirections(this)
                );

            Input.Default.SetMouseLeftButtonSources(MouseToPointConverter.LeftButtonToPoints(this));

            Input.Default.SetMouseRightButtonSources(MouseToPointConverter.RightButtonToPoints(this));

            Input.Default.SetMouseMoveSource(MouseToPointConverter.MoveToPoints(this));

            DataContext = _viewModel = new MainViewModel();
        }
    }
}
