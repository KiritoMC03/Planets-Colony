using PlanetsColony.Cargos;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    public interface IPirate
    {
        void SetSpawnPosition(Vector2 position);
        void StealCargos(List<ICargo> cargos);
    }
}
