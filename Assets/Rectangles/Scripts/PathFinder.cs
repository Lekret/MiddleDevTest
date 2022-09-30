using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathFinder : IPathFinder
    {
        public IEnumerable<Vector2> GetPath(Vector2 from, Vector2 to, IEnumerable<Edge> edges)
        {
            return new List<Vector2>
            {
                Vector2.right,
                Vector2.down
            };
        }
    }
}