using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10__4_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = 
            {
                //1  2  3  4  5  6  7  8
                {-1,120,60,-1,-1,-1,-1,-1},  //1
				{120,-1,-1,-1,-1,70,100,-1}, //2 
				{60,-1,-1,30,100,120,-1,-1}, //3 
				{-1,-1,30,-1,-1,-1,-1,-1},   //4
				{-1,-1,100,-1,-1,-1,-1,50},  //5
				{-1,70,120,-1,50,-1,60,20},  //6
				{-1,100,-1,-1,-1,60,-1,-1},  //7
				{-1,-1,-1,-1,50,20,-1,-1}    //8
			};

            Graph graph = new Graph(arr, 8);

            Console.WriteLine("Введите номер города от 1-8\n");
            int X = int.Parse(Console.ReadLine());
            while (X == 0 || X > 8)
            {
                Console.WriteLine("Значение введено не верно.Введите верное значение от 1 до 8:");
                X = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Маршруты:\n");
            for (int j = 0; j < 8; j++)
            {
                if (X != j + 1)
                {
                    Stack<int> BFS = graph.BFS(X - 1, j);
                    PrintPath(BFS,arr);
                }
            }

        }
        private static void PrintPath(Stack<int> path,int[,] arr)
        {
            if (path.Count == 0)
            {
                Console.WriteLine("Путь не найден");
            }
            else
            {
                int [] matrix =path.ToArray();
                int sum = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (i + 1 == matrix.Length) { break; }
                    sum += arr[matrix[i], matrix[i + 1]];
                }
                if (sum <= 200)
                {
                    Console.WriteLine(string.Join(" -> ", path.Select(x => (x + 1).ToString())) + "(" + sum + "км)");
                }
            }

        }

    }
}
