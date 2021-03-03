using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(OrbitMovement))]
public class OrbitRenderer : MonoBehaviour
{
    [Range(4, 100)]
    [SerializeField] internal int segments = 100;

    private Orbit _orbit = new Orbit(10f, 10f);
    private LineRenderer _lineRenderer;
    private OrbitMovement _orbitMovement;

    private Vector2 _position2D;
    private Vector3 _position3D;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _orbitMovement = GetComponent<OrbitMovement>();
    }

    private void Start()
    {
        _orbit = _orbitMovement.orbitPath;

        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i < segments; i++)
        {
            _position2D = _orbit.Evaluate(i / (float)segments);
            _position3D.Set(_position2D.x, _position2D.y, 0f);
            points[i] = _position3D + transform.position;
        }

        points[segments] = points[0];

        _lineRenderer.positionCount = segments + 1;
        _lineRenderer.SetPositions(points);
    }

    internal IEnumerator RenderLine(bool condition)
    {
        while(true)
        {
            if (condition)
            {
                CalculateEllipse();
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
