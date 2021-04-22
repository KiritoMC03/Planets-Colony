namespace PlanetsColony.Resources
{
    public interface IResourceRarity
    {
        ResourceRarity.ResourceInfo[] GetResourceInfo();
        float GetResourceRare(Resource.Type type);
    }
}