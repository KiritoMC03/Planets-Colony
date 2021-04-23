using PlanetsColony.Resources;
using System.Numerics;

namespace PlanetsColony.Cargos
{
    public interface ICargoGenerator
    {
        Cargo GenerateCargo(Resource.Type type, BigInteger value);
        Cargo GenerateCargo(Resource.Type type, ulong min, ulong max);
        Cargo GenerateCargo(Resource.Type type, ulong min, ulong max, BigInteger multiplier);
    }
}