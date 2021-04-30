using UnityEngine;

namespace PlanetsColony.Spaceships.Components
{
    public interface IMotor
    {
        float GetDevelopedSpeed();
        void SetLocalVelocity();
    }
}