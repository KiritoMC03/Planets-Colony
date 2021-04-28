using PlanetsColony.Cargos;
using System.Collections.Generic;

namespace PlanetsColony.Pirates
{
    public interface IPirateCargoKeeper
    {
        void Accept(ICargo cargo);
        void Accept(List<ICargo> cargos);
        void TryAccept(ICargo cargo);
    }
}