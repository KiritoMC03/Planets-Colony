namespace PlanetsColony.Pirates
{
    public interface IPirateGuide
    {
        Planet GetRandomTarget();
        Planet TryGetRandomTarget();
    }
}