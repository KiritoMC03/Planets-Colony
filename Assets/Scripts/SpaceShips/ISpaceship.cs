using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface ISpaceship
    {
        Transform GetDepartureObject();
        Transform GetTarget();
        bool IsCanMove();
        void SetCanMove(bool value);
        void SetDepartureObject(Transform departureObject);
        void SetDepartureObjectAsTarget();
        void SetTarget(Transform target);
        void UpdateTargetPoint();
    }
}