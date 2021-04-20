using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Cargos
{
    public interface ISpaceshipsReceiver
    {
        void AcceptShip(SpaceshipCargoHandler ship);
    }
}