using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OrbitRenderer))]
public class OrbitQuality : MonoBehaviour
{
    [SerializeField] private Camera _spaceCamera;
    [SerializeField] private float _baseLineWidth = 0.15f;
    [SerializeField] private float _normalRenderDistance = 200f;
    [SerializeField] private float _lineScale = 2f;
    [SerializeField] private bool _renderEveryFrame;

    private OrbitRenderer _orbitRenderer;
    private LineRenderer _lineRenderer;
    private Coroutine _renderEveryFrameRoutine;

    private CameraMovement _spaceCameraMovement;
    private CameraRange _spaceCameraRange;

    private void Awake()
    {
        _orbitRenderer = GetComponent<OrbitRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _spaceCameraMovement = _spaceCamera.GetComponent<CameraMovement>();
        _spaceCameraRange = _spaceCamera.GetComponent<CameraRange>();
    }

    private void Start()
    {
        ChangeWidth();
        if (_renderEveryFrame)
        {
            _renderEveryFrameRoutine = StartCoroutine(_orbitRenderer.RenderLine(_renderEveryFrame));
        }
    }

    private void OnEnable()
    {
        ChangeWidth();
        _renderEveryFrameRoutine = StartCoroutine(_orbitRenderer.RenderLine(_renderEveryFrame));
    }

    private void OnDisable()
    {
        StopCoroutine(_renderEveryFrameRoutine);
    }

    public void ChangeWidth()
    {
        _lineRenderer.widthMultiplier = _spaceCameraRange.GetDistanceToSun() * _baseLineWidth * _lineScale / _normalRenderDistance;
    }
}
