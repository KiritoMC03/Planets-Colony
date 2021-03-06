using UnityEngine;

namespace PlanetsColony
{
    public interface IAcceptShipWithCargo
    {
        void AcceptCargoFromShip(ICargo cargo);
    }
}
