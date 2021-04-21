using PlanetsColony.Spaceships;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoHandler
    {
        void AcceptCargo(ICargo cargo);
        void AcceptFinish();
        void AcceptNow();
        bool CheckCargo();
        List<ICargo> DeliverCargo(ICargoReceiver cargoReceiver);
        ICargoTransporter GetLinkToSpaceship();
        GameObject GetUnityObject();
    }
}