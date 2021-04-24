using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface IDeparturePlaceKeeper
    {
        Transform GetDepartureObject();
        void SetDepartureObject(Transform departureObject);
        void SetDepartureObjectAsTarget();
    }
}
