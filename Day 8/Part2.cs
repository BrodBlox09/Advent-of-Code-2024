using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Part2
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
            //Grid dispGrid = grid.Clone();
            //antinodes.ForEach(antinode =>
            //{
            //    dispGrid[antinode.x, antinode.y] = new GridObject(antinode, '#');
            //});
            //Console.WriteLine(dispGrid);
            return antinodes.Count;
        }

        static void AddAntinodesFromAntennaPair(Point a, Point b)
        {
            Point spacing = b - a;
            bool isAntinode1Active = true;
            bool isAntinode2Active = true;
            for (int i = 0;; i++)
            {
                if (isAntinode1Active)
                {
                    Point antinode1 = a + (spacing * i);
                    if (PointIsInGridBounds(antinode1))
                    {
                        if (!antinodes.Contains(antinode1)) antinodes.Add(antinode1);
                    } else
                    {
                        isAntinode1Active = false;
                    }
                }
                if (isAntinode2Active)
                {
                    Point antinode2 = a - (spacing * i);
                    if (PointIsInGridBounds(antinode2))
                    {
                        if (!antinodes.Contains(antinode2)) antinodes.Add(antinode2);
                    }
                    else
                    {
                        isAntinode2Active = false;
                    }
                }
                if (!isAntinode1Active && !isAntinode2Active) break;
            }
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
            }
            else
            {
                antennaCollections[index].Add(point);
            }
        }
    }
}