namespace PlanetsColony.Improvements
{
    public interface IImprovement
    {
        string GetLabel();
        int GetLevel();
        void LevelUp();
    }
}
