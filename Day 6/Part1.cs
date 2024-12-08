using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Part1
    {
        static Point guardPos;
        static int guardRotation = 0;
        static List<Point> pointsVisited = new List<Point>();

        static int gridWidth;
        static int gridHeight;

        static public int GetAnswer(GridObject[,] grid)
        {
            gridWidth = grid.GetLength(0);
            gridHeight = grid.GetLength(1);
            foreach (GridObject gridObject in grid)
            {
                if (gridObject.type == '^')
                {
                    guardPos = gridObject.position;
                    break;
                }
            }
            while (PointIsInGridBounds(guardPos))
            {
                AddNewPointVisited(guardPos);
                Point offset = OffsetFromRotation(guardRotation);
                guardPos += offset;
                Point facingObject = guardPos + offset;
                if (PointIsInGridBounds(facingObject) && grid[facingObject.x, facingObject.y].type == '#') guardRotation = (guardRotation + 90) % 360;
            }
            return pointsVisited.Count;
        }

        static bool PointIsInGridBounds(Point point)
        {
            return (0 <= point.x && point.x < gridWidth
                && 0 <= point.y && point.y < gridHeight);
        }

        static void AddNewPointVisited(Point point)
        {
            if (!pointsVisited.Contains(point)) pointsVisited.Add(point);
        }

        static Point OffsetFromRotation(int rot)
        {
            switch (rot)
            {
                case 0: return new Point(0, -1);
                case 90: return new Point(1, 0);
                case 180: return new Point(0, 1);
                case 270: return new Point(-1, 0);
            }
            return new Point(0, 0);
        }
    }
}