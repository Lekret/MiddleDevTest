using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public interface IPathFinder
    {
        IEnumerable<Vector2> GetPath(Vector2 a, Vector2 c, IEnumerable<Edge> edges);
    }
}