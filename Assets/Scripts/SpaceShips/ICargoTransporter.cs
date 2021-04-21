using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface ICargoTransporter : ISpaceship
    {
        void SetUnityPosition(Vector3 position);
    }
}