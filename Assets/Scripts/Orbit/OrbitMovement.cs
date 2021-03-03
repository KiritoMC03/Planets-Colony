using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    [SerializeField] private Transform orbitingObject;
    [SerializeField] internal Orbit orbitPath = new Orbit(10, 10);
    [Range(0f,1f)]
    [SerializeField] internal float orbitProgress = 0f;
    [SerializeField] internal float orbitPeriod = 3f;
    [SerializeField] internal bool orbitActive = true;
    [SerializeField] internal bool toOptimize = false;

    private Transform _transform = null;
    private Vector2 _tempOrbitPosition2D;
    private Vector3 _tempOrbitPosition3D;
    private Vector3 _startPosition = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
        _startPosition = _transform.position;
        if (orbitingObject == null)
        {
            orbitActive = false;
        }
    }

    void Start()
    {
        if (orbitActive)
        {
            SetOrbitingObjectPosition();
            StartCoroutine(AnimateOrbit());
        }
    }

    void SetOrbitingObjectPosition()
    {
        _tempOrbitPosition2D = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = _tempOrbitPosition2D + (Vector2)_startPosition;
    }

    IEnumerator AnimateOrbit()
    {
        if(orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }

        float orbitSpeed = 1f / orbitPeriod;

        while (orbitActive)
        {
            /*if (GameState.onPause != true)
            {*/
                orbitProgress += Time.deltaTime * orbitSpeed;
                orbitProgress %= 1f;
                SetOrbitingObjectPosition();
            //}
            
            yield return null;
        }
    }
}