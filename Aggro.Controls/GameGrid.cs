using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Aggro.Controls
{
    public class GameGrid : Grid
    {
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register("ColumnCount", typeof(int), typeof(GameGrid),
            new PropertyMetadata(0, (o, a) => ((GameGrid)o).ColumnCountChanged()));

        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.Register("RowCount", typeof(int), typeof(GameGrid),
            new PropertyMetadata(0, (o, a) => ((GameGrid)o).RowCountChanged()));

        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        public int RowCount
        {
            get { return (int)GetValue(RowCountProperty); }
            set { SetValue(RowCountProperty, value); }
        }

        private void ColumnCountChanged()
        {
            ColumnDefinitions.Clear();

            ColumnCount.Times().Do(() =>
                {
                    ColumnDefinitions.Add(new ColumnDefinition());
                });

            OnApplyTemplate();
        }

        private void RowCountChanged()
        {
            RowDefinitions.Clear();

            RowCount.Times().Do(() =>
                {
                    RowDefinitions.Add(new RowDefinition());
                });

            OnApplyTemplate();
        }
    }
}
