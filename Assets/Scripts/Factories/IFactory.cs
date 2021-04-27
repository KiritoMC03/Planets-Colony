using PlanetsColony.Cargos.CargoHandlingByShip;
using PlanetsColony.Pirates;
using PlanetsColony.Resources;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony.Factories
{
    public interface IFactory
    {
        bool IsRobbed { get; set; }
        void Activate();
        void Disactivate();
        void AddListenerForOnActivate(UnityAction call);
        string GetID();
        bool GetIsActive();
        void SendCargo(ISpaceshipCargoHandler ship, Resource.Type resourceType);
        void SendCargo(IPirate pirate, Resource.Type resourceType);
        Transform GetUnityTransform();
        string GetName();
        IFactoryLevel GetLinkToIFactoryLevel();
    }
}