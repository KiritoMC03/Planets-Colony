using PlanetsColony.Cargos;
using System.Collections.Generic;

namespace Assets.Scripts.WorkWithSpaceships
{
    public interface ISpaceshipsStoragePort
    {
        void AddShip(CargoHandler ship);
        Queue<CargoHandler> GetAcceptedShips();
        void TryAddShip(CargoHandler ship);
    }
}