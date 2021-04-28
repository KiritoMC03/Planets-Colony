using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface IMotor
    {
        float GetDevelopedSpeed();
        void SetLocalVelocity();
    }
}