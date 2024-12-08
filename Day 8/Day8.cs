using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Day8
    {
        static public List<string> input;
        static public Grid grid;

        static void Main(string[] args)
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();
            grid = new Grid(input);

            //int part1Answer = Part1.GetAnswer(grid);
            //Console.WriteLine($"Part 1 Answer: {part1Answer}");

            int part2Answer = Part2.GetAnswer(grid);
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }
    }

    class Grid
    {
        public int width;
        public int height;
        GridObject[,] grid;

        public Grid(List<string> gridString)
        {
            this.width = gridString[0].ToCharArray().Length;
            this.height = gridString.Count;
            GridObject[,] grid = new GridObject[this.width, this.height];
            for (int y = 0; y < gridString.Count; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    grid[x, y] = new GridObject(new Point(x, y), gridString[y][x]);
                }
            }
            this.grid = grid;
        }
        public Grid(int width, int height, GridObject[,] grid)
        {
            this.width = width;
            this.height = height;
            this.grid = grid;
        }

        public override string ToString()
        {
            string output = "";
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    output += grid[x, y].type;
                }
                if (x != width - 1) output += "\n";
            }
            return output;
        }

        public Grid Clone() { return new Grid(width, height, (GridObject[,])grid.Clone()); }
        public GridObject this[int x, int y] { get { return grid[x, y]; } set { grid[x, y] = value; } }
    }

    struct GridObject
    {
        public Point position;
        public char type;

        public GridObject(Point _pos, char type)
        {
            this.position = _pos;
            this.type = type;
        }
    }
    
    class AntennaCollection : IEnumerable<Point>
    {
        List<Point> antennas;
        public char frequency;
        
        public AntennaCollection(List<Point> antennas, char frequency)
        {
            this.antennas = antennas;
            this.frequency = frequency;
        }

        public override string ToString() { return this.frequency + " : " + String.Join(", ", antennas); }
        public void Add(Point antenna) { this.antennas.Add(antenna); }

        public Point this[int i] { get { return antennas[i]; } set { antennas[i] = value; } }
        public int size { get { return antennas.Count; } }
        public IEnumerator<Point> GetEnumerator() { return antennas.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public override string ToString() { return $"({x}, {y})"; }

        public static Point operator *(Point a, int scalar) { return new Point(a.x * scalar, a.y * scalar); }
        public static Point operator +(Point a, Point b) { return new Point(a.x + b.x, a.y + b.y); }
        public static Point operator -(Point a, Point b) { return new Point(a.x - b.x, a.y - b.y); }
    }
}
