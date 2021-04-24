using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public interface IFlying
    {
        bool IsCanMove();
        void SetCanMove(bool value);
    }
}
