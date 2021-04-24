using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;
using PlanetsColony.Spaceships;
using PlanetsColony.Pirates;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    [RequireComponent(typeof(ICargoTransporter))]
    [RequireComponent(typeof(SpaceshipCargoKeeper), typeof(SpaceshipCargoReceiver), typeof(SpaceshipCargoUnloader))]
    public class SpaceshipCargoHandler : MonoBehaviour, ISpaceshipCargoHandler
    {
        private List<ICargo> _cargos = new List<ICargo>();
        private ICargoTransporter _cargoTransporter = null;

        private void Awake()
        {
            _cargoTransporter = GetComponent<ICargoTransporter>();
            _cargos = new List<ICargo>();

            if (_cargoTransporter == null)
            {
                throw new ArgumentNullException("Компонент Cargo Transporter не добавлен.");
            }
        }

        public bool CheckCargo()
        {
            return (_cargos != null && _cargos.Count > 0);
        }

        public void AcceptCargo(ICargo cargo)
        {
            this._cargos.Add(cargo);
        }

        public void AcceptNow()
        {
            _cargoTransporter.Flying.SetCanMove(false);
            gameObject.SetActive(false);
        }

        public void AcceptFinish()
        {
            _cargoTransporter.DeparturePlaceKeeper.SetDepartureObjectAsTarget();
            gameObject.SetActive(true);
            _cargoTransporter.Flying.SetCanMove(true);
        }

        public List<ICargo> DeliverCargo(ICargoReceiver cargoReceiver)
        {
            var tempCargo = _cargos;
            cargoReceiver.Receive(_cargos);
            _cargos.Clear();
            return tempCargo;
        }

        public List<ICargo> DeliverCargo(IPirate pirate)
        {
            var tempCargo = _cargos;
            pirate.StealCargos(_cargos);
            _cargos.Clear();
            return tempCargo;
        }

        public ICargoTransporter GetLinkToSpaceship()
        {
            return _cargoTransporter;
        }

        public GameObject GetUnityObject()
        {
            return gameObject;
        }
    }
}