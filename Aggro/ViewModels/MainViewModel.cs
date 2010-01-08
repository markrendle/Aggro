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
using Aggro.Models;

namespace Aggro.ViewModels
{
    public class MainViewModel
    {
        private readonly Player _player = new Player();

        public Player Player
        {
            get { return _player; }
        }
    }
}
