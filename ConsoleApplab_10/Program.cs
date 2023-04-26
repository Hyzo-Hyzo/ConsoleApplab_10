using ConsoleApplab_10.Point3D_;

namespace ConsoleApplab_10
{
    public class Program
    {
        public static double Distance(Point3D point1, Point3D point2)
        {
            double xDiff = point1.X - point2.X;
            double yDiff = point1.Y - point2.Y;
            double zDiff = point1.Z - point2.Z;
           
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff + zDiff * zDiff);
        }

        public static void MaxDistance(Point3D[] points, out Point3D point1, out Point3D point2, out double maxDistance)
        {
            maxDistance = 0;
            point1 = null;
            point2 = null;

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = Distance(points[i], points[j]);

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        point1 = points[i];
                        point2 = points[j];
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Point3D[] points = new Point3D[3];
            points[0] = new Point3D(1, 2, 3);
            points[1] = new Point3D(4, 5, 6);
            points[2] = new Point3D(7, 8, 9);

            Point3DList pointList = new Point3DList(points);

            pointList.PointsChanged += (sender, e) =>
            {
                Console.WriteLine("Points changed:");
                foreach (var point in e.Points)
                {
                    Console.WriteLine($"({point.X}, {point.Y}, {point.Z})");
                }
            };

            Console.WriteLine("Initial points:");
            foreach (var point in pointList.Points)
            {
                Console.WriteLine($"({point.X}, {point.Y}, {point.Z})");
            }
            

            Point3D point1;
            Point3D point2;
            double maxDistance;

            Console.WriteLine($"Distance between point1 and point2 is {Distance(points[0], points[1])}");
            MaxDistance(pointList.Points, out point1, out point2, out maxDistance);

            Console.WriteLine($"Max distance between points ({point1.X}, {point1.Y}, {point1.Z}) and ({point2.X}, {point2.Y}, {point2.Z}) is {maxDistance}");
            
        }
    }

}