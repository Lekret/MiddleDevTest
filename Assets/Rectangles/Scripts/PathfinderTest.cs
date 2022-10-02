using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathfinderTest : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Vector2 _from;
        [SerializeField] private Vector2 _to;
        [SerializeField] private Edge[] _edges;

        private Vector3[] _positions = Array.Empty<Vector3>();

        [ContextMenu("CalcPath")]
        private void CalcPath()
        {
            var pathFinder = new PathFinder();
            var path = pathFinder.GetPath(_from, _to, _edges);
            var positions = path.Select(x => (Vector3) x).ToArray();
            _lineRenderer.positionCount = positions.Length;
            _lineRenderer.SetPositions(positions);
        }

        private void OnValidate()
        {
            for (var i = 0; i < _edges.Length - 1; i++)
            {
                ref var current = ref _edges[i];
                ref var next = ref _edges[i + 1];
                if (!next.First.Equals(current.Second))
                {
                    next.First = current.Second;
                    EditorUtility.SetDirty(this);
                }
            }

            CalcPath();
        }
        
        private void OnDrawGizmos()
        {
            DrawSourceWithTarget();
            DrawLineRendererPoints();
            DrawRectangles();
        }

        private void DrawSourceWithTarget()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(_from, 0.5f);
            Gizmos.DrawWireSphere(_to, 0.5f);
            Gizmos.color = Color.white;
        }
        
        private void DrawLineRendererPoints()
        {
            Gizmos.color = Color.yellow;
            if (_positions == null || _positions.Length < _lineRenderer.positionCount)
                _positions = new Vector3[_lineRenderer.positionCount];

            _lineRenderer.GetPositions(_positions);
            foreach (var p in _positions)
            {
                Gizmos.DrawWireSphere(p, 0.3f);
            }

            Gizmos.color = Color.white;
        }

        private void DrawRectangles()
        {
            foreach (var edge in _edges)
            {
                DrawRectangle(edge.First);
                DrawRectangle(edge.Second);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(edge.Start, edge.End);
                Gizmos.color = Color.white;
            }
        }
        
        private static void DrawRectangle(Rectangle rect)
        {
            var center = (rect.Min + rect.Max) / 2f;
            var size = rect.Max - rect.Min;
            Gizmos.DrawWireCube(center, new Vector3(size.x, size.y, 1));
        }
    }
}