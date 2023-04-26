using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplab_10
{
    namespace Point3D_
    {
        public class Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        public class PointsChangedEventArg : EventArgs
        {
            public Point3D[] Points { get; set; }
        }
        // делегат
        public delegate void PointsChangedEventHandler(object sender, PointsChangedEventArg e);

        public class Point3DList
        {
            private Point3D[] _points;

            public event PointsChangedEventHandler PointsChanged;

            public Point3DList(Point3D[] points)
            {
                _points = points;
            }

            public Point3D[] Points
            {
                get
                {
                    return _points;
                }
                set
                {
                    _points = value;
                    OnPointsChanged(new PointsChangedEventArg { Points = value });
                }
            }

            protected virtual void OnPointsChanged(PointsChangedEventArg e)
            {
                PointsChanged?.Invoke(this, e);
            }
        }
    }
}
