using PlanetsColony.Cargos;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    public class PirateCargoKeeper : MonoBehaviour, IPirateCargoKeeper
    {
        private List<ICargo> _cargos = null;

        public void Accept(ICargo cargo)
        {
            _cargos.Add(cargo);
        }

        public void TryAccept(ICargo cargo)
        {
            if (_cargos == null)
            {
                _cargos = new List<ICargo>();
            }
            _cargos.Add(cargo);
        }

        public void Accept(List<ICargo> cargos)
        {
            _cargos = cargos;
        }
    }
}