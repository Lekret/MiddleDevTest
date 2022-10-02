﻿using System;
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
            foreach (var edge in edgesList)
            {
                var edgeMid = (edge.Start + edge.End) / 2f;
                path.Add(edgeMid);
            }

            path.Add(target);
            RemoveUnnecessaryPoints(path, edgesList);
            return path;
        }
        
        private static void RemoveUnnecessaryPoints(List<Vector2> path, List<Edge> edgesList)
        {
            var edgeIdx = 0;
            var pathIdx = 0;
            while (pathIdx < path.Count - 2)
            {
                var edge = edgesList[pathIdx];
                if (LineUtils.LinesIntersect(path[pathIdx], path[pathIdx + 2], edge.Start, edge.End))
                {
                    path.RemoveAt(pathIdx + 1);
                    edgesList.RemoveAt(edgeIdx);
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