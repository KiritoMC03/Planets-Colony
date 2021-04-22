using PlanetsColony.Cargos.CargoHandlingByShip;
using PlanetsColony.Factories;
using PlanetsColony.Resources;

namespace PlanetsColony.Cargos
{
    public interface ICargoLoader
    {
        void LoadCargoForShip(ISpaceshipCargoHandler ship, IFactory factory, ResourceRarity.ResourceInfo[] resourceInfo);
    }
}