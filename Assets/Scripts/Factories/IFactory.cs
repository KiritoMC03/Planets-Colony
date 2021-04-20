using PlanetsColony.Cargos.CargoHandlingByShip;
using PlanetsColony.Resources;
using UnityEngine;

namespace PlanetsColony.Factories
{
    public interface IFactory
    {
        void Activate();
        void Disactivate();
        string GetID();
        bool GetIsActive();
        void SendCargo(SpaceshipCargoHandler ship, Resource.Type resourceType);
        Transform GetUnityTransform();
        string GetName();
        IFactoryLevel GetLinkToIFactoryLevel();
    }
}