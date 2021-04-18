using System.Collections.Generic;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoKeeper
    {
        void AddCargo(Cargo cargo);
        List<Cargo> ExtractCargos();
    }
}