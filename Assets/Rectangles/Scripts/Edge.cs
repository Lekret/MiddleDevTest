using System;
using UnityEngine;

namespace Rectangles.Scripts
{
    [Serializable]
    public struct Edge
    {
        public Rectangle First;
        public Rectangle Second;
        public Vector2 Start;
        public Vector2 End;
    }
}