using System;


namespace Dijkstra
{
    class Program
    {
        class MatrixOfRelationships
        {
            int numberVertices; int[] wayToVertexDestination;
            int[,] matrix; int[] vertices; int[] shortestWays;
            
            public void SetRelations(int numberVertices)
            {
                this.numberVertices = numberVertices;
                matrix = new int[numberVertices, numberVertices];
                
                for(int i=0; i < numberVertices; i++)
                {
                    for(int k = i + 1; k < numberVertices; k++)
                    {
                        Console.Write("Введите вес " +
                            "ребра для вершин " + (i+1) + "-" + (k+1) + ": ");
                        
                        while(true)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out int weight))
                            {
                                matrix[i, k] = matrix[k, i] = weight;
                                break;
                            }

                            Console.WriteLine("Значение должно быть целым положительным числом!");
                            Console.Write("Введите вес " +
                            "ребра для вершин " + (i + 1) + "-" + (k + 1) + ": ");
                        }
                    }
                }
            }
            
            private void PrintResult()
            {
                if(matrix != null)
                {
                    for (int i = 0; i < numberVertices; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        
                        for (int k = 0; k < numberVertices; k++)
                            Console.Write(matrix[i, k] + " ");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Кратчайшие пути равны: ");
                    Console.WriteLine();

                    for (int l = 1; l < numberVertices; l++)
                        Console.Write(shortestWays[l] + " ");
                }
                else
                    Console.WriteLine("Отсутствует матрица отношений!");
            }

            private void Dijkstra()
            {
                int quantityUnvisitedVertices = numberVertices;
                vertices = new int[numberVertices]; shortestWays = new int[numberVertices];
                
                for(int i=1; i < numberVertices; i++)
                    shortestWays[i] = matrix[0, i];
                
                int currentVertex = 1;
                while(quantityUnvisitedVertices > 1)
                {
                    for (int i = 0; i < numberVertices; i++)
                    {
                        if (matrix[currentVertex, i] > 0)
                        {
                            int way = matrix[currentVertex, i] + shortestWays[currentVertex];

                            if (way < shortestWays[i] || shortestWays[i] == 0)
                                shortestWays[i] = way;
                        }
                    }
                    
                    vertices[currentVertex] = -1;
                    quantityUnvisitedVertices--;
                    
                    int index = 0;
                    for(int j=1; j < numberVertices; j++)
                    {
                        if (vertices[j] != -1 && shortestWays[j] != 0)
                        {
                            if( j != 1 )
                            {
                                if (shortestWays[j] < shortestWays[index])
                                    index = j;
                            }
                            else
                                index = 1;
                        }                
                    }
                    
                    currentVertex = index;
                }
            }

            public void CalculatePathToVertex(int vertex)
            {
                Dijkstra();
                PrintResult();

                wayToVertexDestination = new int[numberVertices];
                wayToVertexDestination[0] = vertex;

                int index = vertex - 1;
                int mark = shortestWays[index];
                
                bool end = false;
                for (int i=1; i < numberVertices; i++)
                {
                    if(end)
                        break;

                    for (int j=0; j < numberVertices; j++)
                    {
                        if(matrix[index, j] != 0)
                        {
                            if (mark - matrix[index, j] == 0)
                            {
                                wayToVertexDestination[i] = 1;
                                end = true;
                                break;
                            }
                            
                            if(mark - matrix[index, j] == shortestWays[j])
                            {
                                wayToVertexDestination[i] = j + 1;
                                index = j;
                                mark = shortestWays[j];
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Кратчайший путь до вершины " + vertex +
                    ": ");

                for(int k = numberVertices - 1; k >= 0; k--)
                {
                    if(wayToVertexDestination[k] != 0)
                        Console.Write(wayToVertexDestination[k] + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            MatrixOfRelationships matrix = new MatrixOfRelationships();

            matrix.SetRelations(5);
            matrix.CalculatePathToVertex(5);
            
            Console.ReadKey();
        }
    }
}