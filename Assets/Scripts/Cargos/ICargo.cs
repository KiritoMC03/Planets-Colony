using PlanetsColony.Resources;
using System.Numerics;

namespace PlanetsColony.Cargos
{
    public interface ICargo
    {
        Resource.Type GetResourceType();
        BigInteger GetValue();
    }
}