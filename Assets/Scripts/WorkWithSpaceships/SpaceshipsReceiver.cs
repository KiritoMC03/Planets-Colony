using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.WorkWithSpaceships;
using System;

namespace PlanetsColony.Cargos
{
    [RequireComponent(typeof(ISpaceshipsStoragePort))]
    public class SpaceshipsReceiver : MonoBehaviour
    {
        private ISpaceshipsStoragePort _spaceshipsStoragePort = null;

        private void Awake()
        {
            _spaceshipsStoragePort = GetComponent<ISpaceshipsStoragePort>();

            if (_spaceshipsStoragePort == null)
            {
                throw new NullReferenceException("No component that implements the ISpaceshipsStoragePort interface was found.");
            }
        }

        public void AcceptShip(CargoHandler ship)
        {
            ship.AcceptNow();
            _spaceshipsStoragePort.AddShip(ship);
        }
    }
}