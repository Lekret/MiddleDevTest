using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 a, Vector2 c, IEnumerable<Edge> edges)
        {
            return new List<Vector2>();
        }
    }
}