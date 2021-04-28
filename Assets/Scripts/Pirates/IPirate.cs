using PlanetsColony.Cargos;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    public interface IPirate
    {
        Transform GetTarget();
        void SetTarget(Transform target);
        void SetSpawnPosition(Vector2 position);
        void StealCargo(ICargo cargo);
        void TryStealCargo(ICargo cargo);
        void StealCargos(List<ICargo> cargos);
        bool IsEscape();
        Vector3 GetSpawnPosition();
    }
}
