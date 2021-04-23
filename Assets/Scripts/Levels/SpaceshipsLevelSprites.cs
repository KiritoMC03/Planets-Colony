using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony.Levels
{
    public class SpaceshipsLevelSprites : MonoBehaviour, ISpaceshipsLevelSprites
    {
        [SerializeField] private Sprite[] _spriteForLevels = null;

        private void Awake()
        {
            if (_spriteForLevels == null || _spriteForLevels.Length == 0)
            {
                throw new Exception("Need one spaceship sprite or more.");
            }
        }

        public Sprite GetCurrentSprite(int currentLevel)
        {
            return _spriteForLevels[currentLevel - 1];
        }

        public Sprite TryGetCurrentSprite(int currentLevel)
        {
            if (currentLevel - 1 < _spriteForLevels.Length && _spriteForLevels[currentLevel - 1] != null)
            {
                return _spriteForLevels[currentLevel - 1];
            }
            else
            {
                throw new Exception($"Sprite for level {currentLevel} not found");
            }
        }
    }
}