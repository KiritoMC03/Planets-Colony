using UnityEngine;
using System.Collections.Generic;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public class SpaceshipCargoKeeper : MonoBehaviour, ISpaceshipCargoKeeper
    {
        private List<Cargo> _cargos = new List<Cargo>();

        private void Awake()
        {
            _cargos = new List<Cargo>();
        }

        public void AddCargo(Cargo cargo)
        {
            _cargos.Add(cargo);
        }

        public List<Cargo> ExtractCargos()
        {
            var tempCargo = _cargos;
            _cargos.Clear();
            return tempCargo;
        }
    }
}