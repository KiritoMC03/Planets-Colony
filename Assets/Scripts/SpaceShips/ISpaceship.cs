using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface ISpaceship
    {
        IDeparturePlaceKeeper DeparturePlaceKeeper { get; }
        IFlying Flying { get; }
        Transform GetTarget();
        void SetTarget(Transform target);
        void UpdateTargetPoint();
    }
}