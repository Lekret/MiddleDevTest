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
            if (!edges.FirstOrDefault().First.Contains(source))
                return Array.Empty<Vector2>();

            if (!edges.LastOrDefault().Second.Contains(target))
                return Array.Empty<Vector2>();
            
            var result = new List<Vector2>();
            result.Add(source);
            foreach (var edge in edges)
            {
                var edgeMid = (edge.Start + edge.End) / 2f;
                result.Add(edgeMid);
            }
            
            result.Add(target);
            return result;
        }
    }
}