using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Part1
    {
        static Grid grid;
        static List<AntennaCollection> antennaCollections = new List<AntennaCollection>();
        static List<Point> antinodes = new List<Point>();

        static public int GetAnswer(Grid input)
        {
            grid = input;
            RetrieveAntennas(grid);
            
            foreach (AntennaCollection antennaCollection in antennaCollections)
            {
                for (int i = 0; i < antennaCollection.size; i++)
                {
                    for (int j = i + 1; j < antennaCollection.size; j++)
                    {
                        AddAntinodesFromAntennaPair(antennaCollection[i], antennaCollection[j]);
                    }
                }
            }
            return antinodes.Count;
        }

        static void AddAntinodesFromAntennaPair(Point a, Point b)
        {
            Point spacing = b - a;
            Point antinodeA = a - spacing;
            Point antinodeB = b + spacing;
            if (PointIsInGridBounds(antinodeA) && !antinodes.Contains(antinodeA)) antinodes.Add(antinodeA);
            if (PointIsInGridBounds(antinodeB) && !antinodes.Contains(antinodeB)) antinodes.Add(antinodeB);
        }

        static bool PointIsInGridBounds(Point point)
        {
            return (0 <= point.x && point.x < grid.width
                && 0 <= point.y && point.y < grid.height);
        }

        static void RetrieveAntennas(Grid grid)
        {
            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    char type = grid[x, y].type;
                    if (type != '.')
                    {
                        AddNewAntenna(x, y, type);
                    }
                }
            }
        }

        static void AddNewAntenna(int x, int y, char frequency)
        {
            Point point = new Point(x, y);
            int index = antennaCollections.FindIndex(a => a.frequency == frequency);
            if (index == -1)
            {
                antennaCollections.Add(new AntennaCollection(new List<Point>() { point }, frequency));
            } else
            {
                antennaCollections[index].Add(point);
            }
        }
    }
}