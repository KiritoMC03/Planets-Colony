using UnityEngine;

namespace PlanetsColony.Levels
{
    public interface ISpaceshipsLevelSprites
    {
        Sprite GetCurrentSprite(int currentLevel);
        Sprite TryGetCurrentSprite(int currentLevel);
    }
}