namespace PlanetsColony.Factories
{
    public interface IFactoryLevel
    {
        uint GetLevel();
        void LevelUp();
        void SetLevel(uint level);
        void SetCanLevelUp(bool value);
        bool IsCanLevelUp();
    }
}