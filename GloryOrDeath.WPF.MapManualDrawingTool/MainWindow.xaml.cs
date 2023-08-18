using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GloryOrDeath.WPF.MapManualDrawingTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        private List<DotPoint> _edges = new List<DotPoint>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);

                DotPoint dotPoint = new DotPoint { X = currentPoint.X, Y = currentPoint.Y };
                _edges.Add(dotPoint);
            }
        }

        private void Save(object sender, EventArgs e)
        {
            var distincted = _edges.Select(x => new { X = x.X, Y = x.Y }).Distinct().ToList();
            string data = System.Text.Json.JsonSerializer.Serialize(_edges);
            System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "mapEdges.Json"), data);
        }
    }
    public class DotPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

