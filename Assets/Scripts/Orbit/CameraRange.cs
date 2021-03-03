using UnityEngine;

[RequireComponent(typeof(CameraMovement))]
public class CameraRange : MonoBehaviour
{
    internal float distanceToSun;

    [SerializeField] private Transform _sun;

    private Transform _transform;
    private CameraMovement _spaceCameraHandler;

    private void Awake()
    {
        _transform = transform;
        _sun = _sun.transform;
        _spaceCameraHandler = GetComponent<CameraMovement>();

        GetDistanceToSun();
    }

    internal float GetDistanceToSun()
    {
        distanceToSun = Mathf.Abs((_sun.position - _transform.position).z);

        return distanceToSun;
    }

}
