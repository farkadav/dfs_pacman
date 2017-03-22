using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Spot
    {
       
        public Spot(int i, int j, Boolean Accessible)
        {
            I = i;
            J = j;
            f = 0;
            g = 0;
            h = 0;
            neighbors = new List<Spot>();
            accessible = Accessible;
            discovered = false;
        }

        public int I { get; set; }
        public int J { get; set; }
        public double f { get; set; }   //cost function
        public double h { get; set; }   // heuristics
        public double g { get; set; }   //cost
        public List<Spot> neighbors { get; set; }
        public Boolean accessible { get; set; }
        public Boolean discovered { get; set; }

        public void addNeighbors(Spot[,] grid, int c, int r)
        {
            int i = I;
            int j = J;
            if (i < r-1)    neighbors.Add(grid[i + 1, j]);          
            if (i > 0)      neighbors.Add(grid[i - 1, j]);       
            if (j > 0 )     neighbors.Add(grid[i, j - 1]);
            if (j < c - 1)  neighbors.Add(grid[i, j + 1]);
           
        }   
    }
}
