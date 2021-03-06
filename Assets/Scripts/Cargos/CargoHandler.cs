using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(ICargoTransporter))]
    public class CargoHandler : MonoBehaviour, ITransferringCargo
    {
        private Transform _transform = null;
        private ICargo _cargo = null;
        private ICargoTransporter _cargoTransporter = null;

        private void Awake()
        {
            _transform = transform;
            _cargoTransporter = GetComponent<ICargoTransporter>();
        }

        public bool CheckCargo()
        {
            return (_cargo != null) ? true : false;
        }

        public void AcceptCargo(ICargo cargo)
        {
            this._cargo = cargo;
        }

        public void AcceptNow()
        {
            _cargoTransporter.SetCanMove(false);
            gameObject.SetActive(false);
        }

        public void AcceptFinish()
        {
            _cargoTransporter.SetDepartureObjectAsTarget();
            gameObject.SetActive(true);
            _cargoTransporter.SetCanMove(true);
        }

        public ICargo DeliverCargo(ICargoReceiver cargoReceiver)
        {
            var tempCargo = _cargo;
            cargoReceiver.AcceptCargo(_cargo);
            _cargo = null;
            return tempCargo;
        }
        public Transform GetUnityTransform()
        {
            if(_transform != null)
            {
                return _transform;
            }
            return transform;
        }

        public void SetUnityPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}