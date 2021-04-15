using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.WorkWithSpaceships;
using System;

namespace PlanetsColony.Cargos
{
    [RequireComponent(typeof(SpaceshipsStoragePort))]
    public class SpaceshipsReceiver : MonoBehaviour
    {
        private SpaceshipsStoragePort _spaceshipsStoragePort = null;

        private void Awake()
        {
            _spaceshipsStoragePort = GetComponent<SpaceshipsStoragePort>();

            if (_spaceshipsStoragePort == null)
            {
                throw new NullReferenceException("SpaceshipsStoragePort component not found.");
            }
        }

        public void AcceptShip(CargoHandler ship)
        {
            ship.AcceptNow();
            _spaceshipsStoragePort.AddShip(ship);
        }
    }
}