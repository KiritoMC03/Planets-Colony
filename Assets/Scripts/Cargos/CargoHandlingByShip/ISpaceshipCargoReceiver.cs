namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoReceiver
    {
        void Receive(ICargo cargo);
    }
}