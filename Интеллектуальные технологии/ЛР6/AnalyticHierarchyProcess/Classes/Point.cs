using System;

namespace AnalyticHierarchyProcess.Classes
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(Matrix m)
        {
            if (m.N != 2 && m.M!= 1)
                return;
            X = m.Element[0, 0];
            Y = m.Element[1, 0];
        }
        /// <summary>
        /// Длина
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        /// <summary>
        /// Скалярное произведение
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double operator *(Point p1, Point p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
        /// <summary>
        /// Произведение на число
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Point operator *(Point p1, double c)
        {
            return new Point (p1.X * c, p1.Y * c);
        }
        public static Point operator *(double c, Point p1)
        {
            return new Point(c * p1.X, c * p1.Y);
        }
        /// <summary>
        /// Деление на число
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator /(double c, Point p1)
        {
            return new Point(c / p1.X, c / p1.Y);
        }
        public static Point operator /(Point p1, double c)
        {
            return new Point(p1.X / c, p1.Y / c);
        }
    }
}
