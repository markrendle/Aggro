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

namespace Aggro
{
    public partial class MainPage : UserControl
    {
        private readonly MainViewModel _viewModel;
        private readonly Dictionary<Key, Direction> _directions = new Dictionary<Key, Direction>
        {
            { Key.W, Direction.North },
            { Key.A, Direction.West },
            { Key.S, Direction.South },
            { Key.D, Direction.East }
        };

        public MainPage()
        {
            InitializeComponent();
            IsTabStop = true;
            Focus();
            DataContext = _viewModel = new MainViewModel();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (_directions.ContainsKey(e.Key))
            {
                _viewModel.Player.Movement.AddDirection(_directions[e.Key]);
            }
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (_directions.ContainsKey(e.Key))
            {
                _viewModel.Player.Movement.RemoveDirection(_directions[e.Key]);
            }
        }
    }
}
