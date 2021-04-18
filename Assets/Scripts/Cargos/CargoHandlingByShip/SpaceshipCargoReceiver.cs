using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    [RequireComponent(typeof(SpaceshipCargoKeeper))]
    public class SpaceshipCargoReceiver : MonoBehaviour, ISpaceshipCargoReceiver
    {
        private SpaceshipCargoKeeper _spaceshipCargoKeeper = null;

        private void Awake()
        {
            _spaceshipCargoKeeper = GetComponent<SpaceshipCargoKeeper>();
            if (_spaceshipCargoKeeper == null)
            {
                throw new NullReferenceException("SpaceshipCargoKeeper component not found.");
            }
        }

        public void Receive(Cargo cargo)
        {
            _spaceshipCargoKeeper.AddCargo(cargo);
        }
    }
}