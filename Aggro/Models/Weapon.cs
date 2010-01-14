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
using System.Diagnostics;

namespace Aggro.Models
{
    public class Weapon : DependencyObject
    {
        private readonly RotateTransform _transform = new RotateTransform { CenterX = 6, CenterY = 12 };

        public Transform Transform
        {
            get { return _transform; }
        }

        public void SetRotation(double rotation)
        {
            Debug.WriteLine(rotation);
            _transform.Angle = rotation;
        }
    }
}
