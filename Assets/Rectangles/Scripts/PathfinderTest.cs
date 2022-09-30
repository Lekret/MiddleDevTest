using System.Linq;
using UnityEngine;

namespace Rectangles.Scripts
{
    public class PathfinderTest : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Vector2 _from;
        [SerializeField] private Vector2 _to;
        [SerializeField] private Edge[] _edges;
        
        private void Start()
        {
            CalcPath();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                CalcPath();
        }

        private void CalcPath()
        {
            var pathFinder = new PathFinder();
            var path = pathFinder.GetPath(_from, _to, _edges);
            var linePosition = path.Select(x => (Vector3) x).ToArray();
            _lineRenderer.SetPositions(linePosition);
        }
    }
}