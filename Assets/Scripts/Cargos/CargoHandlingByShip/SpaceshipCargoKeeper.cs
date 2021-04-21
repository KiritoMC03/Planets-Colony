using UnityEngine;
using System.Collections.Generic;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public class SpaceshipCargoKeeper : MonoBehaviour, ISpaceshipCargoKeeper
    {
        private List<ICargo> _cargos = new List<ICargo>();

        private void Awake()
        {
            _cargos = new List<ICargo>();
        }

        public void AddCargo(ICargo cargo)
        {
            _cargos.Add(cargo);
        }

        public List<ICargo> ExtractCargos()
        {
            var tempCargo = _cargos;
            _cargos.Clear();
            return tempCargo;
        }
    }
}