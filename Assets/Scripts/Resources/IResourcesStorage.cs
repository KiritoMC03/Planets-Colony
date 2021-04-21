using PlanetsColony.Cargos;
using System.Collections.Generic;
using System.Numerics;

namespace PlanetsColony.Resources
{
    public interface IResourcesStorage
    {
        void AcceptCargoFromShip(List<ICargo> cargos);
        ref Dictionary<Resource.Type, BigInteger> GetInitResourcesRef();
        BigInteger GetResourceToTrade(Resource.Type type, BigInteger value);
        BigInteger GetResourceValue(Resource.Type type);
    }
}