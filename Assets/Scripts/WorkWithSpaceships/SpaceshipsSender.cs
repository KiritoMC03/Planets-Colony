using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Factories;

namespace Assets.Scripts.WorkWithSpaceships
{
    [RequireComponent(typeof(SpaceshipsStoragePort), typeof(Factory))]
    public class SpaceshipsSender : MonoBehaviour
    {
        [SerializeField] private float _sendShipWithCargoDelay = 3f;
        private CargoLoaderForShips _cargoLoaderForShips = null;
        private SpaceshipsStoragePort _spaceshipsStoragePort = null;
        private Queue<CargoHandler> _tempSpaceships = null;
        private Transform _transform = null;
        private Coroutine _sendShipWithCargoRoutine = null;
        private Factory _factory = null;

        private void Awake()
        {
            _transform = transform;
            _spaceshipsStoragePort = GetComponent<SpaceshipsStoragePort>();
            _cargoLoaderForShips = GetComponent<CargoLoaderForShips>();
            _factory = GetComponent<Factory>();

            if (_spaceshipsStoragePort == null)
            {
                throw new NullReferenceException("SpaceshipsStoragePort component not found.");
            }
            if (_cargoLoaderForShips == null)
            {
                throw new NullReferenceException("CargoLoaderForShips component not found.");
            }
            if (_factory == null)
            {
                throw new NullReferenceException("Factory component not found.");
            }
            else
            {
                if (_factory.GetIsActive())
                {
                    StartShipSendRoutine();
                }
                else
                {
                    _factory.OnActivate.AddListener(StartShipSendRoutine);
                }
            }
        }

        public void SendShipWithCargo(Queue<CargoHandler> spaceships)
        {
            if (spaceships.Count < 1)
            {
                return;
            }

            var ship = spaceships.Dequeue();
            _cargoLoaderForShips.LoadCargoForShip(ref ship, ref _factory);
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }

        private void StartShipSendRoutine()
        {
            _sendShipWithCargoRoutine = StartCoroutine(SendShipWithCargoRoutine(_spaceshipsStoragePort.GetAcceptedShips()));
        }

        private IEnumerator SendShipWithCargoRoutine(Queue<CargoHandler> spaceships)
        {
            _tempSpaceships = spaceships;
            while (true)
            {
                yield return new WaitForSeconds(_sendShipWithCargoDelay);
                SendShipWithCargo(_tempSpaceships);
            }
        }

        private void OnDisable()
        {
            if (_sendShipWithCargoRoutine != null)
            {
                StopCoroutine(_sendShipWithCargoRoutine);
            }
        }
    }
}