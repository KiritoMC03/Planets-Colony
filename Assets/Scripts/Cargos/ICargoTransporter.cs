using UnityEngine;
namespace PlanetsColony
{
    public interface ICargoTransporter
    {
        Transform GetTarget();
        Transform GetDepartureObject();
        void SetDepartureObjectAsTarget();
        void SetCanMove(bool canMove);
        void DeliverCargo();
    }
}
