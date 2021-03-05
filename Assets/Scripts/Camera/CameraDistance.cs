using UnityEngine;

namespace PlanetsColony
{
    public class CameraDistance : MonoBehaviour
    {
        [SerializeField] private Transform _referencePoint;

        private Transform _transform;
        private float distanceToSun;

        private void Awake()
        {
            _transform = transform;
            _referencePoint = _referencePoint.transform;
        }

        public float GetDistanceToSun()
        {
            distanceToSun = Mathf.Abs(_referencePoint.position.z - _transform.position.z);
            return distanceToSun;
        }
    }
}