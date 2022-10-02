using UnityEngine;

namespace Rectangles.Scripts
{
    public static class LineUtils
    {
        public static bool LinesIntersect(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4) 
        {
            var o1 = Orientation(p1, p2, p3);
            var o2 = Orientation(p1, p2, p4);
            var o3 = Orientation(p3, p4, p1);
            var o4 = Orientation(p3, p4, p2);
            
            if (o1 != o2 && o3 != o4) 
                return true;

            if (o1 == 0 && PointOnLine(p1, p2, p3)) return true;
            if (o2 == 0 && PointOnLine(p1, p2, p4)) return true;
            if (o3 == 0 && PointOnLine(p3, p4, p1)) return true;
            if (o4 == 0 && PointOnLine(p3, p4, p2)) return true;

            return false;
        }
        
        private static int Orientation(Vector2 a, Vector2 b, Vector2 c) 
        {
            var value = (b.y - a.y) * (c.x - b.x) - (b.x - a.x) * (c.y - b.y);
            if (Mathf.Abs(value) < Vector2.kEpsilon) 
                return 0;
            return value > 0 ? -1 : +1;
        }

        private static bool PointOnLine(Vector2 a, Vector2 b, Vector2 c) 
        {
            return Orientation(a, b, c) == 0 && 
                   Mathf.Min(a.x, b.x) <= c.x && c.x <= Mathf.Max(a.x, b.x) && 
                   Mathf.Min(a.y, b.y) <= c.y && c.y <= Mathf.Max(a.y, b.y);
        }
    }
}