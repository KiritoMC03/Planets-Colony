using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    [RequireComponent(typeof(SpaceshipCargoKeeper))]
    public class SpaceshipCargoUnloader : MonoBehaviour, ISpaceshipCargoUnloader
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

        public List<ICargo> Extract()
        {
            return _spaceshipCargoKeeper.ExtractCargos();
        }
    }
}
