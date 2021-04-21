using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;
using System.Collections.Generic;

namespace Assets.Scripts.WorkWithSpaceships
{
    public interface ISpaceshipsStoragePort
    {
        void AddShip(ISpaceshipCargoHandler ship);
        Queue<ISpaceshipCargoHandler> GetAcceptedShips();
        void TryAddShip(ISpaceshipCargoHandler ship);
    }
}