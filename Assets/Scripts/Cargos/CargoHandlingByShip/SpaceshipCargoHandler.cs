using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;
using PlanetsColony.Spaceships;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    [RequireComponent(typeof(CargoTransporter))]
    [RequireComponent(typeof(SpaceshipCargoKeeper), typeof(SpaceshipCargoReceiver), typeof(SpaceshipCargoUnloader))]
    public class SpaceshipCargoHandler : MonoBehaviour
    {
        private List<Cargo> _cargos = new List<Cargo>();
        private CargoTransporter _cargoTransporter = null;

        private void Awake()
        {
            _cargoTransporter = GetComponent<CargoTransporter>();
            _cargos = new List<Cargo>();

            if (_cargoTransporter == null)
            {
                throw new ArgumentNullException("Компонент Cargo Transporter не добавлен.");
            }
        }

        public bool CheckCargo()
        {
            return (_cargos != null && _cargos.Count > 0);
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

        public List<Cargo> DeliverCargo(Cargos.CargoReceiver cargoReceiver)
        {
            var tempCargo = _cargos;
            cargoReceiver.AcceptCargo(_cargos);
            _cargos.Clear();
            return tempCargo;
        }
        
        public CargoTransporter GetLinkToSpaceship()
        {
            return _cargoTransporter;
        }
    }
}