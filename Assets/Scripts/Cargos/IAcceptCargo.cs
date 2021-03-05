using System;
using System.Collections.Generic;

namespace PlanetsColony
{
    public interface IAcceptCargo
    {
        void AcceptCargo(ICargo cargo);
        void AcceptNow();
        void AcceptFinish();
        void DeliverCargo(ICargoReceiver cargoReceiver);
        bool CheckCargo();
    }
}
