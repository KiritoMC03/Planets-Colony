using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public interface IAcceptCargo
    {
        void AcceptCargo(ICargo cargo);
        void AcceptNow();
        void AcceptFinish();
        void DeliverCargo(ICargoReceiver cargoReceiver);
        bool CheckCargo();
        Transform GetUnityTransform();
        void SetUnityPosition(Vector3 position);
    }
}
