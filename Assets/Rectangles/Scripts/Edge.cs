using System;
using UnityEngine;

namespace Rectangles.Scripts
{
    [Serializable]
    public struct Edge
    {
        public Rectangle First;
        public Rectangle Second;
        public Vector3 Start;
        public Vector3 End;
    }
}