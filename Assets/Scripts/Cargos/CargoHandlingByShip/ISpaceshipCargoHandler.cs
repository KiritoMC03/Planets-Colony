using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Pirates;
using PlanetsColony.Spaceships.Types;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoHandler
    {
        void AcceptCargo(ICargo cargo);
        void AcceptFinish();
        void AcceptNow();
        bool CheckCargo();
        /// <summary>
        /// Must deliver the load to the argument object.
        /// </summary>
        /// <returns>Copy of the delivered cargo.</returns>
        List<ICargo> DeliverCargo(ICargoReceiver cargoReceiver);
        /// <summary>
        /// Must deliver the load to the argument object.
        /// </summary>
        /// <returns>Copy of the delivered cargo.</returns>
        List<ICargo> DeliverCargo(IPirate pirate);
        ICargoTransporter GetLinkToSpaceship();
        GameObject GetUnityObject();
    }
}