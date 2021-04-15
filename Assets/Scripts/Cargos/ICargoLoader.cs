using PlanetsColony.Factories;
using PlanetsColony.Resources;

namespace PlanetsColony.Cargos
{
    public interface ICargoLoader
    {
        void LoadCargoForShip(ref CargoHandler ship, ref Factory factory);
        float GetResourceRare(Resource.Type type);
    }
}