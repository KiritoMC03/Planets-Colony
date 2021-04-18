using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;
using System.Collections.Generic;

namespace Assets.Scripts.WorkWithSpaceships
{
    public interface ISpaceshipsStoragePort
    {
        void AddShip(SpaceshipCargoHandler ship);
        Queue<SpaceshipCargoHandler> GetAcceptedShips();
        void TryAddShip(SpaceshipCargoHandler ship);
    }
}