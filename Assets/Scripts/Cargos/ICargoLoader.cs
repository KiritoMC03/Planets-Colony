using PlanetsColony.Cargos.CargoHandlingByShip;
using PlanetsColony.Factories;
using PlanetsColony.Resources;

namespace PlanetsColony.Cargos
{
    public interface ICargoLoader
    {
        void LoadCargoForShip(ref SpaceshipCargoHandler ship, ref Factory factory);
        float GetResourceRare(Resource.Type type);
    }
}