using UnityEngine;

namespace PlanetsColony.Spaceships.Components
{
    public interface IWheel
    {
        void RotateTo(Transform rotatingObject, Vector3 target);
    }
}