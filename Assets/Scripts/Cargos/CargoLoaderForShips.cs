using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;
using System;

namespace PlanetsColony
{
    [RequireComponent(typeof(Factory))]
    public class CargoLoaderForShips : MonoBehaviour
    {
        [SerializeField] private Resource.Type[] _resourceTypes;
        [SerializeField] private float _sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private Factory _factory = null;
        private Queue<CargoHandler> aceptedSpaceShips = null;
        private Coroutine _sendShipWithCargoRoutine = null;

        private void Awake()
        {
            _transform = transform;
            _factory = GetComponent<Factory>();
            aceptedSpaceShips = new Queue<CargoHandler>();

            if(_factory == null)
            {
                throw new Exception();
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

#region SendShipWork
        private void StartShipSendRoutine()
        {
            _sendShipWithCargoRoutine = StartCoroutine(SendShipWithCargoRoutine());
        }

        private IEnumerator SendShipWithCargoRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_sendShipWithCargoDelay);
                SendShipWithCargo();
            }
        }

        public void SendShipWithCargo()
        {
            if (aceptedSpaceShips.Count < 1)
            {
                return;
            }
            var ship = aceptedSpaceShips.Dequeue();
            for (int i = 0; i < _resourceTypes.Length; i++)
            {
                _factory.SendCargo(ship, _resourceTypes[i]);
            }
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }
#endregion

#region AcceptShipWork
        public void AcceptShip(CargoHandler ship)
        {
            aceptedSpaceShips.Enqueue(ship);
            ship.AcceptNow();
        }
#endregion

#region GettersSetters
        public Resource.Type[] GetResourceTypes()
        {
            return _resourceTypes;
        }

        public float GetSendShipWithCargoDelay()
        {
            return _sendShipWithCargoDelay;
        }
#endregion

        private void OnDisable()
        {
            if(_sendShipWithCargoRoutine != null)
            {
                StopCoroutine(_sendShipWithCargoRoutine);
            }
        }
    }
}