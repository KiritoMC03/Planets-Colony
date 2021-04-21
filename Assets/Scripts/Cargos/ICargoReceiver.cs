using System.Collections.Generic;

namespace PlanetsColony.Cargos
{
    public interface ICargoReceiver
    {
        void Receive(List<ICargo> cargo);
    }
}