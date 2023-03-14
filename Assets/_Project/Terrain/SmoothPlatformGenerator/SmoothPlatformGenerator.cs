using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedTypeGame
{
    public class SmoothPlatformGenerator : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private PolygonCollider2D polygonCollider;

        private List<Vector3> points;
        private float bottomColliderLimit = -10;






        public List<Vector3> publicPoints;

        private void Start()
        {
            points = publicPoints;
        }


        [ContextMenu("Update Points")]
        public void UpdatePoint()
        {
            lineRenderer.positionCount = publicPoints.Count;
            lineRenderer.SetPositions(points.ToArray());

            List<Vector2> colliderPoints = new List<Vector2>();
            foreach (var point in points)
            {
                colliderPoints.Add(point);
            }
            Vector2 endPoint = points[points.Count - 1];
            endPoint.y = bottomColliderLimit;
            Vector2 startPoint = points[0];
            startPoint.y = bottomColliderLimit;

            colliderPoints.Add(endPoint);
            colliderPoints.Add(startPoint);

            polygonCollider.points = colliderPoints.ToArray();
        }


    }
}
