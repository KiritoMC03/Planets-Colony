using System.Collections.Generic;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoKeeper
    {
        void AddCargo(ICargo cargo);
        List<ICargo> ExtractCargos();
    }
}