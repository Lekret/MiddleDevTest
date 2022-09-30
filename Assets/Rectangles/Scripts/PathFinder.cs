using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 from, Vector2 to, IEnumerable<Edge> edges)
        {
            var result = new List<Vector2>();
            result.Add(from);
            foreach (var edge in edges)
            {
                var edgeMid = (edge.Start + edge.End) / 2f;
                result.Add(edgeMid);
            }
            result.Add(to);
            return result;
        }
    }
}