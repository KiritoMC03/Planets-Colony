using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface IWheel
    {
        void RotateTo(Transform rotatingObject, Vector3 target);
    }
}