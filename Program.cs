using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Solution
    {
        static Spot[,] MakeReasonableGrid(int r, int c, int pacman_r, int pacman_c, int food_r, int food_c, String[] grid)
        {
            Spot[,] Grid = new Spot[r, c];
            int j_index = 0;
            foreach (string item in grid)
            {
                char[] helper = item.ToCharArray();
                for (int i = 0; i < helper.Length; i++)
                {
                    if (helper[i].ToString() == "%")
                    {
                        Grid[j_index, i] = new Spot(j_index, i, false);
                        continue;
                    }
                    if (helper[i].ToString() == "-")
                    {
                        Grid[j_index, i] = new Spot(j_index, i, true);
                        continue;
                    }
                    else
                    {
                        Grid[j_index, i] = new Spot(j_index, i, true);
                    }
                }
                j_index++;
            }


            for (var i = 0; i < c; i++)
            {
                for (var j = 0; j < r; j++)
                {
                    Grid[j, i].addNeighbors(Grid, c, r);
                }
            }

            return Grid;
        }


        static void dfs(int r, int c, int pacman_r, int pacman_c, int food_r, int food_c, String[] grid)
        {
            //Your logic here
            Stack<Spot> openList = new Stack<Spot>();
            List<Spot> path = new List<Spot>();
            List<Spot> expandedNodes = new List<Spot>();

            //make reasonable grid and add neighbors
            Spot[,] Grid = MakeReasonableGrid(r, c, pacman_r, pacman_c, food_r, food_c, grid);
            
            var start = Grid[pacman_r, pacman_c];
            var end = Grid[food_r, food_c];

            openList.Push(start);

            while (openList.Count > 0)
            {
                var v = openList.Pop();
                expandedNodes.Add(v);

                if (v.Equals(end))
                {
                    path.Add(v);
                    break;
                }
                if (!v.discovered)
                {                    
                    path.Add(v);
                    v.discovered = true;
                    foreach (var item in v.neighbors)
                    {
                        if (item.accessible & !item.discovered)
                        {
                            openList.Push(item);
                        }
                    }
                }
            }
            Console.WriteLine(expandedNodes.Count);
            foreach (var item in expandedNodes)
            {
                Console.WriteLine(item.I + " " + item.J);
            }
            Console.WriteLine(path.Count - 1);
            foreach (var item in path)
            {
                Console.WriteLine(item.I + " " + item.J);
            }

        }
        static void Main(String[] args)
        {
            int r, c;
            int pacman_r, pacman_c;
            int food_r, food_c;

            String pacman = Console.ReadLine();
            String food = Console.ReadLine();
            String pos = Console.ReadLine();

            String[] pos_split = pos.Split(' ');
            String[] pacman_split = pacman.Split(' ');
            String[] food_split = food.Split(' ');

            r = Convert.ToInt32(pos_split[0]);
            c = Convert.ToInt32(pos_split[1]);

            pacman_r = Convert.ToInt32(pacman_split[0]);
            pacman_c = Convert.ToInt32(pacman_split[1]);

            food_r = Convert.ToInt32(food_split[0]);
            food_c = Convert.ToInt32(food_split[1]);

            String[] grid = new String[r];

            for (int i = 0; i < r; i++)
            {
                grid[i] = Console.ReadLine();
            }


            dfs(r, c, pacman_r, pacman_c, food_r, food_c, grid);
        }
    }
}