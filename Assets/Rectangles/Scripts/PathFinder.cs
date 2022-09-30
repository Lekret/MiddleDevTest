using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 source, Vector2 target, IEnumerable<Edge> edges)
        {
            var result = new List<Vector2> {source};
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