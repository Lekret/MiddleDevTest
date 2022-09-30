using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public interface IPathFinder
    {
        IEnumerable<Vector2> GetPath(Vector2 from, Vector2 to, IEnumerable<Edge> edges);
    }
}