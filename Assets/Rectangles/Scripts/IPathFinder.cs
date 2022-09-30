using System.Collections.Generic;
using UnityEngine;

namespace Rectangles.Scripts
{
    public interface IPathFinder
    {
        IEnumerable<Vector2> GetPath(Vector2 source, Vector2 target, IEnumerable<Edge> edges);
    }
}