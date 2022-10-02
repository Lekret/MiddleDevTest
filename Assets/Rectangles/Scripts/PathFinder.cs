using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 source, Vector2 target, IEnumerable<Edge> edges)
        {
            var edgesList = edges.ToList();
            if (edgesList.Count == 0)
                return Array.Empty<Vector2>();
            
            if (!edgesList[0].First.Contains(source))
                return Array.Empty<Vector2>();

            if (!edgesList[edgesList.Count - 1].Second.Contains(target))
                return Array.Empty<Vector2>();

            var path = new List<Vector2>();
            path.Add(source);
            CollectEdgeMiddlePoints(path, edgesList);
            path.Add(target);
            RemoveUnnecessaryPoints(path, edgesList);
            return path;
        }

        private static void CollectEdgeMiddlePoints(ICollection<Vector2> path, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                var edgeMid = (edge.Start + edge.End) / 2f;
                path.Add(edgeMid);
            }
        }

        private static void RemoveUnnecessaryPoints(List<Vector2> path, List<Edge> edges)
        {
            var edgeIdx = 0;
            var pathIdx = 0;
            while (pathIdx < path.Count - 2)
            {
                var edge = edges[pathIdx];
                if (LineUtils.LinesIntersect(path[pathIdx], path[pathIdx + 2], edge.Start, edge.End))
                {
                    path.RemoveAt(pathIdx + 1);
                    edges.RemoveAt(edgeIdx);
                }
                else
                {
                    pathIdx++;
                    edgeIdx++;
                }
            }
        }
    }
}