using System;
using UnityEngine;

namespace Rectangles.Scripts
{
    [Serializable]
    public struct Rectangle
    {
        public Vector2 Min;
        public Vector2 Max;
    }

    public static class RectangleExtensions
    {
        public static bool IsValid(this Rectangle rectangle)
        {
            return rectangle.Max.x > rectangle.Min.x &&
                   rectangle.Max.y > rectangle.Min.y;
        }
        
        public static bool Contains(this Rectangle rectangle, Vector2 point)
        {
            if (!rectangle.IsValid())
                return false;
            return point.x >= rectangle.Min.x &&
                   point.y >= rectangle.Min.y &&
                   point.x <= rectangle.Max.x &&
                   point.y <= rectangle.Max.y;
        }
    }
}