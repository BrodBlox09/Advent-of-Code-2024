using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Part2
    {
        static List<DirectedPoint> possibleObstructionPoints = new List<DirectedPoint>();
        static DirectedPoint guard;
        static List<DirectedPoint> pointsVisited = new List<DirectedPoint>();

        static int gridWidth;
        static int gridHeight;

        static public int GetAnswer(GridObject[,] baseGrid)
        {
            gridWidth = baseGrid.GetLength(0);
            gridHeight = baseGrid.GetLength(1);
            DirectedPoint baseGuard = new DirectedPoint(0, 0, 0);
            foreach (GridObject gridObject in baseGrid)
            {
                if (gridObject.type == '^')
                {
                    baseGuard = gridObject.position;
                    break;
                }
            }
            guard = baseGuard;
            MapVisitedPoints(baseGrid);
            possibleObstructionPoints = pointsVisited;
            int loopCreatingObjects = 0;
            possibleObstructionPoints.ForEach(obstructionPoint =>
            {
                int x = obstructionPoint.x;
                int y = obstructionPoint.y;
                if (baseGrid[x, y].type == '#' || baseGrid[x, y].type == '^') return;
                GridObject[,] newGrid = CloneGrid(baseGrid);
                guard = baseGuard;
                pointsVisited = new List<DirectedPoint>();
                newGrid[x, y].type = '#';
                if (GridMakesGuardLoop(newGrid)) loopCreatingObjects++;
            });
            return loopCreatingObjects;
        }

        static GridObject[,] CloneGrid(GridObject[,] grid)
        {
            return (GridObject[,])grid.Clone();
        }

        static bool GridMakesGuardLoop(GridObject[,] grid)
        {
            while(PointIsInGridBounds(guard))
            {
                bool visitedPreviously = AddNewPointVisited(guard);
                if (visitedPreviously) return true;
                RaycastHitInfo hitInfo = Raycast(guard, grid);
                guard = (DirectedPoint)hitInfo.endPoint;
                if (hitInfo.obstructionType == "object") guard.rotation = (guard.rotation + 90) % 360;
                else return false;
            }
            return false;
        }

        static RaycastHitInfo Raycast(DirectedPoint point, GridObject[,] grid)
        {
            DirectedPoint offset = OffsetFromRotation(point.rotation);
            DirectedPoint pointer = point;
            while (PointIsInGridBounds(pointer) && grid[pointer.x, pointer.y].type != '#')
            {
                pointer += offset;
            }
            Point obstructionLocation = (Point)pointer;
            pointer -= offset;
            if (PointIsInGridBounds(obstructionLocation)) return new RaycastHitInfo(pointer, "object");
            return new RaycastHitInfo(pointer, "endOfGrid");
        }

        struct RaycastHitInfo
        {
            public IPoint endPoint;
            public string obstructionType;

            public RaycastHitInfo(IPoint endPoint, string obstructionType)
            {
                this.endPoint = endPoint;
                this.obstructionType = obstructionType;
            }
        }

        static void MapVisitedPoints(GridObject[,] grid)
        {
            while (PointIsInGridBounds(guard))
            {
                if (!pointsVisited.Contains((Point)guard)) pointsVisited.Add((Point)guard);
                Point offset = OffsetFromRotation(guard.rotation);
                guard += offset;
                Point facingObject = (Point)(guard + offset);
                if (PointIsInGridBounds(facingObject) && grid[facingObject.x, facingObject.y].type == '#') guard.rotation = (guard.rotation + 90) % 360;
            }
        }

        static bool PointIsInGridBounds(IPoint point)
        {
            return (0 <= point.x && point.x < gridWidth
                && 0 <= point.y && point.y < gridHeight);
        }

        static bool AddNewPointVisited(DirectedPoint point)
        {
            if (!pointsVisited.Contains(point))
            {
                pointsVisited.Add(point);
                return false;
            }
            return true;
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