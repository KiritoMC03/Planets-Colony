using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(Spaceship), typeof(CargoTransporter))]
    public class CargoHandler : MonoBehaviour
    {
        private Transform _transform = null;
        private Cargo _cargo = null;
        private Spaceship _cargoTransporter = null;

        private void Awake()
        {
            _transform = transform;
            _cargoTransporter = GetComponent<Spaceship>();

            if(_cargoTransporter == null)
            {
                throw new ArgumentNullException("Компонент Cargo Transporter не добавлен.");
            }
        }

        public bool CheckCargo()
        {
            return (_cargo != null) ? true : false;
        }

        public void AcceptCargo(Cargo cargo)
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

        public Cargo DeliverCargo(CargoReceiver cargoReceiver)
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