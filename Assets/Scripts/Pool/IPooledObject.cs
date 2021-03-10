namespace PlanetsColony
{
    public interface IPooledObject
    {
        ObjectPooler.ObjectInfo.ObjectType Type { get; }
    }
}
