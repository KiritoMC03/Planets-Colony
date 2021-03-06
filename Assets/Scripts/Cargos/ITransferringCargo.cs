using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public interface ITransferringCargo
    {
        void AcceptCargo(ICargo cargo);
        void AcceptNow();
        void AcceptFinish();
        ICargo DeliverCargo(ICargoReceiver cargoReceiver);
        bool CheckCargo();
        Transform GetUnityTransform();
        void SetUnityPosition(Vector3 position);
    }
}
