using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Factories;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace Assets.Scripts.WorkWithSpaceships
{
    [RequireComponent(typeof(ISpaceshipsStoragePort), typeof(ICargoLoader), typeof(Factory))]
    public class SpaceshipsSender : MonoBehaviour
    {
        [SerializeField] private float _sendShipWithCargoDelay = 3f;
        private ICargoLoader _cargoLoaderForShips = null;
        private ISpaceshipsStoragePort _spaceshipsStoragePort = null;
        private Queue<SpaceshipCargoHandler> _tempSpaceships = null;
        private Transform _transform = null;
        private Coroutine _sendShipWithCargoRoutine = null;
        private Factory _factory = null;

        private void Awake()
        {
            _transform = transform;
            _spaceshipsStoragePort = GetComponent<ISpaceshipsStoragePort>();
            _cargoLoaderForShips = GetComponent<ICargoLoader>();
            _factory = GetComponent<Factory>();

            if (_spaceshipsStoragePort == null)
            {
                throw new NullReferenceException("No component that implements the ISpaceshipsStoragePort interface was found.");
            }
            if (_cargoLoaderForShips == null)
            {
                throw new NullReferenceException("No component that implements the ICargoLoader interface was found.");
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

        public void SendShipWithCargo(Queue<SpaceshipCargoHandler> spaceships)
        {
            if (spaceships.Count < 1)
            {
                return;
            }

            var spaceshipCargoHandler = spaceships.Dequeue();
            _cargoLoaderForShips.LoadCargoForShip(ref spaceshipCargoHandler, ref _factory);
            spaceshipCargoHandler.AcceptFinish();
            spaceshipCargoHandler.GetLinkToSpaceship().SetUnityPosition(_transform.position);
        }

        private void StartShipSendRoutine()
        {
            _sendShipWithCargoRoutine = StartCoroutine(SendShipWithCargoRoutine(_spaceshipsStoragePort.GetAcceptedShips()));
        }

        private IEnumerator SendShipWithCargoRoutine(Queue<SpaceshipCargoHandler> spaceships)
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