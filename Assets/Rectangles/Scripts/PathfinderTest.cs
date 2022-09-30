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

        [ContextMenu("CalcPath")]
        private void CalcPath()
        {
            var pathFinder = new PathFinder();
            var path = pathFinder.GetPath(_from, _to, _edges);
            var positions = path.Select(x => (Vector3) x).ToArray();
            _lineRenderer.positionCount = positions.Length;
            _lineRenderer.SetPositions(positions);
        }

        private void OnDrawGizmos()
        {
            foreach (var edge in _edges)
            {
                DrawRectangle(edge.First);
                DrawRectangle(edge.Second);
            }
        }

        private void OnValidate()
        {
            for (var i = 0; i < _edges.Length; i++)
            {
                if (i < _edges.Length - 1)
                {
                    _edges[i + 1].First = _edges[i].Second;
                    EditorUtility.SetDirty(this);
                }
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