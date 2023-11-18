using System.Diagnostics;

namespace MatrixMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            var A = Matrix.CreateSquareMatrix(100);
            var B = Matrix.CreateSquareMatrix(100);

            sw.Start();
            Matrix.MultiplyInOneThread(A, B);
            sw.Stop();
            Console.WriteLine($"One thread: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();

            sw.Start();
            Matrix.MultiplyInNCoresThreads(A, B);
            sw.Stop();
            Console.WriteLine($"Four threads: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();

            sw.Start();
            Matrix.MultiplyInNxNThreads(A, B);
            sw.Stop();
            Console.WriteLine($"NxN threads: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();
        }
    }

    public class Matrix
    {
        private static int MultiplyRowColumn(int[,] A, int[,] B, int row, int col, int n)
        {
            int result = 0;
            for (int k = 0; k < n; k++)
            {
                result += A[row, k] * B[k, col];
            }
            return result;
        }

        // 1
        public static int[,] CreateSquareMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Random.Shared.Next(10);
                }
            }

            return matrix;
        }

        public static int[,] MultiplyInOneThread(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MultiplyRowColumn(A, B, i, j, n);
                }
            }

            return new int[n, n];
        }


        //N = cores count
        public static void MultiplyInNCoresThreads(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);

            if(n % 4 != 0)
            {
                throw new ArgumentException("Matrix size % 4 != 0");
            }

            var t1 = new Thread(() => Multiply(A, B, 0, n / 4));
            var t2 = new Thread(() => Multiply(A, B, n / 4, n /  2));
            var t3 = new Thread(() => Multiply(A, B, n / 2, (n / 4) * 3));
            var t4 = new Thread(() => Multiply(A, B, (n / 4) * 3, n));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
        }

        private static void Multiply(int[,] A, int[,] B, int start, int end)
        {
            int n = A.GetLength(0);

            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        MultiplyRowColumn(A, B, i, j, n);
                    }
                }
            }
        }

        // N x N
        public static int[,] MultiplyInNxNThreads(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] C = new int[n, n];

            Thread[,] threads = new Thread[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int row = i;
                    int col = j;

                    threads[i, j] = new Thread(() =>
                    {
                        C[row, col] = MultiplyRowColumn(A, B, row, col, n);
                    });

                    threads[i, j].Start();
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    threads[i, j].Join();
                }
            }

            return C;
        }
    }
}