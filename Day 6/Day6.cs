using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Day6
    {
        static public List<string> input;
        static public GridObject[,] grid;

        static void Main(string[] args)
        {
            input = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "../../input.txt")).ToList();
            grid = CreateGrid(input);

            int part1Answer = Part1.GetAnswer(grid);
            Console.WriteLine($"Part 1 Answer: {part1Answer}");

            int part2Answer = Part2.GetAnswer(grid);
            Console.WriteLine($"Part 2 Answer: {part2Answer}");
        }

        static GridObject[,] CreateGrid(List<string> gridString)
        {
            int gridWidth = gridString[0].ToCharArray().Length;
            int gridHeight = gridString.Count;
            GridObject[,] grid = new GridObject[gridWidth,gridHeight];
            for (int y = 0; y < gridString.Count; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[x,y] = new GridObject(new Point(x, y), gridString[y][x]);
                }
            }
            return grid;
        }
    }
    
    struct GridObject
    {
        public Point position;
        public Point pos { get { return this.position; } set { this.position = value; } }
        public char type;

        public GridObject(Point _pos, char type)
        {
            this.position = _pos;
            this.type = type;
        }
    }

    struct DirectedPoint : IPoint
    {
        public int x { get; set; }
        public int y { get; set; }
        public int rotation { get; set; }

        public DirectedPoint(int x, int y, int rot)
        {
            this.x = x;
            this.y = y;
            this.rotation = rot;
        }

        public override string ToString()
        {
            return $"{x}, {y} ({rotation} degrees)";
        }

        public static DirectedPoint operator +(DirectedPoint a, IPoint b)
        {
            return new DirectedPoint(a.x + b.x, a.y + b.y, a.rotation);
        }

        public static DirectedPoint operator -(DirectedPoint a, IPoint b)
        {
            return new DirectedPoint(a.x - b.x, a.y - b.y, a.rotation);
        }

        public static explicit operator Point(DirectedPoint a) => new Point(a.x, a.y);
    }

    struct Point : IPoint
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public override string ToString()
        {
            return $"{x}, {y}";
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static implicit operator DirectedPoint(Point a) => new DirectedPoint(a.x, a.y, 0);
    }

    interface IPoint
    {
        int x { get; set; }
        int y { get; set; }
    }
}
