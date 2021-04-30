using UnityEngine;

namespace PlanetsColony.Spaceships.Types
{
    public interface ICargoTransporter : ISpaceship
    {
        void SetUnityPosition(Vector3 position);
    }
}