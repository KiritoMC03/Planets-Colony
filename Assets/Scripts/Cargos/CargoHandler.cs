using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;


namespace PlanetsColony
{
    [RequireComponent(typeof(Spaceship), typeof(CargoTransporter))]
    public class CargoHandler : MonoBehaviour
    {
        private Transform _transform = null;
        private List<Cargo> _cargos = new List<Cargo>();
        private Spaceship _cargoTransporter = null;

        private void Awake()
        {
            _transform = transform;
            _cargoTransporter = GetComponent<Spaceship>();
            _cargos = new List<Cargo>();

            if (_cargoTransporter == null)
            {
                throw new ArgumentNullException("Компонент Cargo Transporter не добавлен.");
            }
        }

        public bool CheckCargo()
        {
            return (_cargos != null && _cargos.Count > 0) ? true : false;
        }

        public void AcceptCargo(Cargo cargo)
        {
            this._cargos.Add(cargo);
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

        public List<Cargo> DeliverCargo(CargoReceiver cargoReceiver)
        {
            var tempCargo = _cargos;
            cargoReceiver.AcceptCargo(_cargos);
            _cargos.Clear();
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