using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class BackStart : MonoBehaviour
    {
        [SerializeField] private Camera _camera = null;
        [SerializeField] private Vector3 _startOffset = new Vector3(0, 0, 10);
        private Transform _transform = null;

        private void Awake()
        {
            _transform = transform;

            if(_camera == null)
            {
                throw new Exception("Необходимо заполнить поле Camera.");
            }
        }

        public void MoveForCamera(Camera camera)
        {
            _transform.position = camera.transform.position + _startOffset;
        }
    }
}