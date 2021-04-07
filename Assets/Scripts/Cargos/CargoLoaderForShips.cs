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
        [Serializable]
        public struct ResourceRareInfo
        {
            [SerializeField] private Resource.Type Type;
            [Header("Precent (0-100)")]
            [SerializeField] private int _rare;

            public float GetRare()
            {
                return _rare / 100f;
            }

            public Resource.Type GetResourceType()
            {
                return Type;
            }
        }

        [SerializeField] private ResourceRareInfo[] _resourceRareInfo;
        [SerializeField] private float _sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private Factory _factory = null;
        private Queue<CargoHandler> aceptedSpaceShips = null;
        private Coroutine _sendShipWithCargoRoutine = null;
        private Resource.Type[] _tempResourceTypes = null;

        private void Awake()
        {
            _transform = transform;
            _factory = GetComponent<Factory>();
            aceptedSpaceShips = new Queue<CargoHandler>();

            for (int i = 0; i < _resourceRareInfo.Length; i++)
            {
                if (_resourceRareInfo[i].GetRare()*100 > 100 || _resourceRareInfo[i].GetRare()*100 < 0)
                {
                    Application.Quit();
                    throw new Exception("Rare value Incorrect.");
                }
            }

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
            for (int i = 0; i < _resourceRareInfo.Length; i++)
            {
                _factory.SendCargo(ship, _resourceRareInfo[i].GetResourceType());
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
            _tempResourceTypes = new Resource.Type[_resourceRareInfo.Length];
            for (int i = 0; i < _resourceRareInfo.Length; i++)
            {
                _tempResourceTypes[i] = _resourceRareInfo[i].GetResourceType();
            }

            return _tempResourceTypes;
        }

        public float GetSendShipWithCargoDelay()
        {
            return _sendShipWithCargoDelay;
        }

        public float GetResourceRare(Resource.Type type)
        {
            for (int i = 0; i < _resourceRareInfo.Length; i++)
            {
                if (_resourceRareInfo[i].GetResourceType() == type)
                {
                    return _resourceRareInfo[i].GetRare();
                }
            }
            return 0f;
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