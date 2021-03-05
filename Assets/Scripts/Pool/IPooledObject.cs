namespace PlanetsColony
{
    interface IPooledObject
    {
        ObjectPooler.ObjectInfo.ObjectType Type { get; }
    }
}
