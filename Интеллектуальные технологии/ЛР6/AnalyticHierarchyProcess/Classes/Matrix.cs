using System;
using System.Collections.Generic;

namespace AnalyticHierarchyProcess.Classes
{
    public class Matrix
    {
        public double[,] Element { get; set; }
        public int M { get; set; } // Номер строки
        public int N { get; set; } // Номер столбца
        

        /// <summary>
        /// Конструкторы
        /// </summary>
        /// <param name="points"></param>
        public Matrix(Matrix m)
        {
            N = m.N;
            M = m.M; // для Point
            Element = new double[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    Element[i, j] = m.Element[i, j];
        }
        public Matrix(List<Point> points)
        {
            M = points.Count;
            N = 2; // для Point
            Element = new double[M, N];
            for (int i = 0; i < M; i++)
            {
                Element[i, 0] = points[i].X;
                Element[i, 1] = points[i].Y;
            }
        }
        public Matrix(Point[] points)
        {
            N = points.Length;
            M = 2; // для Point
            Element = new double[N, M];
            for (int i = 0; i < N; i++)
            {
                Element[i, 0] = points[i].X;
                Element[i, 1] = points[i].Y;
            }
        }
        public Matrix(Point point)
        {
            N = 2;
            M = 1;
            Element = new double[M, N];
            Element[0, 0] = point.X;
            Element[0, 1] = point.Y;
        }
        public Matrix(double element)
        {
            N = 1;
            M = 1;
            Element = new double[M, N];
            Element[0, 0] = element;
        }
        public Matrix(int m = 2, int n = 2)
        {
            N = n;
            M = m;
            Element = new double[M, N];
        }
        /// <summary>
        /// Транспонирование
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public static Matrix Transpose(Matrix m1) // +
        {
            Matrix m = new Matrix(m1.N, m1.M);
            for (int i = 0; i < m.M; i++)
                for (int j = 0; j < m.N; j++)
                    m.Element[i, j] = m1.Element[j, i];
            return m;
        }
        /// <summary>
        /// Обратная матрица
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public static Matrix Inverse(Matrix m1)
        {
            if (m1.M != m1.N)
                return null;
            int m = m1.M;
            Matrix matrix = new Matrix(m1);
            // Делаем единичную матрицу
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                {
                    if (i == j)
                        matrix.Element[i, j] = 1;
                    else
                        matrix.Element[i, j] = 0;
                }
            // Вычисляем обратную матрицу
            double arg;
            for (int j = 0; j < m; j++)
                for (int i = 0; i < m; i++)
                {
                    if (i == j)
                        continue;
                    arg = m1.Element[i, j] / m1.Element[j, j];
                    for (int k = 0; k < m; k++)
                    {
                        m1.Element[i, k] = m1.Element[i, k] - m1.Element[j, k] * arg;
                        matrix.Element[i, k] = matrix.Element[i, k] - matrix.Element[j, k] * arg;
                    }
                }
            for (int j = 0; j < m; j++)
                for (int i = 0; i < m; i++)
                {
                    if (i == j)
                    {
                        arg = m1.Element[i, j];
                        for (int k = 0; k < m; k++)
                        {
                            m1.Element[i, k] = m1.Element[i, k] / arg;
                            matrix.Element[i, k] = matrix.Element[i, k] / arg;
                        }
                    }
                }
            return matrix;
        }
        /// <summary>
        /// Детерминант матрицы
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public static double Determinant(Matrix m1)
        {
            if (m1.M != m1.N)
                return 0;
            int n = m1.M;
            double result = 0;
            if (n == 1)
                return m1.Element[0, 0];
            else if (n == 2)
                return m1.Element[0, 0] * m1.Element[1, 1] - m1.Element[0, 1] * m1.Element[1, 0];
            for (int k = 0; k < n; k++)
            {
                Matrix m = new Matrix(m1.M - 1, m1.N - 1);
                for (int i = 0; i < m.M; i++)
                    for (int j = 0; j < m.N; j++)
                        m.Element[i, j] = (j < k) ? m1.Element[i + 1, j] : m1.Element[i + 1, j + 1];
                result += Math.Pow(-1, 2 + k) * m1.Element[0, k] * Determinant(m);
            }
            return result;
        }
        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2) // +
        {
            Matrix m = new Matrix(m1.M, m2.N);
            if (m1.M == 1 && m1.N == 1)
            {
                m = m1.Element[0, 0] * m2;
                return m;
            }
            else if (m2.M == 1 && m2.N == 1)
            {
                m = m1 * m2.Element[0, 0];
                return m;
            }
            else if (m1.N != m2.M)
                return null;
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.N; j++)
                    for (int k = 0; k < m2.M; k++)
                        m.Element[i, j] += m1.Element[i, k] * m2.Element[k, j];
            return m;
        }
        public static Point operator *(Matrix m1, Point p) // +
        {
            Matrix m2 = new Matrix(p);
            m2 = Transpose(m2); // Транспонируем
            if (m1.N != m2.M)
                return null;
            Matrix m = new Matrix(m1.M, m2.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.N; j++)
                    for (int k = 0; k < m2.M; k++)
                        m.Element[i, j] += m1.Element[i, k] * m2.Element[k, j];
            p = new Point(m);
            return p;
        }
        public static Point operator *(Point p, Matrix m2)
        {
            Matrix m1 = new Matrix(p);
            if (m1.N != m2.M)
                return null;
            Matrix m = new Matrix(m1.M, m2.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.N; j++)
                    for (int k = 0; k < m2.M; k++)
                        m.Element[i, j] += m1.Element[i, k] * m2.Element[k, j];
            p = new Point(m);
            return p;
        }
        public static Matrix operator *(Matrix m1, double c)
        {
            Matrix m = new Matrix(m1.M, m1.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.M; j++)
                    m.Element[i, j] = m1.Element[i, j] * c;
            return m;
        }
        public static Matrix operator *(double c, Matrix m1)
        {
            Matrix m = new Matrix(m1.M, m1.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.M; j++)
                    m.Element[i, j] = c * m1.Element[i, j];
            return m;
        }
        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator /(Matrix m1, Matrix m2) // +
        {
            Matrix m = new Matrix(m1.M, m2.N);
            if (m1.M == 1 && m1.N == 1)
            {
                m = m1.Element[0, 0] / m2;
                return m;
            }
            else if (m2.M == 1 && m2.N == 1)
            {
                m = m1 / m2.Element[0, 0];
                return m;
            }
            else if (m1.N != m2.M)
                return null;
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.N; j++)
                    for (int k = 0; k < m2.M; k++)
                        m.Element[i, j] += m1.Element[i, k] * (1 / m2.Element[k, j]);
            return m;
        }
        public static Matrix operator /(Matrix m1, double c)
        {
            Matrix m = new Matrix(m1.M, m1.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.M; j++)
                    m.Element[i, j] = m1.Element[i, j] / c;
            return m;
        }
        public static Matrix operator /(double c, Matrix m1)
        {
            Matrix m = new Matrix(m1.M, m1.N);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.M; j++)
                    m.Element[i, j] = c / m1.Element[i, j];
            return m;
        }
        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m1, Matrix m2) // +
        {
            Matrix m = new Matrix(m1.M, m2.N);
            if (m1.M == 1 && m1.M == 1)
            {
                m = m1.Element[0, 0] - m2;
                return m;
            }
            else if (m2.M == 1 && m2.N == 1)
            {
                m = m1 - m2.Element[0, 0];
                return m;
            }
            else if (m1.M != m2.M && m1.N != m2.N)
                return null;
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] - m2.Element[i, j];
            return m;
        }
        public static Matrix operator -(Matrix m1, Point p)
        {
            Matrix m2 = new Matrix(p);
            if (m1.M != m2.M && m1.N != m2.N)
                return null;
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] - m2.Element[i, j];
            return m;
        }
        public static Matrix operator -(Point p, Matrix m2)
        {
            Matrix m1 = new Matrix(p);
            if (m1.M != m2.M && m1.N != m2.N)
                return null;
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] - m2.Element[i, j];
            return m;
        }
        public static Matrix operator -(Matrix m1, double c)
        {
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.N; j++)
                    m.Element[i, j] = m1.Element[i, j] - c;
            return m;
        }
        public static Matrix operator -(double c, Matrix m1)
        {
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.N; j++)
                    m.Element[i, j] = c - m1.Element[i, j];
            return m;
        }
        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix(m1.M, m2.N);
            if (m1.M == 1 && m1.N == 1)
            {
                m = m1.Element[0, 0] + m2;
                return m;
            }
            else if (m2.M == 1 && m2.N == 1)
            {
                m = m1 + m2.Element[0, 0];
                return m;
            }
            else if (m1.M != m2.M && m1.N != m2.N)
                return null;
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] + m2.Element[i, j];
            return m;
        }
        public static Matrix operator +(Matrix m1, Point p)
        {
            Matrix m2 = new Matrix(p);
            if (m1.M != m2.M && m1.N != m2.N)
                return null;
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] + m2.Element[i, j];
            return m;
        }
        public static Matrix operator +(Point p, Matrix m2)
        {
            Matrix m1 = new Matrix(p);
            if (m1.M != m2.M && m1.N != m2.N)
                return null;
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m2.M; j++)
                    m.Element[i, j] = m1.Element[i, j] + m2.Element[i, j];
            return m;
        }
        public static Matrix operator +(Matrix m1, double c)
        {
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.N; j++)
                    m.Element[i, j] = m1.Element[i, j] + c;
            return m;
        }
        public static Matrix operator +(double c, Matrix m1)
        {
            Matrix m = new Matrix(m1.M);
            for (int i = 0; i < m1.M; i++)
                for (int j = 0; j < m1.N; j++)
                    m.Element[i, j] = c + m1.Element[i, j];
            return m;
        }
    }
}
