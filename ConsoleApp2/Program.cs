using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static int[,] grid = {{1, 2, 3, 4, 5},
            {6,  7,  8,  9,  10},
            {11, 12, 13, 14, 15},
            {16, 17, 18, 19, 20}};

        static List<int> list = grid.Cast<int>().ToList();

        static int firstDim = grid.GetLength(0);
        static int secondDim = grid.GetLength(1);

        static void Main(string[] args)
        {          

            while(list.Count>0) { 
                upRemove(list);
                if (list.Count == 0) break;
                rightRemove(list);
                if (list.Count == 0) break;
                downRemove(list);
                if (list.Count == 0) break;
                leftRemove(list);
                if (list.Count == 0) break;     
            }

            List<int> upRemove(List<int> listToRemove)
            {
                for (int i = 0; i < secondDim; i++)
                {
                    Console.Write(listToRemove[0] + " ");
                    listToRemove.RemoveAt(0);
                }
                firstDim--;
                return listToRemove;
            }

            List<int> rightRemove(List<int> listToRemove)
            {
                for (int i = 0; i < firstDim; i++)
                {
                    Console.Write(listToRemove[(secondDim-1)*(1+i)] + " ");
                    listToRemove.RemoveAt((secondDim-1)*(1+i));
                }
                secondDim--;
                return listToRemove;
            }

            List<int> downRemove(List<int> listToRemove)
            {
                int listCount = list.Count - 1;
                for (int i = 0; i < secondDim; i++)
                {
                    Console.Write(listToRemove[listCount - i] + " ");
                    listToRemove.RemoveAt(listCount - i);
                }
                firstDim--;
                return listToRemove;
            }

            List<int> leftRemove(List<int> listToRemove)
            {
                List<int> tempList = new List<int>();
                for (int i = 0; i < firstDim; i++)
                {
                    int temp = listToRemove[i * (secondDim - 1)];
                    tempList.Add(temp);
                    listToRemove.RemoveAt(i*(secondDim - 1));
                }
                tempList.Reverse();
                foreach (var lr in tempList)
                {
                    Console.Write(lr + " ");
                }
                secondDim--;
                return listToRemove;
            }

            Console.Read();
        }
    }
}
