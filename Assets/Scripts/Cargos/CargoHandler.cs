using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(ICargoTransporter))]
    public class CargoHandler : MonoBehaviour, IAcceptCargo
    {
        private ICargo _cargo = null;
        private ICargoTransporter _cargoTransporter = null;

        private void Awake()
        {
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

        public void DeliverCargo(ICargoReceiver cargoReceiver)
        {
            cargoReceiver.AcceptCargo(_cargo);
            _cargo = null;
        }
    }
}